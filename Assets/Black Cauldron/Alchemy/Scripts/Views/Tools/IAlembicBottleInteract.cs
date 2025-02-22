using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public interface IAlembicBottleInteract
    {
        public void PlugIn(Transform transform);

        public void PlugOut();
    }
}
