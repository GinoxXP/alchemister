using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class FlyAgaricView : AIngredientView, IMortarInteractable
    {
        [Inject]
        private void Init(FlyAgaricController viewModel)
        {
            base.Init(viewModel);
        }

        public void Interact(MortarController controller)
        {
            controller.PutIn(this);
        }
    }
}
