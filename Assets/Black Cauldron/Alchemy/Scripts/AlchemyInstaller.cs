using Ginox.BlackCauldron.Alchemy.Service;
using Ginox.BlackCauldron.Alchemy.ViewModel;
using Ginox.BlackCauldron.Alchemy.Model;
using Ginox.BlackCauldron.Alchemy.Model.Potions;
using Ginox.BlackCauldron.Alchemy.Model.Ingredients;
using Zenject;
using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using UnityEngine;

public class AlchemyInstaller : MonoInstaller
{
    [SerializeField]
    private Material beginerPotionMaterial;

    public override void InstallBindings()
    {

        Container.Bind<CauldronViewModel>().AsTransient();
        Container.Bind<BrewingService>().AsSingle();
        Container.Bind<BottleViewModel>().AsTransient();

        InstallIngredients();
        InstallPotions();
    }

    private void InstallIngredients()
    {
        Container.Bind<Ash>().AsTransient();
        Container.Bind<BayLeafs>().AsTransient();
        Container.Bind<CattailCob>().AsTransient();
        Container.Bind<FlyAgaric>().AsTransient();
        Container.Bind<LicoriceRoot>().AsTransient();
        Container.Bind<PineCone>().AsTransient();
        Container.Bind<Salt>().AsTransient();

        Container.Bind<AshViewModel>().AsTransient();
        Container.Bind<BayLeafsViewModel>().AsTransient();
        Container.Bind<CattailCobViewModel>().AsTransient();
        Container.Bind<FlyAgaricViewModel>().AsTransient();
        Container.Bind<LicoriceRootViewModel>().AsTransient();
        Container.Bind<PineConeViewModel>().AsTransient();
        Container.Bind<SaltViewModel>().AsTransient();
    }

    private void InstallPotions()
    {
        var brewingService = Container.Resolve<BrewingService>();

        var ash = Container.Resolve<Ash>();
        var bayLeafs = Container.Resolve<BayLeafs>();
        var cattailCob = Container.Resolve<CattailCob>();
        var flyAgaric = Container.Resolve<FlyAgaric>();
        var licoriceRoot = Container.Resolve<LicoriceRoot>();
        var pineCone = Container.Resolve<PineCone>();
        var salt = Container.Resolve<Salt>();

        Container.Bind<BeginerPotion>().FromMethod(x => new BeginerPotion(beginerPotionMaterial)).AsTransient();

        var beginerPotionRecipe = new Recipe(Container.Resolve<BeginerPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(salt);

        brewingService.RegisterRecipe(beginerPotionRecipe);
    }
}