using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View.Ingredients
{
    public class FlyAgaricView : AIngredientView
    {
        [Inject]
        private void Init(FlyAgaricViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
