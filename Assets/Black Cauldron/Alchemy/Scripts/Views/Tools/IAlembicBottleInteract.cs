using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public interface IAlembicBottleInteract
    {
        public void Subscribe(Transform transform);

        public void Unsubscribe();
    }
}
