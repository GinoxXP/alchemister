using Ginox.BlackCauldron.Alchemy.Model;

namespace Ginox.BlackCauldron.Alchemy.ViewModel
{
    public abstract class AIngredientViewModel
    {
        public AIngredient Model { get; private set; }

        public AIngredientViewModel(AIngredient model)
        {
            this.Model = model;
        }
    }
}
