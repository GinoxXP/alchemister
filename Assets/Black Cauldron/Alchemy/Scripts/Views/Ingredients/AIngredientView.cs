using Ginox.BlackCauldron.Alchemy.ViewModels;
using Ginox.BlackCauldron.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public abstract class AIngredientView : MonoBehaviour, IScoopCauldron, IPokeIndicatorDisplay
    {
        private LocalizedString localizedName;

        public AIngredientViewModel ViewModel { get; protected set; }

        public string DisplayableText { get; private set; }

        protected void Init(AIngredientViewModel controller)
        {
            ViewModel = controller;
            ViewModel.Destroyed += OnDestroyed;
        }

        private void Start()
        {
            localizedName = new LocalizedString("Ingredients", ViewModel.Model.NameKey);
            localizedName.StringChanged += OnStringChanged;
        }

        private void OnStringChanged(string value)
            => DisplayableText = value;

        public void Scoop(CauldronView cauldronView)
        {
            cauldronView.PutIn(ViewModel);
        }

        private void OnDestroy()
        {
            ViewModel.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            Destroy(gameObject);
        }

        public void SetInteractableState(bool isInteractable)
        {
            var colliders = GetComponentsInChildren<Collider>();
            var xrGrabs = GetComponentsInChildren<XRGrabInteractable>();
            var rigidbodies = GetComponentsInChildren<Rigidbody>();

            foreach (var collider  in colliders)
                collider.enabled = isInteractable;

            foreach (var xrGrab in xrGrabs)
                xrGrab.enabled = isInteractable;

            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = !isInteractable;
                rigidbody.useGravity = isInteractable;
            }
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
