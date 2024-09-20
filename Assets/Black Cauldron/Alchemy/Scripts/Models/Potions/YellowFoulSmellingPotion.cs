using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Models.Potions
{
    public class YellowFoulSmellingPotion : APotion
    {
        public YellowFoulSmellingPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(YellowFoulSmellingPotion);
    }
}
