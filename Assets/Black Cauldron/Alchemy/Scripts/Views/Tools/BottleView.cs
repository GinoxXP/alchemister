using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;
using UnityEngine.Localization;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(Rigidbody))]
    public class BottleView : XRGrabInteractable, IScoopCauldron, IPourAlembic, IPokeIndicatorDisplay
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleViewModel bottleViewModel;
        private TurnOverBehaviour turnOverBehaviour;
        private LocalizedString localizedName;

        public BottleViewModel BottleViewModel => bottleViewModel;

        public string DisplayableText { get; private set; }

        public APotion ContainedPotion => bottleViewModel.Potion;

        [Inject]
        private void Init(BottleViewModel bottleViewModel)
        {
            this.bottleViewModel = bottleViewModel;
        }

        private void Start()
        {
            turnOverBehaviour = GetComponent<TurnOverBehaviour>();
            turnOverBehaviour.TurnOverStateChanged += OnTurnOverStateChanged;

            if (BottleViewModel.Potion != null)
                localizedName = new LocalizedString("Potions", BottleViewModel.Potion.NameKey);
            else
                localizedName = new LocalizedString();

            localizedName.StringChanged += OnStringChanged;
        }

        private new void OnDestroy()
        {
            base.OnDestroy();

            localizedName.StringChanged -= OnStringChanged;
        }

        private void OnStringChanged(string value)
        {
            DisplayableText = value;
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
            if (BottleViewModel.Potion == null)
                return;

            alembicController.TryAddPotion(BottleViewModel.Potion);
            BottleViewModel.Potion = null;
            fillingMaterial.gameObject.SetActive(false);
        }

        public void SetPotion(APotion potion)
        {
            BottleViewModel.Potion = potion;
            fillingMaterial.material = potion.Material;
            fillingMaterial.gameObject.SetActive(true);

            localizedName = new LocalizedString("Potions", BottleViewModel.Potion.NameKey);
            DisplayableText = localizedName.GetLocalizedString();
        }

        private void OnTurnOverStateChanged(bool state)
        {
            if (BottleViewModel.Potion == null)
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
