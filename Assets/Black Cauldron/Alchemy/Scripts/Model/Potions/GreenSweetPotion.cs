using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class GreenSweetPotion : APotion
    {
        public GreenSweetPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(GreenSweetPotion);
    }
}
