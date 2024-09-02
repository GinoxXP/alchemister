using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View.Ingredients
{
    public class CattailCobView : AIngredientView
    {
        [Inject]
        private void Init(CattailCobViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
