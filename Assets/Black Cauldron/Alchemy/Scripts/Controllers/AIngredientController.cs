using Ginox.BlackCauldron.Alchemy.Models;
using System;

namespace Ginox.BlackCauldron.Alchemy.Controllers
{
    public abstract class AIngredientController
    {
        public event Action Destroyed;

        public AIngredient Model { get; private set; }

        public AIngredientController(AIngredient model)
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
