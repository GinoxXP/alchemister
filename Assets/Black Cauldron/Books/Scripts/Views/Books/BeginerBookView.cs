using Ginox.BlackCauldron.Books.Controllers.Books;
using Zenject;

namespace Ginox.BlackCauldron.Books.Views.Books
{
    public class BeginerBookView : ABookView
    {
        [Inject]
        private void Init(BeginerBookController viewModel)
        {
            base.Init(viewModel);
        }
    }
}
