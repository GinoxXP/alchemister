using Ginox.BlackCauldron.Books.ViewModels;
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
