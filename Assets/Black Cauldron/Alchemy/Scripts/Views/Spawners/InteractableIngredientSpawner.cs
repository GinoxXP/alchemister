using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Ginox.BlackCauldron.Alchemy.Views.IngredientSpawner;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    [RequireComponent(typeof(IngredientSpawner))]
    public class InteractableIngredientSpawner : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
    {
        [SerializeField]
        private Ingredient ingredient;

        private CreateIngredient createIngredient;

        private void Start()
        {
            var ingredientSpawner = GetComponent<IngredientSpawner>();
            createIngredient = ingredientSpawner.SetIngredient(ingredient);
        }

        public void Create(SelectEnterEventArgs args)
        {
            var ingredient = createIngredient.Invoke();
            ingredient.transform.position = transform.position;

            var interactable = ingredient.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            interactionManager.SelectEnter(args.interactorObject, interactable);
        }
    }
}
