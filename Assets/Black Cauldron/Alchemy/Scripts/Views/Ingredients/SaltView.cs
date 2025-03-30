using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class SaltView : AIngredientView
    {
        [Inject]
        private void Init(SaltViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
