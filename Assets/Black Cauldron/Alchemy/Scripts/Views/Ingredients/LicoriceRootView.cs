using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class LicoriceRootView : AIngredientView, IMortarInteractable
    {
        [Inject]
        private void Init(LicoriceRootController viewModel)
        {
            base.Init(viewModel);
        }

        public void Interact(MortarController controller)
        {
            controller.PutIn(this);
        }
    }
}
