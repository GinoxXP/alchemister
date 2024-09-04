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
        [SerializeField]
        private TMP_Text pageIndex;

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
            var potionNameKey = recipe.Potion.NameKey;

            var potionLocalizedName = new LocalizedString("Potions", potionNameKey);
            leftContent.text = potionLocalizedName.GetLocalizedString();

            var ingredientsKeyNames = recipe.Ingredients.Select(x => x.NameKey).ToList();

            var ingredientsNames = new List<string>();
            for (int i = 0; i < ingredientsKeyNames.Count; i++)
            {
                var localizedName = new LocalizedString("Ingredients", ingredientsKeyNames[i]);
                var localizedString = localizedName.GetLocalizedString();

                if (i != 0)
                    localizedString = localizedString[..1].ToLowerInvariant() + localizedString[1..];

                ingredientsNames.Add(localizedString);
            }

            var potionRecpe = string.Empty;
            potionRecpe = string.Join(", ", ingredientsNames);

            rightContent.text = potionRecpe;

            pageIndex.text = $"{page + 1}";
        }
    }
}
