using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views.Ingredients;
using System;

namespace Ginox.BlackCauldron.Alchemy.ViewModels.Tools
{
    public class MortarViewModel
    {
        private static readonly int PERFORM_MAX_RANDOM_RANGE = 5;

        private Random random;
        private IMortarService mortarService;
        private AIngredientView hangedIngredient;
        private AIngredient performedIngredient;

        public MortarViewModel(IMortarService mortarService)
        {
            this.mortarService = mortarService;
            random = new Random();
        }

        public AIngredientView HangedIngredient => hangedIngredient;

        public bool IsReadyForAddIngredient { get; set; } = true;

        public event Action<AIngredientView> HangedIngredientChanged;

        public event Action<AIngredient> PerformedIngredientChanged;

        public void PutIn(AIngredientView view)
        {
            if (!IsReadyForAddIngredient)
                return;

            if (hangedIngredient != null)
                return;

            hangedIngredient = view;
            HangedIngredientChanged?.Invoke(view);
        }

        public AIngredient PutOut()
        {
            if (hangedIngredient != null)
            {
                RemoveIngredient();
                return null;
            }

            return Drop();
        }

        public void Perform()
        {
            var randomValue = random.Next(PERFORM_MAX_RANDOM_RANGE);
            if (randomValue != 0)
                return;

            if (hangedIngredient == null)
                return;

            performedIngredient = mortarService.Transform(hangedIngredient.ViewModel.Model);
            hangedIngredient.ViewModel.Destroy();
            hangedIngredient = null;

            HangedIngredientChanged?.Invoke(null);
            PerformedIngredientChanged?.Invoke(performedIngredient);
        }

        public AIngredient Drop()
        {
            var ingredient = performedIngredient;
            performedIngredient = null;

            PerformedIngredientChanged?.Invoke(performedIngredient);

            return ingredient;
        }

        private void RemoveIngredient()
        {
            hangedIngredient.SetInteractableState(true);
            hangedIngredient.transform.parent = null;
            hangedIngredient = null;
        }
    }
}
