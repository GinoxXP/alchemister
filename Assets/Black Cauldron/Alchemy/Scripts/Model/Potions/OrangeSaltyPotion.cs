using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class OrangeSaltyPotion : APotion
    {
        public OrangeSaltyPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(OrangeSaltyPotion);
    }
}
