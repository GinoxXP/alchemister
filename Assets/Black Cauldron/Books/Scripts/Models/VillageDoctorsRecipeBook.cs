using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Models
{
    public class VillageDoctorsRecipeBook : ABook
    {
        public override string NameKey { get; } = nameof(VillageDoctorsRecipeBook);

        public override List<Recipe> Recipes { get; } = new();
    }
}
