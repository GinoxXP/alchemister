using Ginox.BlackCauldron.Alchemy.Controllers;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public abstract class AIngredientView : MonoBehaviour, IScoopCauldron, IMortarInteractable
    {
        private LocalizedString localizedName;

        public AIngredientController Controller { get; protected set; }
        public string Name { get; private set; }

        protected void Init(AIngredientController controller)
        {
            Controller = controller;
            Controller.Destroyed += OnDestroyed;
        }

        private void Start()
        {
            localizedName = new LocalizedString("Alchemy", Controller.Model.NameKey);
            localizedName.StringChanged += OnStringChanged;
            Name = localizedName.GetLocalizedString();
        }
        private void OnStringChanged(string value)
        {
            Name = value;
        }

        public void Scoop(CauldronView cauldronView)
        {
            cauldronView.PutIn(Controller);
        }

        private void OnDestroy()
        {
            Controller.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            Destroy(gameObject);
        }

        public void Interact(MortarController controller)
        {
            controller.AddIngredient(this);
        }

        public void SetInteractableState(bool isInteractable)
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            var colliders = GetComponentsInChildren<Collider>();
            var xrGrabs = GetComponentsInChildren<XRGrabInteractable>();

            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = !isInteractable;
                rigidbody.useGravity = isInteractable;
            }

            foreach (var collider  in colliders)
                collider.enabled = isInteractable;

            foreach (var xrGrab in xrGrabs)
                xrGrab.enabled = isInteractable;
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
