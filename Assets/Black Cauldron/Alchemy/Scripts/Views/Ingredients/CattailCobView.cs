using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class CattailCobView : AIngredientView, IMortarInteractable
    {
        [Inject]
        private void Init(CattailCobController viewModel)
        {
            base.Init(viewModel);
        }

        public void Interact(MortarController controller)
        {
            controller.PutIn(this);
        }
    }
}
