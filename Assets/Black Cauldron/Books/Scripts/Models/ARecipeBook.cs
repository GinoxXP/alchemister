using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Models
{
    public abstract class ARecipeBook : ABook
    {
        public abstract List<Recipe> Recipes { get; }
    }
}