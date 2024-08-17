using Ginox.BlackCauldron.Decorations.ViewModels;
using Ginox.BlackCauldron.Decorations.Views;
using Zenject;

namespace Ginox.BlackCauldron.Decorations
{
    public class DecorationsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BookViewModel>().AsTransient();
            Container.Bind<BookView>().AsTransient();
        }
    }
}
