using Ginox.BlackCauldron.Alchemy.Models.Potions;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Books.Models;
using Ginox.BlackCauldron.Books.ViewModels;
using Zenject;

namespace Ginox.BlackCauldron.Books
{
    public class BooksInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            #region BeginerBook

            Container.Bind<BeginerBook>().AsSingle();

            Container.Bind<BeginerBookViewModel>().AsSingle();

            var brewingService = Container.Resolve<IBrewingService>();

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

            #endregion

            #region VillageDoctorBook

            Container.Bind<VillageDoctorsRecipeBook>().AsSingle();

            Container.Bind<VillageDoctorsRecipeBookViewModel>().AsSingle();

            var coughSyrup = brewingService.GetRecipe(Container.Resolve<CoughSyrup>());
            var tinctureForRunnyNose = brewingService.GetRecipe(Container.Resolve<TinctureForRunnyNose>());
            var antiBaldnessLotion = brewingService.GetRecipe(Container.Resolve<AntiBaldnessLotion>());
            var thickHairPotion = brewingService.GetRecipe(Container.Resolve<ThickHairPotion>());
            var ointmentForRestoringLostFingers = brewingService.GetRecipe(Container.Resolve<OintmentForRestoringLostFingers>());

            var villageDoctorsRecipeBookController = Container.Resolve<VillageDoctorsRecipeBookViewModel>();
            villageDoctorsRecipeBookController.RegisterRecipe(coughSyrup);
            villageDoctorsRecipeBookController.RegisterRecipe(tinctureForRunnyNose);
            villageDoctorsRecipeBookController.RegisterRecipe(antiBaldnessLotion);
            villageDoctorsRecipeBookController.RegisterRecipe(thickHairPotion);
            villageDoctorsRecipeBookController.RegisterRecipe(ointmentForRestoringLostFingers);

            #endregion
        }
    }
}
