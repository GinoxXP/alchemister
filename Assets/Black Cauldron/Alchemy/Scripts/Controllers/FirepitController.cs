using System;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class FirepitController
    {
        public const int MAX_FIREPITS_COUNT = 5;

        public int FuelCount { get; private set; }

        public event Action<int> FuelChanged;

        public void AddFuel()
        {
            if (FuelCount >= MAX_FIREPITS_COUNT)
                return;

            FuelCount++;
            FuelChanged?.Invoke(FuelCount);
        }
    }
}
