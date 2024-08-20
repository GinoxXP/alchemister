using Ginox.BlackCauldron.Books.ViewModels.Books;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Ginox.BlackCauldron.Books.Views
{
    public class ABookView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text leftContent;
        [SerializeField]
        private TMP_Text rightContent;

        private ABookViewModel viewModel;

        private int page;

        protected void Init(ABookViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void Start()
        {
            LocalizationSettings.Instance.OnSelectedLocaleChanged += OnSelectedLocaleChanged;
            RenderPage();
        }

        private void OnDestroy()
        {
            LocalizationSettings.Instance.OnSelectedLocaleChanged -= OnSelectedLocaleChanged;
        }

        private void Update()
        {
            RenderPage();
        }
        private void OnSelectedLocaleChanged(Locale obj)
        {
            RenderPage();
        }

        public void OnNextPage()
        {
            page++;
            RenderPage();
        }

        public void OnPreviousPage()
        {
            page--;
            RenderPage();
        }

        private void RenderPage()
        {
            var recipe = viewModel.Recipes[page];
            leftContent.text = recipe.Potion.ToString();

            var ingredientsKeyNames = recipe.Ingredients.Select(x => x.NameKey).ToList();

            var ingredientsNames = new List<string>();
            ingredientsKeyNames.ForEach(x =>
            {
                var localizedName = new LocalizedString("Alchemy", x);
                ingredientsNames.Add(localizedName.GetLocalizedString());
            });

            var potionRecpe = string.Empty;
            potionRecpe = string.Join(", ", ingredientsNames);

            rightContent.text = potionRecpe;
        }
    }
}
