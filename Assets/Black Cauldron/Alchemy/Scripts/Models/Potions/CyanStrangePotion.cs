using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Models.Potions
{
    public class CyanStrangePotion : APotion
    {
        public CyanStrangePotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(CyanStrangePotion);
    }
}
