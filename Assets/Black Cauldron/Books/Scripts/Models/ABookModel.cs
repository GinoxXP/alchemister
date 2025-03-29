using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Models
{
    public abstract class ABookModel
    {
        public List<Recipe> Recipes { get; private set; } = new();
    }
}
