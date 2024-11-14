using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public class FirepitController : ITickable
    {
        private const int firepitBurnTime = 60;
        public const int MAX_FIREPITS_COUNT = 5;

        public int FuelCount { get; private set; }

        private float time;

        public event Action<int> FuelChanged;

        public void AddFuel()
        {
            if (FuelCount >= MAX_FIREPITS_COUNT)
                return;

            FuelCount++;
            FuelChanged?.Invoke(FuelCount);
        }

        public void Tick()
        {
            if (FuelCount <= 0)
                return;

            time += Time.deltaTime;

            if (time >= firepitBurnTime)
            {
                FuelCount--;
                FuelChanged?.Invoke(FuelCount);
                time = 0;
            }
        }
    }
}
