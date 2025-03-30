using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class AshView : AIngredientView
    {
        [Inject]
        private void Init(AshViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
