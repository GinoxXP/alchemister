using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Models.Tools;
using Ginox.BlackCauldron.Core;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.ViewModels
{
    public class FirepitViewModel : ViewModel, ITickable
    {
        private Firepit model;

        public FirepitViewModel(Firepit model)
        {
            this.model = model;
        }

        public float Time
        {
            get => model.Time;
            private set
            {
                model.Time = value;
                OnPropertyChanged();
            }
        }

        public int FuelCount
        {
            get => model.FuelCount;
            private set
            {
                model.FuelCount = value;
                OnPropertyChanged();
            }
        }

        public bool IsBurn
        {
            get => model.IsBurn;
            private set
            {
                model.IsBurn = value;
                OnPropertyChanged();
            }
        }

        public bool TryAddFuel()
        {
            if (FuelCount >= model.MAX_FIREPITS_COUNT)
                return false;

            FuelCount++;
            return true;
        }

        public void Burn()
        {
            if (FuelCount <= 0)
                return;

            IsBurn = true;
        }

        public void Tick()
        {
            if (FuelCount <= 0)
                return;

            Time += UnityEngine.Time.deltaTime;

            if (Time >= model.FUEL_FIRE_TIME)
            {
                FuelCount--;

                if (FuelCount <= 0)
                    IsBurn = false;

                Time = 0;
            }
        }
    }
}
