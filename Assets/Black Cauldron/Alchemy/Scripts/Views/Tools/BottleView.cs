using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(Rigidbody))]
    public class BottleView : XRGrabInteractable, IScoopCauldron, IAlembicBottleInteract
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleController bottleController;
        private Rigidbody rigidbody;

        public BottleController BottleController => bottleController;

        [Inject]
        private void Init(BottleController bottleViewModel)
        {
            this.bottleController = bottleViewModel;
        }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Scoop(CauldronView cauldronView)
        {
            var potion = cauldronView.Finish();

            if (potion == null)
            {
                Destroy(gameObject);
                return;
            }

            bottleController.Potion = potion;
            fillingMaterial.material = potion.Material;
        }

        public void Interact(AlembicController alembicController)
        {
            if (BottleController.Potion != null)
                return;

            if (alembicController.TryAddBottle())
                Destroy(gameObject);
        }

        public void Subscribe(Transform transform)
        {
            firstFocusEntered.AddListener(x => FirstFocusEnter(x, transform));
            lastFocusExited.AddListener(LastFocusExit);
        }

        public void Unsubscribe()
        {
            firstFocusEntered.RemoveListener(x => FirstFocusEnter(x, null));
            lastFocusExited.RemoveListener(LastFocusExit);
        }

        private void LastFocusExit(FocusExitEventArgs args)
        {
            SetMovingState(false);
        }

        private void FirstFocusEnter(FocusEnterEventArgs args, Transform transform)
        {
            SetMovingState(true);

            this.transform.position = transform.position;
            this.transform.rotation = transform.rotation;
        }

        private void SetMovingState(bool state)
        {
            rigidbody.isKinematic = !state;
            rigidbody.useGravity = state;
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
