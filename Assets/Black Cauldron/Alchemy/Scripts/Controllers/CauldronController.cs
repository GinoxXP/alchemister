using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class CauldronController
    {
        private IBrewingService brewingService;

        public CauldronController(IBrewingService brewingService)
        {
            this.brewingService = brewingService;
        }

        public void PutIn(AIngredient ingredient)
            => brewingService.Brew(ingredient);

        public void Finish()
            => brewingService.FinishBrew();

        public APotion GetPotion()
            => brewingService.CompleatedPotion;
    }
}
