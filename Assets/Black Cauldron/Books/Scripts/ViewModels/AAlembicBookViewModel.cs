using System.Collections.Generic;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Books.Models;

namespace Ginox.BlackCauldron.Books.ViewModels
{
    public class AAlembicBookViewModel : ABookViewModel
    {
        public AAlembicBook Model { get; protected set; }
        
        public List<PotionTransformation> Transformations => Model.Transformations;
        
        public void RegisterTransformation(PotionTransformation transformation)
            => Transformations.Add(transformation);
    }
}