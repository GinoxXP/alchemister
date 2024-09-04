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
    private Material blueUselessPotionMaterial;
    [SerializeField]
    private Material cyanStrangePotionMaterial;
    [SerializeField]
    private Material greenSweetPotionMaterial;
    [SerializeField]
    private Material orangeSaltyPotionMaterial;
    [SerializeField]
    private Material pinkMysteryPotionMaterial;
    [SerializeField]
    private Material redCommonPotionMaterial;
    [SerializeField]
    private Material yellowFoulSmellingPotionMaterial;

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

        Container.Bind<BlueUselessPotion>().FromMethod(x => new BlueUselessPotion(blueUselessPotionMaterial)).AsTransient();
        Container.Bind<CyanStrangePotion>().FromMethod(x => new CyanStrangePotion(cyanStrangePotionMaterial)).AsTransient();
        Container.Bind<GreenSweetPotion>().FromMethod(x => new GreenSweetPotion(greenSweetPotionMaterial)).AsTransient();
        Container.Bind<OrangeSaltyPotion>().FromMethod(x => new OrangeSaltyPotion(orangeSaltyPotionMaterial)).AsTransient();
        Container.Bind<PinkMysteryPotion>().FromMethod(x => new PinkMysteryPotion(pinkMysteryPotionMaterial)).AsTransient();
        Container.Bind<RedCommonPotion>().FromMethod(x => new RedCommonPotion(redCommonPotionMaterial)).AsTransient();
        Container.Bind<YellowFoulSmellingPotion>().FromMethod(x => new YellowFoulSmellingPotion(yellowFoulSmellingPotionMaterial)).AsTransient();

        var blueUselessPotionRecipe = new Recipe(Container.Resolve<BlueUselessPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(cattailCob);
        var cyanStrangePotionRecipe = new Recipe(Container.Resolve<CyanStrangePotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(flyAgaric);
        var greenSweetPotionRecipe = new Recipe(Container.Resolve<GreenSweetPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(licoriceRoot);
        var orangeSaltyPotionRecipe = new Recipe(Container.Resolve<OrangeSaltyPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(pineCone);
        var pinkMysteryPotionRecipe = new Recipe(Container.Resolve<PinkMysteryPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(salt);
        var redCommonPotionRecipe = new Recipe(Container.Resolve<RedCommonPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(ash);
        var yellowFoulSmellingPotionRecipe = new Recipe(Container.Resolve<YellowFoulSmellingPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(bayLeafs);

        brewingService.RegisterRecipe(blueUselessPotionRecipe);
        brewingService.RegisterRecipe(cyanStrangePotionRecipe);
        brewingService.RegisterRecipe(greenSweetPotionRecipe);
        brewingService.RegisterRecipe(orangeSaltyPotionRecipe);
        brewingService.RegisterRecipe(pinkMysteryPotionRecipe);
        brewingService.RegisterRecipe(redCommonPotionRecipe);
        brewingService.RegisterRecipe(yellowFoulSmellingPotionRecipe);
    }
}