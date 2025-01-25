using Ginox.BlackCauldron.Alchemy.Controllers;
using Ginox.BlackCauldron.Alchemy.Controllers.Ingredients;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Models.Potions;
using Ginox.BlackCauldron.Alchemy.Models.Ingredients;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views;
using Ginox.BlackCauldron.Alchemy.Views.Ingredients;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using UnityEngine;
using Zenject;

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
    private Material coughSyrupMaterial;
    [SerializeField]
    private Material tinctureForRunnyNoseMaterial;
    [SerializeField]
    private Material antiBaldnessLotionMaterial;
    [SerializeField]
    private Material thickHairPotionMaterial;
    [SerializeField]
    private Material ointmentForRestoringLostFingersMaterial;

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
    [SerializeField]
    private GameObject paprika;
    [SerializeField]
    private GameObject herringSkin;
    [SerializeField]
    private GameObject mint;
    [SerializeField]
    private GameObject beaverTail;
    [SerializeField]
    private GameObject coal;
    [SerializeField]
    private GameObject coalPowder;

    [SerializeField]
    private GameObject bottle;
    [SerializeField]
    private GameObject firelog;

    public override void InstallBindings()
    {
        Container.Bind<CauldronController>().AsSingle();
        Container.Bind<BrewingService>().AsSingle();
        Container.Bind<MortarService>().AsSingle();
        Container.BindInterfacesAndSelfTo<FirepitController>().AsSingle();

        InstallTools();
        InstallIngredients();
        InstallPotions();
        InstallMortarTransformation();
    }

    private void InstallTools()
    {
        Container.Bind<BottleController>().AsTransient();
        Container.Bind<MortarController>().AsTransient();

        Container.BindFactory<BottleView, BottleView.Factory<BottleView>>().FromComponentInNewPrefab(bottle);
        Container.BindFactory<FirelogView, FirelogView.Factory<FirelogView>>().FromComponentInNewPrefab(firelog);
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
        Container.Bind<Paprika>().AsTransient();
        Container.Bind<HerringSkin>().AsTransient();
        Container.Bind<Mint>().AsTransient();
        Container.Bind<BeaverTail>().AsTransient();
        Container.Bind<Coal>().AsTransient();
        Container.Bind<CoalPowder>().AsTransient();

        Container.Bind<AshController>().AsTransient();
        Container.Bind<BayLeafsController>().AsTransient();
        Container.Bind<CattailCobController>().AsTransient();
        Container.Bind<FlyAgaricController>().AsTransient();
        Container.Bind<LicoriceRootController>().AsTransient();
        Container.Bind<PineConeController>().AsTransient();
        Container.Bind<SaltController>().AsTransient();
        Container.Bind<PaprikaController>().AsTransient();
        Container.Bind<HerringSkinController>().AsTransient();
        Container.Bind<MintController>().AsTransient();
        Container.Bind<BeaverTailController>().AsTransient();
        Container.Bind<CoalController>().AsTransient();
        Container.Bind<CoalPowderController>().AsTransient();

        Container.BindFactory<AshView, AIngredientView.Factory<AshView>>().FromComponentInNewPrefab(ash);
        Container.BindFactory<BayLeafsView, AIngredientView.Factory<BayLeafsView>>().FromComponentInNewPrefab(bayLeafs);
        Container.BindFactory<CattailCobView, AIngredientView.Factory<CattailCobView>>().FromComponentInNewPrefab(cattailCob);
        Container.BindFactory<FlyAgaricView, AIngredientView.Factory<FlyAgaricView>>().FromComponentInNewPrefab(flyAgaric);
        Container.BindFactory<LicoriceRootView, AIngredientView.Factory<LicoriceRootView>>().FromComponentInNewPrefab(licoriceRoot);
        Container.BindFactory<PineConeView, AIngredientView.Factory<PineConeView>>().FromComponentInNewPrefab(pineCone);
        Container.BindFactory<SaltView, AIngredientView.Factory<SaltView>>().FromComponentInNewPrefab(salt);
        Container.BindFactory<PaprikaView, AIngredientView.Factory<PaprikaView>>().FromComponentInNewPrefab(paprika);
        Container.BindFactory<HerringSkinView, AIngredientView.Factory<HerringSkinView>>().FromComponentInNewPrefab(herringSkin);
        Container.BindFactory<MintView, AIngredientView.Factory<MintView>>().FromComponentInNewPrefab(mint);
        Container.BindFactory<BeaverTailView, AIngredientView.Factory<BeaverTailView>>().FromComponentInNewPrefab(beaverTail);
        Container.BindFactory<CoalView, AIngredientView.Factory<CoalView>>().FromComponentInNewPrefab(coal);
        Container.BindFactory<CoalPowderView, AIngredientView.Factory<CoalPowderView>>().FromComponentInNewPrefab(coalPowder);
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

        var paprika = Container.Resolve<Paprika>();
        var herringSkin = Container.Resolve<HerringSkin>();
        var mint = Container.Resolve<Mint>();
        var beaverTail = Container.Resolve<BeaverTail>();
        var coal = Container.Resolve<Coal>();

        Container.Bind<BlueUselessPotion>().FromMethod(x => new BlueUselessPotion(blueUselessPotionMaterial)).AsTransient();
        Container.Bind<CyanStrangePotion>().FromMethod(x => new CyanStrangePotion(cyanStrangePotionMaterial)).AsTransient();
        Container.Bind<GreenSweetPotion>().FromMethod(x => new GreenSweetPotion(greenSweetPotionMaterial)).AsTransient();
        Container.Bind<OrangeSaltyPotion>().FromMethod(x => new OrangeSaltyPotion(orangeSaltyPotionMaterial)).AsTransient();
        Container.Bind<PinkMysteryPotion>().FromMethod(x => new PinkMysteryPotion(pinkMysteryPotionMaterial)).AsTransient();
        Container.Bind<RedCommonPotion>().FromMethod(x => new RedCommonPotion(redCommonPotionMaterial)).AsTransient();
        Container.Bind<YellowFoulSmellingPotion>().FromMethod(x => new YellowFoulSmellingPotion(yellowFoulSmellingPotionMaterial)).AsTransient();

        Container.Bind<CoughSyrup>().FromMethod(x => new CoughSyrup(coughSyrupMaterial)).AsTransient();
        Container.Bind<TinctureForRunnyNose>().FromMethod(x => new TinctureForRunnyNose(tinctureForRunnyNoseMaterial)).AsTransient();
        Container.Bind<AntiBaldnessLotion>().FromMethod(x => new AntiBaldnessLotion(antiBaldnessLotionMaterial)).AsTransient();
        Container.Bind<ThickHairPotion>().FromMethod(x => new ThickHairPotion(thickHairPotionMaterial)).AsTransient();
        Container.Bind<OintmentForRestoringLostFingers>().FromMethod(x => new OintmentForRestoringLostFingers(ointmentForRestoringLostFingersMaterial)).AsTransient();

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

        var coughSyrupRecipe = new Recipe(Container.Resolve<CoughSyrup>())
            .RegisterIngredient(ash)
            .RegisterIngredient(coal)
            .RegisterIngredient(mint)
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(salt);
        var tinctureForRunnyNoseRecipe = new Recipe(Container.Resolve<TinctureForRunnyNose>())
            .RegisterIngredient(coal)
            .RegisterIngredient(ash)
            .RegisterIngredient(salt)
            .RegisterIngredient(flyAgaric)
            .RegisterIngredient(licoriceRoot);
        var antiBaldnessLotionRecipe = new Recipe(Container.Resolve<AntiBaldnessLotion>())
            .RegisterIngredient(bayLeafs)
            .RegisterIngredient(coal)
            .RegisterIngredient(pineCone)
            .RegisterIngredient(beaverTail)
            .RegisterIngredient(cattailCob);
        var thickHairPotionRecipe = new Recipe(Container.Resolve<ThickHairPotion>())
            .RegisterIngredient(coal)
            .RegisterIngredient(ash)
            .RegisterIngredient(flyAgaric)
            .RegisterIngredient(ash)
            .RegisterIngredient(coal);
        var ointmentForRestoringLostFingersRecipe = new Recipe(Container.Resolve<OintmentForRestoringLostFingers>())
            .RegisterIngredient(flyAgaric)
            .RegisterIngredient(coal)
            .RegisterIngredient(beaverTail)
            .RegisterIngredient(licoriceRoot)
            .RegisterIngredient(bayLeafs);

        brewingService.RegisterRecipe(blueUselessPotionRecipe);
        brewingService.RegisterRecipe(cyanStrangePotionRecipe);
        brewingService.RegisterRecipe(greenSweetPotionRecipe);
        brewingService.RegisterRecipe(orangeSaltyPotionRecipe);
        brewingService.RegisterRecipe(pinkMysteryPotionRecipe);
        brewingService.RegisterRecipe(redCommonPotionRecipe);
        brewingService.RegisterRecipe(yellowFoulSmellingPotionRecipe);

        brewingService.RegisterRecipe(coughSyrupRecipe);
        brewingService.RegisterRecipe(tinctureForRunnyNoseRecipe);
        brewingService.RegisterRecipe(antiBaldnessLotionRecipe);
        brewingService.RegisterRecipe(thickHairPotionRecipe);
        brewingService.RegisterRecipe(ointmentForRestoringLostFingersRecipe);
    }

    private void InstallMortarTransformation()
    {
        var mortarService = Container.Resolve<MortarService>();

        var coal = Container.Resolve<Coal>();

        var coalPowder = Container.Resolve<CoalPowder>();

        mortarService.RegisterTransformation(new IngredientTransformation(coal, coalPowder));
    }
}