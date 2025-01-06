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
            Model = model;
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
        }
    }
}
