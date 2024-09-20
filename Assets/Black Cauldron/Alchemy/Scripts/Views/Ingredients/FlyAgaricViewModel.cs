using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class FlyAgaricView : AIngredientView
    {
        [Inject]
        private void Init(FlyAgaricController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
