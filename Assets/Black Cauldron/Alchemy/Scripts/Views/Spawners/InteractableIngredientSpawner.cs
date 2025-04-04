using Ginox.BlackCauldron.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.XR.Interaction.Toolkit;
using static Ginox.BlackCauldron.Alchemy.Views.IngredientSpawner;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    [RequireComponent(typeof(IngredientSpawner))]
    public class InteractableIngredientSpawner : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable, IPokeIndicatorDisplay
    {
        [SerializeField]
        private Ingredient ingredient;

        private CreateIngredient createIngredient;
        private LocalizedString localizedName;

        private string displayableText;

        public string DisplayableText
        {
            get => displayableText;
            private set => displayableText = value;
        }

        private void Start()
        {
            var ingredientSpawner = GetComponent<IngredientSpawner>();
            createIngredient = ingredientSpawner.SetIngredient(ingredient);


            localizedName = new LocalizedString("Ingredients", ingredient.ToString());
            localizedName.StringChanged += OnStringChanged;
        }

        public void Create(SelectEnterEventArgs args)
        {
            var ingredient = createIngredient.Invoke();
            ingredient.transform.position = transform.position;

            var interactable = ingredient.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            interactionManager.SelectEnter(args.interactorObject, interactable);
        }

        private void OnStringChanged(string value)
        {
            DisplayableText = value;
        }
    }
}
