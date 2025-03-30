namespace Ginox.BlackCauldron.Alchemy.Models
{
    public class Firepit
    {
        public readonly int FUEL_FIRE_TIME = 60;
        public readonly int MAX_FIREPITS_COUNT = 6;

        public int FuelCount { get; set; }

        public bool IsBurn { get; set; }

        public float Time { get; set; }
    }
}
