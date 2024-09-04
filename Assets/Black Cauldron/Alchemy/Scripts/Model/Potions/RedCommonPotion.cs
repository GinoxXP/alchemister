using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class RedCommonPotion : APotion
    {
        public RedCommonPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(RedCommonPotion);
    }
}
