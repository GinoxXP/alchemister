using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class BeginerPotion : APotion
    {
        public BeginerPotion(Material material) : base(material)
        {
        }

        public override string NameKey => "potions.beginerPotion";
    }
}
