﻿using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Ingredients
{
    public class LicoriceRootView : AIngredientView, IMortarInteractable
    {
        [Inject]
        private void Init(LicoriceRootViewModel viewModel)
        {
            base.Init(viewModel);
        }

        public void Interact(MortarViewModel controller)
        {
            controller.PutIn(this);
        }
    }
}
