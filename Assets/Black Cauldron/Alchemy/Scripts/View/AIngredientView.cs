using Ginox.BlackCauldron.Alchemy.ViewModel;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public abstract class AIngredientView : MonoBehaviour, IScoopCauldron
    {
        public AIngredientViewModel ViewModel { get; protected set; }

        protected void Init(AIngredientViewModel viewModel)
        {
            ViewModel = viewModel;
            viewModel.Destroyed += OnDestroyed;
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
    }
}
