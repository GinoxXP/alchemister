using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class HerringSkinView : AIngredientView
    {
        [Inject]
        private void Init(HerringSkinController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
