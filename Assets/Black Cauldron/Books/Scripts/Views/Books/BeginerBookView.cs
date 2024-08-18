using Ginox.BlackCauldron.Books.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Books.Views.Books
{
    public class BeginerBookView : ABookView
    {
        [Inject]
        private void Init(BeginerBookViewModel viewModel)
        {
            base.Init(viewModel);
        }
    }
}
