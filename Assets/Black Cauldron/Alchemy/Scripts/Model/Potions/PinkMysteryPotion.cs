using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class PinkMysteryPotion : APotion
    {
        public PinkMysteryPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(PinkMysteryPotion);
    }
}
