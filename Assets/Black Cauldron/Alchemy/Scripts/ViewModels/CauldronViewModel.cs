using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;

namespace Ginox.BlackCauldron.Alchemy.ViewModels
{
    public class CauldronViewModel
    {
        private IBrewingService brewingService;

        public CauldronViewModel(IBrewingService brewingService)
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
