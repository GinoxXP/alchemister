namespace Ginox.BlackCauldron.Alchemy.Models
{
    public class PotionTransformation
    {
        public PotionTransformation(
            APotion inputPotion,
            APotion outputPotion)
        {
            InputPotion = inputPotion;
            OutputPotion = outputPotion;
        }

        public APotion InputPotion { get; private set; }

        public APotion OutputPotion { get; private set; }
    }
}
