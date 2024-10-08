using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class CauldronController
    {
        private BrewingService brewingService;

        public CauldronController(BrewingService brewingService)
        {
            this.brewingService = brewingService;
        }

        public void PutIn(AIngredient ingredient)
            => brewingService.Brew(ingredient);

        public APotion Finish()
            => brewingService.FinishBrew();

        public APotion GetPotion()
            => brewingService.GetPotion();
    }
}
