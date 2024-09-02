using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View.Ingredients
{
    public class BayLeafsView : AIngredientView
    {
        [Inject]
        private void Init(BayLeafsViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
