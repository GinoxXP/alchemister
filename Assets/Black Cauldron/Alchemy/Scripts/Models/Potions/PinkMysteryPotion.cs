using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Models.Potions
{
    public class PinkMysteryPotion : APotion
    {
        public PinkMysteryPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(PinkMysteryPotion);
    }
}
