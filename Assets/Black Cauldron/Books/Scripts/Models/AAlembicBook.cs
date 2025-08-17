using System.Collections.Generic;
using Ginox.BlackCauldron.Alchemy.Models;

namespace Ginox.BlackCauldron.Books.Models
{
    public abstract class AAlembicBook : ABook
    {
        public abstract List<PotionTransformation> Transformations { get; }
    }
}