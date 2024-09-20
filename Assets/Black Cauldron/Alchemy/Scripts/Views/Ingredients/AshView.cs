using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class AshView : AIngredientView
    {
        [Inject]
        private void Init(AshController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
