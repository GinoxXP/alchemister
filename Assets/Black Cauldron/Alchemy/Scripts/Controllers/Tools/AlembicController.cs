using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Controllers.Tools
{
    public class AlembicController : ITickable
    {
        private const int FUEL_FIRE_TIME = 60;

        private float time;
        private bool isBurn;
        private bool hasFuel;
        private bool hasBottle;

        public bool IsBurn
        {
            get => isBurn;
            private set
            {
                isBurn = value;
                BurnChanged?.Invoke(isBurn);
            }
        }

        public bool HasFuel
        {
            get => hasFuel;
            private set
            {
                hasFuel = value;
                HasFuelChanged?.Invoke(hasFuel);
            }
        }

        public bool HasBottle
        {
            get => hasBottle;
            private set
            {
                hasBottle = value;
                HasBottleChanged?.Invoke(hasBottle);
            }
        }

        public event Action<bool> HasFuelChanged;


        public event Action<bool> BurnChanged;

        public event Action<bool> HasBottleChanged;


        public bool TryAddFuel()
        {
            if (HasFuel)
                return false;

            HasFuel = true;
            return true;
        }

        public void TryBurn()
        {
            if (!HasFuel || IsBurn)
                return;

            IsBurn = true;
        }

        public bool TryAddBottle()
        {
            if (HasBottle)
                return false;

            HasBottle = true;
            return true;
        }

        public bool TryRemoveBottle()
        {
            if (!HasBottle)
                return false;

            HasBottle = false;
            return true;
        }

        public void Tick()
        {
            if (!IsBurn)
                return;

            time += Time.deltaTime;

            if (time >= FUEL_FIRE_TIME)
            {
                IsBurn = false;
                HasFuel = false;
                time = 0;
            }
        }
    }
}
