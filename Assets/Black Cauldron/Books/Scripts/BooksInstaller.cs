using Ginox.BlackCauldron.Alchemy.Model.Potions;
using Ginox.BlackCauldron.Alchemy.Service;
using Ginox.BlackCauldron.Books.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Books
{
    public class BooksInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BeginerBookViewModel>().AsSingle();

            var brewingService = Container.Resolve<BrewingService>();
            var beginerPotionRecipe = brewingService.GetRecipe(Container.Resolve<BeginerPotion>());

            var beginerBookViewModel = Container.Resolve<BeginerBookViewModel>();
            beginerBookViewModel.RegisterRecipe(beginerPotionRecipe);
        }
    }
}
