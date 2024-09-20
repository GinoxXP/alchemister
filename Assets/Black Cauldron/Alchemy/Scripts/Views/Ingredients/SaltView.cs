using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class SaltView : AIngredientView
    {
        [Inject]
        private void Init(SaltController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
