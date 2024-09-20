using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Controllers;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Models.Potions;
using Ginox.BlackCauldron.Alchemy.Models.Ingredients;
using Zenject;
using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using UnityEngine;
using Ginox.BlackCauldron.Alchemy.Views.Ingredients;
using Ginox.BlackCauldron.Alchemy.Views;

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

    [SerializeField]
    private GameObject ash;
    [SerializeField]
    private GameObject bayLeafs;
    [SerializeField]
    private GameObject cattailCob;
    [SerializeField]
    private GameObject flyAgaric;
    [SerializeField]
    private GameObject licoriceRoot;
    [SerializeField]
    private GameObject pineCone;
    [SerializeField]
    private GameObject salt;

    public override void InstallBindings()
    {

        Container.Bind<CauldronController>().AsTransient();
        Container.Bind<BrewingService>().AsSingle();
        Container.Bind<BottleController>().AsTransient();

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

        Container.Bind<AshController>().AsTransient();
        Container.Bind<BayLeafsController>().AsTransient();
        Container.Bind<CattailCobController>().AsTransient();
        Container.Bind<FlyAgaricController>().AsTransient();
        Container.Bind<LicoriceRootController>().AsTransient();
        Container.Bind<PineConeController>().AsTransient();
        Container.Bind<SaltController>().AsTransient();

        Container.BindFactory<AshView, AIngredientView.Factory<AshView>>().FromComponentInNewPrefab(ash);
        Container.BindFactory<BayLeafsView, AIngredientView.Factory<BayLeafsView>>().FromComponentInNewPrefab(bayLeafs);
        Container.BindFactory<CattailCobView, AIngredientView.Factory<CattailCobView>>().FromComponentInNewPrefab(cattailCob);
        Container.BindFactory<FlyAgaricView, AIngredientView.Factory<FlyAgaricView>>().FromComponentInNewPrefab(flyAgaric);
        Container.BindFactory<LicoriceRootView, AIngredientView.Factory<LicoriceRootView>>().FromComponentInNewPrefab(licoriceRoot);
        Container.BindFactory<PineConeView, AIngredientView.Factory<PineConeView>>().FromComponentInNewPrefab(pineCone);
        Container.BindFactory<SaltView, AIngredientView.Factory<SaltView>>().FromComponentInNewPrefab(salt);
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