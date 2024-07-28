using Ginox.BlackCauldron.Alchemy.ViewModel;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public abstract class AIngredientView : MonoBehaviour
    {
        public AIngredientViewModel ViewModel { get; protected set; }

        protected void Init(AIngredientViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
