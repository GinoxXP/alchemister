using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public interface IAlembicBottleInteract
    {
        public void PlugIn(AlembicBottleHolderView view);

        public void PlugOut(AlembicBottleHolderView view);
    }
}
