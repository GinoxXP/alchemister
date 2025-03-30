namespace Ginox.BlackCauldron.Alchemy.Models.Tools
{
    public class Alembic
    {
        public readonly int FUEL_FIRE_TIME = 60;

        public float Time { get; set; }

        public bool IsBurn { get; set; }

        public bool HasFuel { get; set; }

        public bool HasBottle { get; set; }

        public bool HasPotion { get; set; }

        public APotion PerformedPotion { get; set; }
    }
}
