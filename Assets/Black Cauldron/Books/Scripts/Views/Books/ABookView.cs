using Ginox.BlackCauldron.Books.ViewModels.Books;
using TMPro;
using UnityEngine;

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
            recipe.Ingredients.ForEach(x => rightContent.text += $"{x}\n");
        }
    }
}
