using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class BayLeafsView : AIngredientView
    {
        [Inject]
        private void Init(BayLeafsController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
