using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
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
