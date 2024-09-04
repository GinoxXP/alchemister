using System;

namespace Ginox.BlackCauldron.Alchemy.Model
{
    public abstract class AIngredient
    {
        public abstract string NameKey { get; }


        public event Action Destroyed;
        public void Destroy()
            => Destroyed?.Invoke();
    }
}
