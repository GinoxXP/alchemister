using Ginox.BlackCauldron.Alchemy.ViewModel;
using UnityEngine;
using UnityEngine.Localization;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public abstract class AIngredientView : MonoBehaviour, IScoopCauldron
    {
        private LocalizedString localizedName;

        public AIngredientViewModel ViewModel { get; protected set; }
        public string Name { get; private set; }

        protected void Init(AIngredientViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Destroyed += OnDestroyed;
        }

        private void Start()
        {
            localizedName = new LocalizedString("Alchemy", ViewModel.Model.NameKey);
            localizedName.StringChanged += OnStringChanged;
            Name = localizedName.GetLocalizedString();
        }
        private void OnStringChanged(string value)
        {
            Name = value;
        }

        public void Scoop(CauldronView cauldronView)
        {
            cauldronView.PutIn(ViewModel.Model);
        }

        public void OnDestroy()
        {
            ViewModel.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            Destroy(gameObject);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
