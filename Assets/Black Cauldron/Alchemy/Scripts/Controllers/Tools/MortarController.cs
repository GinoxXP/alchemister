using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views;
using System;

namespace Ginox.BlackCauldron.Alchemy.Controllers.Tools
{
    public class MortarController
    {
        private MortarService mortarService;
        private AIngredientView hangedIngredient;
        private AIngredient performedIngredient;

        public MortarController(MortarService mortarService)
        {
            this.mortarService = mortarService;
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
            if (hangedIngredient == null)
                return;

            performedIngredient = mortarService.Transform(hangedIngredient.Controller.Model);
            hangedIngredient.Controller.Destroy();
            hangedIngredient = null;

            HangedIngredientChanged?.Invoke(null);
            PerformedIngredientChanged?.Invoke(performedIngredient);
        }

        private AIngredient Drop()
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
