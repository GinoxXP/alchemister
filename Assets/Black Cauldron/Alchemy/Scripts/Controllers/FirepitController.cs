using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class FirepitController : ITickable
    {
        private const int firepitBurnTime = 60;
        public const int MAX_FIREPITS_COUNT = 5;

        private int fuelCount;
        private bool isBurn;

        public int FuelCount
        {
            get => fuelCount;
            set
            {
                fuelCount = value;
                FuelChanged?.Invoke(fuelCount);
            }
        }

        public bool IsBurn
        {
            get => isBurn;
            set
            {
                isBurn = value;
                BurnChanged?.Invoke(isBurn);
            }
        }

        private float time;

        public event Action<int> FuelChanged;

        public event Action<bool> BurnChanged;

        public void AddFuel()
        {
            if (FuelCount >= MAX_FIREPITS_COUNT)
                return;

            FuelCount++;
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

            if (time >= firepitBurnTime)
            {
                FuelCount--;

                if (FuelCount <= 0)
                    IsBurn = false;

                time = 0;
            }
        }
    }
}
