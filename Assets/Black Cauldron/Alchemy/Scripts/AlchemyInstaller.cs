using Ginox.BlackCauldron.Alchemy.ViewModels;
using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
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
    #region PotionMaterials
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
    #endregion

    #region Ingredients
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
    #endregion

    #region MortarIngredients
    [SerializeField]
    private GameObject coalPowder;
    [SerializeField]
    private GameObject groundBayLeafs;
    [SerializeField]
    private GameObject groundCattailCob;
    [SerializeField]
    private GameObject groundFlyAgaric;
    [SerializeField]
    private GameObject groundHerringSkin;
    [SerializeField]
    private GameObject groundLicoriceRoot;
    [SerializeField]
    private GameObject groundMint;
    [SerializeField]
    private GameObject groundPineCone;
    #endregion

    [SerializeField]
    private GameObject bottle;
    [SerializeField]
    private GameObject firelog;

    public override void InstallBindings()
    {
        Container.Bind<IBrewingService>().To<BrewingService>().AsSingle();
        Container.Bind<IMortarService>().To<MortarService>().AsSingle();
        Container.Bind<IAlembicService>().To<AlembicService>().AsSingle();
        Container.BindInterfacesAndSelfTo<FirepitViewModel>().AsSingle();

        InstallTools();
        InstallIngredients();
        InstallPotions();
        InstallMortarTransformation();
        InstallAlembicTransformation();
    }

    private void InstallTools()
    {
        Container.Bind<CauldronViewModel>().AsSingle();
        Container.Bind<BottleViewModel>().AsTransient();
        Container.Bind<MortarViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<AlembicViewModel>().AsSingle();

        Container.BindFactory<BottleView, BottleView.Factory<BottleView>>().FromComponentInNewPrefab(bottle);
        Container.BindFactory<FirelogView, FirelogView.Factory<FirelogView>>().FromComponentInNewPrefab(firelog);
    }

    private void InstallIngredients()
    {
        #region Ingredients
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

        Container.Bind<AshViewModel>().AsTransient();
        Container.Bind<BayLeafsViewModel>().AsTransient();
        Container.Bind<CattailCobViewModel>().AsTransient();
        Container.Bind<FlyAgaricViewModel>().AsTransient();
        Container.Bind<LicoriceRootViewModel>().AsTransient();
        Container.Bind<PineConeViewModel>().AsTransient();
        Container.Bind<SaltViewModel>().AsTransient();
        Container.Bind<PaprikaViewModel>().AsTransient();
        Container.Bind<HerringSkinViewModel>().AsTransient();
        Container.Bind<MintViewModel>().AsTransient();
        Container.Bind<BeaverTailViewModel>().AsTransient();
        Container.Bind<CoalViewModel>().AsTransient();

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
        #endregion

        #region MortarIngredients
        Container.Bind<CoalPowder>().AsTransient();
        Container.Bind<GroundBayLeafs>().AsTransient();
        Container.Bind<GroundCattailCob>().AsTransient();
        Container.Bind<GroundFlyAgaric>().AsTransient();
        Container.Bind<GroundHerringSkin>().AsTransient();
        Container.Bind<GroundLicoriceRoot>().AsTransient();
        Container.Bind<GroundMint>().AsTransient();
        Container.Bind<GroundPineCone>().AsTransient();

        Container.Bind<CoalPowderController>().AsTransient();
        Container.Bind<GroundBayLeafsViewModel>().AsTransient();
        Container.Bind<GroundCattailCobViewModel>().AsTransient();
        Container.Bind<GroundFlyAgaricViewModel>().AsTransient();
        Container.Bind<GroundHerringSkinViewModel>().AsTransient();
        Container.Bind<GroundLicoriceRootViewModel>().AsTransient();
        Container.Bind<GroundMintViewModel>().AsTransient();
        Container.Bind<GroundPineConeViewModel>().AsTransient();

        Container.BindFactory<CoalPowderView, AIngredientView.Factory<CoalPowderView>>().FromComponentInNewPrefab(coalPowder);
        Container.BindFactory<GroundBayLeafsView, AIngredientView.Factory<GroundBayLeafsView>>().FromComponentInNewPrefab(groundBayLeafs);
        Container.BindFactory<GroundCattailCobView, AIngredientView.Factory<GroundCattailCobView>>().FromComponentInNewPrefab(groundCattailCob);
        Container.BindFactory<GroundFlyAgaricView, AIngredientView.Factory<GroundFlyAgaricView>>().FromComponentInNewPrefab(groundFlyAgaric);
        Container.BindFactory<GroundHerringSkinView, AIngredientView.Factory<GroundHerringSkinView>>().FromComponentInNewPrefab(groundHerringSkin);
        Container.BindFactory<GroundLicoriceRootView, AIngredientView.Factory<GroundLicoriceRootView>>().FromComponentInNewPrefab(groundLicoriceRoot);
        Container.BindFactory<GroundMintView, AIngredientView.Factory<GroundMintView>>().FromComponentInNewPrefab(groundMint);
        Container.BindFactory<GroundPineConeView, AIngredientView.Factory<GroundPineConeView>>().FromComponentInNewPrefab(groundPineCone);
        #endregion

    }

    private void InstallPotions()
    {
        var brewingService = Container.Resolve<IBrewingService>();

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

        #region Level1
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
        #endregion

        #region Level2
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

        brewingService.RegisterRecipe(coughSyrupRecipe);
        brewingService.RegisterRecipe(tinctureForRunnyNoseRecipe);
        brewingService.RegisterRecipe(antiBaldnessLotionRecipe);
        brewingService.RegisterRecipe(thickHairPotionRecipe);
        brewingService.RegisterRecipe(ointmentForRestoringLostFingersRecipe);
        #endregion
    }

    private void InstallMortarTransformation()
    {
        var mortarService = Container.Resolve<IMortarService>();

        #region Ingredients
        var coal = Container.Resolve<Coal>();
        var bayLeafs = Container.Resolve<BayLeafs>();
        var cattailCob = Container.Resolve<CattailCob>();
        var flyAgaric = Container.Resolve<FlyAgaric>();
        var herringSkin = Container.Resolve<HerringSkin>();
        var licoriceRoot = Container.Resolve<LicoriceRoot>();
        var mint = Container.Resolve<Mint>();
        var pineCone = Container.Resolve<PineCone>();
        #endregion

        #region MortarIngredients
        var coalPowder = Container.Resolve<CoalPowder>();
        var groundBayLeafs = Container.Resolve<GroundBayLeafs>();
        var groundCattailCob = Container.Resolve<GroundCattailCob>();
        var groundFlyAgaric = Container.Resolve<GroundFlyAgaric>();
        var groundHerringSkin = Container.Resolve<GroundHerringSkin>();
        var groundLicoriceRoot = Container.Resolve<GroundLicoriceRoot>();
        var groundMint = Container.Resolve<GroundMint>();
        var groundPineCone = Container.Resolve<GroundPineCone>();
        #endregion

        mortarService.RegisterTransformation(new IngredientTransformation(coal, coalPowder));
        mortarService.RegisterTransformation(new IngredientTransformation(bayLeafs, groundBayLeafs));
        mortarService.RegisterTransformation(new IngredientTransformation(cattailCob, groundCattailCob));
        mortarService.RegisterTransformation(new IngredientTransformation(flyAgaric, groundFlyAgaric));
        mortarService.RegisterTransformation(new IngredientTransformation(herringSkin, groundHerringSkin));
        mortarService.RegisterTransformation(new IngredientTransformation(licoriceRoot, groundLicoriceRoot));
        mortarService.RegisterTransformation(new IngredientTransformation(mint, groundMint));
        mortarService.RegisterTransformation(new IngredientTransformation(pineCone, groundPineCone));
    }

    private void InstallAlembicTransformation()
    {
        var alembicService = Container.Resolve<IAlembicService>();

        #region InputPotions
        var blueUselessPotion = Container.Resolve<BlueUselessPotion>();
        var cyanStrangePotion = Container.Resolve<CyanStrangePotion>();
        var greenSweetPotion = Container.Resolve<GreenSweetPotion>();
        var orangeSaltyPotion = Container.Resolve<OrangeSaltyPotion>();
        var yellowFoulSmellingPotion = Container.Resolve<YellowFoulSmellingPotion>();

        var coughSyrup = Container.Resolve<CoughSyrup>();
        var tinctureForRunnyNose = Container.Resolve<TinctureForRunnyNose>();
        var antiBaldnessLotion = Container.Resolve<AntiBaldnessLotion>();
        var thickHairPotion = Container.Resolve<ThickHairPotion>();
        var ointmentForRestoringLostFingers = Container.Resolve<OintmentForRestoringLostFingers>();
        #endregion

        alembicService.RegisterTransformation(new PotionTransformation(blueUselessPotion, coughSyrup));
        alembicService.RegisterTransformation(new PotionTransformation(cyanStrangePotion, tinctureForRunnyNose));
        alembicService.RegisterTransformation(new PotionTransformation(greenSweetPotion, antiBaldnessLotion));
        alembicService.RegisterTransformation(new PotionTransformation(orangeSaltyPotion, thickHairPotion));
        alembicService.RegisterTransformation(new PotionTransformation(yellowFoulSmellingPotion, ointmentForRestoringLostFingers));
    }
}