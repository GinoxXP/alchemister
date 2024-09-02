using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View.Ingredients
{
    public class PineConeView : AIngredientView
    {
        [Inject]
        private void Init(PineConeViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
