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

        private Transform bottleHandlerAlembic;

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

        public void PlugIn(Transform transform)
        {
            bottleHandlerAlembic = transform;

            firstSelectEntered.AddListener(FirstFocusEnter);
            lastSelectExited.AddListener(LastFocusExit);

            if (!isSelected)
                PutBottleToAlembic();
        }

        public void PlugOut()
        {
            firstSelectEntered.RemoveListener(FirstFocusEnter);
            lastSelectExited.RemoveListener(LastFocusExit);
        }

        private void LastFocusExit(SelectExitEventArgs args)
        {
            PutBottleToAlembic();
        }

        private void PutBottleToAlembic()
        {
            SetMovingState(false);


            transform.position = bottleHandlerAlembic.position;
            transform.rotation = bottleHandlerAlembic.rotation;
        }

        private void FirstFocusEnter(SelectEnterEventArgs args)
        {
            SetMovingState(true);
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
