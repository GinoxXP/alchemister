using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.ViewModels.Tools
{
    public class AlembicViewModel : ITickable
    {
        private const int FUEL_FIRE_TIME = 60;

        private float time;
        private bool isBurn;
        private bool hasFuel;
        private bool hasBottle;
        private bool hasPotion;

        private BottleView handledBottleView;
        private APotion inputPotion;

        private IAlembicService alembicService;

        public AlembicViewModel(IAlembicService alembicService)
        {
            this.alembicService = alembicService;
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

        public bool HasPotion
        {
            get => hasPotion;
            private set
            {
                hasPotion = value;
                HasPotionChanged?.Invoke(hasPotion);
            }
        }

        public event Action<bool> HasFuelChanged;

        public event Action<bool> BurnChanged;

        public event Action<bool> HasBottleChanged;

        public event Action<bool> HasPotionChanged;

        public event Action<APotion> PotionPerformed;


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

            TryPerformTransformation();
        }

        public bool TryAddBottle(BottleView bottleView)
        {
            if (HasBottle)
                return false;

            if (bottleView.ContainedPotion != null)
                return false;

            HasBottle = true;
            handledBottleView = bottleView;

            TryPerformTransformation();

            return true;
        }

        public bool TryRemoveBottle()
        {
            if (!HasBottle)
                return false;

            HasBottle = false;
            return true;
        }

        public bool TryAddPotion(APotion potion)
        {
            if (HasPotion)
                return false;

            HasPotion = true;
            inputPotion = potion;

            TryPerformTransformation();

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

        private void TryPerformTransformation()
        {
            if (!IsBurn || !HasBottle || !HasPotion)
                return;

            var outputPotion = alembicService.Transform(inputPotion);
            if (outputPotion != null)
                PotionTransformationSuccess(outputPotion);

            ClearInputPotion();
        }

        private void ClearInputPotion()
        {
            HasPotion = false;
            inputPotion = null;
        }

        private void PotionTransformationSuccess(APotion potion)
        {
            PotionPerformed?.Invoke(potion);
            handledBottleView.SetPotion(potion);
        }
    }
}
