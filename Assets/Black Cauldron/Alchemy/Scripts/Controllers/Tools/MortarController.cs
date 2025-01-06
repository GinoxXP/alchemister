using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views;
using System;

namespace Ginox.BlackCauldron.Alchemy.Controllers.Tools
{
    public class MortarController
    {
        private MortarService mortarService;
        private AIngredientController hangedIngredient;
        private AIngredient performedIngredient;

        public MortarController(MortarService mortarService)
        {
            this.mortarService = mortarService;
        }

        public event Action<AIngredientView> HangedIngredientChanged;

        public void Perform()
        {
            if (hangedIngredient == null)
                return;

            performedIngredient = mortarService.Transform(hangedIngredient.Model);
            hangedIngredient.Destroy();
            hangedIngredient = null;

            HangedIngredientChanged?.Invoke(null);
        }

        public AIngredient Drop()
        {
            var ingredient = performedIngredient;
            performedIngredient = null;

            return ingredient;
        }

        public void AddIngredient(AIngredientView view)
        {
            if (hangedIngredient != null)
                return;

            hangedIngredient = view.Controller;
            HangedIngredientChanged?.Invoke(view);
        }
    }
}
