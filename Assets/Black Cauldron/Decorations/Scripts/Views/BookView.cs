using Ginox.BlackCauldron.Decorations.ViewModels;
using TMPro;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Decorations.Views
{
    public class BookView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text leftContent;
        [SerializeField]
        private TMP_Text rightContent;

        private BookViewModel viewModel;

        [Inject]
        private void Init(BookViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void OnNextPage()
        {
            Destroy(gameObject);
        }

        public void OnPreviousPage()
        {
            Destroy(gameObject);
        }
    }
}
