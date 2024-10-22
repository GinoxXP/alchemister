using System;

namespace Ginox.BlackCauldron.Alchemy.Models
{
    public abstract class AIngredient
    {
        public abstract string NameKey { get; }


        public event Action Destroyed;

        public void Destroy()
            => Destroyed?.Invoke();
    }
}
