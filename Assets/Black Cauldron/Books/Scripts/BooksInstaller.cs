using Ginox.BlackCauldron.Books.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Books
{
    public class BooksInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BeginerBookViewModel>().AsTransient();
        }
    }
}
