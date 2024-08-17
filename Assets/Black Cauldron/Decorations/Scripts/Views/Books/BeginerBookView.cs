using Ginox.BlackCauldron.Decorations.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Decorations.Views.Books
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
