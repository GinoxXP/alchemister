using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class BlueUselessPotion : APotion
    {
        public BlueUselessPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(BlueUselessPotion);
    }
}
