using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Core;

namespace Ginox.BlackCauldron.Alchemy.ViewModels
{
    public class CauldronViewModel : ViewModel
    {
        private IBrewingService brewingService;
        private Cauldron model;

        public CauldronViewModel(
            IBrewingService brewingService,
            Cauldron model)
        {
            this.brewingService = brewingService;
            this.model = model;
        }

        public bool IsBoiling
        {
            get => model.IsBoiling;
            set
            {
                model.IsBoiling = value;
                OnPropertyChanged();
            }
        }

        public bool IsFilled
        {
            get => model.IsFilled;
            set
            {
                model.IsFilled = value;
                OnPropertyChanged();
            }
        }

        public bool IsHasFire
        {
            get => model.IsHasFire;
            set
            {
                model.IsHasFire = value;
                OnPropertyChanged();
            }
        }

        public APotion CompleatedPotion
            => brewingService.CompleatedPotion;

        public void Fill()
            => IsFilled = true;

        public void Drain()
            => IsFilled = false;

        public APotion Finish()
        {
            Drain();

            return CompleatedPotion;
        }

        public void PutIn(AIngredient ingredient)
        {
            brewingService.Brew(ingredient);
        }
    }
}
