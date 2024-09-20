using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class LicoriceRootView : AIngredientView
    {
        [Inject]
        private void Init(LicoriceRootController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
