using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class PineConeView : AIngredientView
    {
        [Inject]
        private void Init(PineConeController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
