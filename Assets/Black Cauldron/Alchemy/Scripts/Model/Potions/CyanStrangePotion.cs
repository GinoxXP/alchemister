using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class CyanStrangePotion : APotion
    {
        public CyanStrangePotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(CyanStrangePotion);
    }
}
