using Ginox.BlackCauldron.Alchemy.Model;
using System;

namespace Ginox.BlackCauldron.Alchemy.ViewModel
{
    public abstract class AIngredientViewModel
    {
        public event Action Destroyed;

        public AIngredient Model { get; private set; }

        public AIngredientViewModel(AIngredient model)
        {
            this.Model = model;
            model.Destroyed += OnDestroyed;
        }

        private void OnDestroyed()
        {
            Destroyed?.Invoke();
        }
    }
}
