using Ginox.BlackCauldron.Alchemy.View.Ingredients;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public class IngredientSpawner : MonoBehaviour
    {
        [SerializeField]
        private Ingredient ingredient;

        [Inject]
        private void Init(
            AIngredientView.Factory<AshView> ashFactory,
            AIngredientView.Factory<BayLeafsView> bayLeafsFactory,
            AIngredientView.Factory<CattailCobView> cattailCobFactory,
            AIngredientView.Factory<FlyAgaricView> flyAgaricFactory,
            AIngredientView.Factory<LicoriceRootView> licoriceRootFactory,
            AIngredientView.Factory<PineConeView> pineConeFactory,
            AIngredientView.Factory<SaltView> saltFactory)
        {
            Transform ingredientTransform = null;

            switch (ingredient)
            {
                case Ingredient.Ash:
                    ingredientTransform = ashFactory.Create().transform;
                    break;

                case Ingredient.BayLeafs:
                    ingredientTransform = bayLeafsFactory.Create().transform;
                    break;

                case Ingredient.CattailCob:
                    ingredientTransform = cattailCobFactory.Create().transform;
                    break;

                case Ingredient.FlyAgaric:
                    ingredientTransform = flyAgaricFactory.Create().transform;
                    break;

                case Ingredient.LicoriceRoot:
                    ingredientTransform = licoriceRootFactory.Create().transform;
                    break;

                case Ingredient.PineCone:
                    ingredientTransform = pineConeFactory.Create().transform;
                    break;

                case Ingredient.Salt:
                    ingredientTransform = saltFactory.Create().transform;
                    break;
            }

            ingredientTransform.position = transform.position;
        }
    }
}
