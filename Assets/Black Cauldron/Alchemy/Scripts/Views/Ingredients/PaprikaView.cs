using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class PaprikaView : AIngredientView
    {
        [Inject]
        private void Init(PaprikaController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
