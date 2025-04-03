using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Models
{
    public abstract class ABook
    {
        public abstract string NameKey { get; }

        public abstract List<Recipe> Recipes { get; }
    }
}
