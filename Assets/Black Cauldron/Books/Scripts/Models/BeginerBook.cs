using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Models
{
    public class BeginerBook : ABook
    {
        public override string NameKey { get; } = nameof(BeginerBook);

        public override List<Recipe> Recipes { get; } = new();
    }
}
