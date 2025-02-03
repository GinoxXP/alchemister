using Ginox.BlackCauldron.Alchemy.Views.Ingredients;
using System;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class IngredientSpawner : MonoBehaviour
    {
        public delegate GameObject CreateIngredient();

        private CreateIngredient createIngredient;

        #region Factories
        private AIngredientView.Factory<AshView> ashFactory;
        private AIngredientView.Factory<BayLeafsView> bayLeafsFactory;
        private AIngredientView.Factory<CattailCobView> cattailCobFactory;
        private AIngredientView.Factory<FlyAgaricView> flyAgaricFactory;
        private AIngredientView.Factory<LicoriceRootView> licoriceRootFactory;
        private AIngredientView.Factory<PineConeView> pineConeFactory;
        private AIngredientView.Factory<SaltView> saltFactory;
        private AIngredientView.Factory<PaprikaView> paprikaFactory;
        private AIngredientView.Factory<HerringSkinView> herringFactory;
        private AIngredientView.Factory<MintView> mintFactory;
        private AIngredientView.Factory<BeaverTailView> beaverTailFactory;
        private AIngredientView.Factory<CoalView> coalFactory;
        private AIngredientView.Factory<CoalPowderView> coalPowderFactory;
        #endregion

        [Inject]
        private void Init(
            AIngredientView.Factory<AshView> ashFactory,
            AIngredientView.Factory<BayLeafsView> bayLeafsFactory,
            AIngredientView.Factory<CattailCobView> cattailCobFactory,
            AIngredientView.Factory<FlyAgaricView> flyAgaricFactory,
            AIngredientView.Factory<LicoriceRootView> licoriceRootFactory,
            AIngredientView.Factory<PineConeView> pineConeFactory,
            AIngredientView.Factory<SaltView> saltFactory,
            AIngredientView.Factory<PaprikaView> paprikaFactory,
            AIngredientView.Factory<HerringSkinView> herringFactory,
            AIngredientView.Factory<MintView> mintFactory,
            AIngredientView.Factory<BeaverTailView> beaverTailFactory,
            AIngredientView.Factory<CoalView> coalFactory,
            AIngredientView.Factory<CoalPowderView> coalPowderFactory)
        {
            this.ashFactory = ashFactory;
            this.bayLeafsFactory = bayLeafsFactory;
            this.cattailCobFactory = cattailCobFactory;
            this.flyAgaricFactory = flyAgaricFactory;
            this.licoriceRootFactory = licoriceRootFactory;
            this.pineConeFactory = pineConeFactory;
            this.saltFactory = saltFactory;
            this.paprikaFactory = paprikaFactory;
            this.herringFactory = herringFactory;
            this.mintFactory = mintFactory;
            this.beaverTailFactory = beaverTailFactory;
            this.coalFactory = coalFactory;
            this.coalPowderFactory = coalPowderFactory;
        }

        public GameObject CreateByName(string name)
        {
            name = name
                .Replace("View", string.Empty)
                .Replace("Model", string.Empty)
                .Replace("Controller", string.Empty);

            Enum.TryParse(name, out Ingredient ingredient);

            var ingredientGameObject = SetIngredient(ingredient).Invoke();
            return ingredientGameObject;
        }

        public CreateIngredient SetIngredient(Ingredient ingredient)
        {
            GameObject Create() => ingredient switch
            {
                Ingredient.Ash => ashFactory.Create().gameObject,
                Ingredient.BayLeafs => bayLeafsFactory.Create().gameObject,
                Ingredient.CattailCob => cattailCobFactory.Create().gameObject,
                Ingredient.FlyAgaric => flyAgaricFactory.Create().gameObject,
                Ingredient.LicoriceRoot => licoriceRootFactory.Create().gameObject,
                Ingredient.PineCone => pineConeFactory.Create().gameObject,
                Ingredient.Salt => saltFactory.Create().gameObject,
                Ingredient.Paprika => paprikaFactory.Create().gameObject,
                Ingredient.HerringSkin => herringFactory.Create().gameObject,
                Ingredient.Mint => mintFactory.Create().gameObject,
                Ingredient.BeaverTail => beaverTailFactory.Create().gameObject,
                Ingredient.Coal => coalFactory.Create().gameObject,
                Ingredient.CoalPowder => coalPowderFactory.Create().gameObject,
                _ => throw new NotImplementedException(),
            };

            return Create;
        }
    }
}
