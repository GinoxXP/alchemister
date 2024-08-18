using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model
{
    public abstract class APotion
    {
        public Material Material { get; private set; }

        public Recipe Recipe { get; set; }

        public APotion(Material material)
        {
            Material = material;
        }
    }
}
