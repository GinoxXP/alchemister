namespace Ginox.BlackCauldron.Progression.Models
{
    public class Level
    {
        public int PassExperience { private set; get; }

        public Level(int passExperience)
        {
            PassExperience = passExperience;
        }
    }
}
