﻿using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class CattailCobView : AIngredientView, IMortarInteractable
    {
        [Inject]
        private void Init(CattailCobViewModel viewModel)
        {
            base.Init(viewModel);
        }

        public void Interact(MortarViewModel controller)
        {
            controller.PutIn(this);
        }
    }
}
