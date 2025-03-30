using Ginox.BlackCauldron.Alchemy.Models;
using System;

namespace Ginox.BlackCauldron.Alchemy.ViewModels
{
    public abstract class AIngredientViewModel
    {
        public event Action Destroyed;

        public AIngredient Model { get; private set; }

        public AIngredientViewModel(AIngredient model)
        {
            Model = model;
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
        }
    }
}
