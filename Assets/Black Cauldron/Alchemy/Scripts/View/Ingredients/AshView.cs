using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
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
