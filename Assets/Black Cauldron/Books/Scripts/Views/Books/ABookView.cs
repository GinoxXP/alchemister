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

        protected void Init(ABookViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void OnNextPage()
        {
        }

        public void OnPreviousPage()
        {
        }
    }
}
