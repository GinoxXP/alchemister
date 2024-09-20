using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Models.Potions
{
    public class RedCommonPotion : APotion
    {
        public RedCommonPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(RedCommonPotion);
    }
}
