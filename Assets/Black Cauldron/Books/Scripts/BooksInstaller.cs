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

            var blueUselessPotion = brewingService.GetRecipe(Container.Resolve<BlueUselessPotion>());
            var cyanStrangePotion = brewingService.GetRecipe(Container.Resolve<CyanStrangePotion>());
            var greenSweetPotion = brewingService.GetRecipe(Container.Resolve<GreenSweetPotion>());
            var orangeSaltyPotion = brewingService.GetRecipe(Container.Resolve<OrangeSaltyPotion>());
            var pinkMysteryPotion = brewingService.GetRecipe(Container.Resolve<PinkMysteryPotion>());
            var redCommonPotion = brewingService.GetRecipe(Container.Resolve<RedCommonPotion>());
            var yellowFoulSmellingPotion = brewingService.GetRecipe(Container.Resolve<YellowFoulSmellingPotion>());

            var beginerBookViewModel = Container.Resolve<BeginerBookViewModel>();
            beginerBookViewModel.RegisterRecipe(blueUselessPotion);
            beginerBookViewModel.RegisterRecipe(cyanStrangePotion);
            beginerBookViewModel.RegisterRecipe(greenSweetPotion);
            beginerBookViewModel.RegisterRecipe(orangeSaltyPotion);
            beginerBookViewModel.RegisterRecipe(pinkMysteryPotion);
            beginerBookViewModel.RegisterRecipe(redCommonPotion);
            beginerBookViewModel.RegisterRecipe(yellowFoulSmellingPotion);
        }
    }
}
