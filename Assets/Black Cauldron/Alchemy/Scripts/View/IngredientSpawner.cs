using Ginox.BlackCauldron.Alchemy.View.Ingredients;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public class IngredientSpawner : XRBaseInteractable
    {
        [SerializeField]
        private Ingredient ingredient;

        private delegate GameObject CreateIngredient();
        CreateIngredient createIngredient;

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
            GameObject Create() => ingredient switch
            {
                Ingredient.Ash => ashFactory.Create().gameObject,
                Ingredient.BayLeafs => bayLeafsFactory.Create().gameObject,
                Ingredient.CattailCob => cattailCobFactory.Create().gameObject,
                Ingredient.FlyAgaric => flyAgaricFactory.Create().gameObject,
                Ingredient.LicoriceRoot => licoriceRootFactory.Create().gameObject,
                Ingredient.PineCone => pineConeFactory.Create().gameObject,
                Ingredient.Salt => saltFactory.Create().gameObject,
                _ => throw new System.NotImplementedException(),
            };
            createIngredient = Create;
        }

        public void Create(SelectEnterEventArgs args)
        {
            var ingredient = createIngredient.Invoke();
            ingredient.transform.position = transform.position;

            var interactable = ingredient.GetComponent<XRGrabInteractable>();
            interactionManager.SelectEnter(args.interactorObject, interactable);
        }
    }
}
