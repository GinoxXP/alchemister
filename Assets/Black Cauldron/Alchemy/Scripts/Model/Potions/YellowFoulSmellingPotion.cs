using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model.Potions
{
    public class YellowFoulSmellingPotion : APotion
    {
        public YellowFoulSmellingPotion(Material material) : base(material)
        {
        }

        public override string NameKey => nameof(YellowFoulSmellingPotion);
    }
}
