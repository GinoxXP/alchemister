using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model
{
    public abstract class APotion
    {
        public abstract string NameKey { get; }

        public Material Material { get; private set; }

        public APotion(Material material)
        {
            Material = material;
        }
    }
}
