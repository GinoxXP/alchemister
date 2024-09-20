using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class CattailCobView : AIngredientView
    {
        [Inject]
        private void Init(CattailCobController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
