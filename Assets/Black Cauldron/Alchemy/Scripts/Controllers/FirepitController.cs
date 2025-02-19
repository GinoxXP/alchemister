using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class FirepitController : ITickable
    {
        private const int FUEL_FIRE_TIME = 60;
        private const int MAX_FIREPITS_COUNT = 6;

        private int fuelCount;
        private bool isBurn;

        public int FuelCount
        {
            get => fuelCount;
            private set
            {
                fuelCount = value;
                FuelChanged?.Invoke(fuelCount);
            }
        }

        public bool IsBurn
        {
            get => isBurn;
            private set
            {
                isBurn = value;
                BurnChanged?.Invoke(isBurn);
            }
        }

        private float time;

        public event Action<int> FuelChanged;

        public event Action<bool> BurnChanged;

        public bool TryAddFuel()
        {
            if (FuelCount >= MAX_FIREPITS_COUNT)
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

            time += Time.deltaTime;

            if (time >= FUEL_FIRE_TIME)
            {
                FuelCount--;

                if (FuelCount <= 0)
                    IsBurn = false;

                time = 0;
            }
        }
    }
}
