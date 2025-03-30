using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(Rigidbody))]
    public class BottleView : XRGrabInteractable, IScoopCauldron, IPourAlembic
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleViewModel bottleController;
        private TurnOverBehaviour turnOverBehaviour;

        public BottleViewModel BottleController => bottleController;

        [Inject]
        private void Init(BottleViewModel bottleViewModel)
        {
            this.bottleController = bottleViewModel;
        }

        private void Start()
        {
            turnOverBehaviour = GetComponent<TurnOverBehaviour>();
            turnOverBehaviour.TurnOverStateChanged += OnTurnOverStateChanged;
        }

        public void Scoop(CauldronView cauldronView)
        {
            var potion = cauldronView.Finish();

            if (potion == null)
            {
                Destroy(gameObject);
                return;
            }

            SetPotion(potion);
        }

        public void Pour(AlembicViewModel alembicController)
        {
            if (BottleController.Potion == null)
                return;

            alembicController.TryAddPotion(BottleController.Potion);
            BottleController.Potion = null;
            fillingMaterial.gameObject.SetActive(false);
        }

        public void SetPotion(APotion potion)
        {
            BottleController.Potion = potion;
            fillingMaterial.material = potion.Material;
            fillingMaterial.gameObject.SetActive(true);
        }

        private void OnTurnOverStateChanged(bool state)
        {
            if (BottleController.Potion == null)
                return;

            if (state)
                Drain();
        }

        private void Drain()
        {
            var castExists = Physics.Raycast(turnOverBehaviour.Offset.position, Vector3.down, out var hit);
            if (!castExists || !hit.collider.TryGetComponent<AlembicBottleNeckView>(out var alembicBottleNeck))
                return;

            alembicBottleNeck.Pour(this);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
