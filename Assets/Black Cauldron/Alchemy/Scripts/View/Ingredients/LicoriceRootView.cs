using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View.Ingredients
{
    public class LicoriceRootView : AIngredientView
    {
        [Inject]
        private void Init(LicoriceRootViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
