using Ginox.BlackCauldron.Alchemy.Model;
using Ginox.BlackCauldron.Alchemy.Service;

namespace Ginox.BlackCauldron.Alchemy.ViewModel
{
    public class CauldronViewModel
    {
        private BrewingService brewingService;

        public CauldronViewModel(BrewingService brewingService)
        {
            this.brewingService = brewingService;
        }

        public void PutIn(AIngredient ingredient)
        {
            brewingService.Brew(ingredient);
        }
    }
}
