using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class PaprikaView : AIngredientView
    {
        [Inject]
        private void Init(PaprikaViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
