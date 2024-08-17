using Ginox.BlackCauldron.Decorations.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Decorations
{
    public class DecorationsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BeginerBookViewModel>().AsTransient();
        }
    }
}
