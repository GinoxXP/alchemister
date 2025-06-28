using Ginox.BlackCauldron.Alchemy.ViewModels;
using Ginox.BlackCauldron.Alchemy.ViewModels.Ingredients;
using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Models.Potions;
using Ginox.BlackCauldron.Alchemy.Models.Ingredients;
using Ginox.BlackCauldron.Alchemy.Services;
using Ginox.BlackCauldron.Alchemy.Views.Ingredients;
using Ginox.BlackCauldron.Alchemy.Views.Tools;
using UnityEngine;
using Zenject;
using Ginox.BlackCauldron.Alchemy.Models.Tools;

public class AlchemyInstaller : MonoInstaller
{
    #region PotionMaterials

    #region Level1
    [SerializeField]
    private Material abrassionOintmentMaterial;
    [SerializeField]
    private Material beeCatalystMaterial;
    [SerializeField]
    private Material fertilizerMaterial;
    [SerializeField]
    private Material healingPotionMaterial;
    [SerializeField]
    private Material staminaPotionMaterial;
    #endregion
    
    #region Level2
    [SerializeField]
    private Material inspirationPotionMaterial;
    [SerializeField]
    private Material masteryPotionMaterial;
    [SerializeField]
    private Material mindfullnessPotionMaterial;
    #endregion
    
    #region Level3
    [SerializeField]
    private Material defencePotionMaterial;
    [SerializeField]
    private Material perseverancePotionMaterial;
    [SerializeField]
    private Material strengthPotionMaterial;
    #endregion
    
    #region Level4
    [SerializeField]
    private Material charismaPotionMaterial;
    [SerializeField]
    private Material deceptionProtectionPotionMaterial;
    [SerializeField]
    private Material stealthPotionMaterial;
    #endregion
    
    #region Level5
    [SerializeField]
    private Material calmingPotionMaterial;
    [SerializeField]
    private Material mentalClarityPotionMaterial;
    [SerializeField]
    private Material spiritStrengthPotionMaterial;
    #endregion
    
    #region Level6
    [SerializeField]
    private Material charmPotionMaterial;
    [SerializeField]
    private Material memoryPotionMaterial;
    [SerializeField]
    private Material rejuvenationPotionMaterial;
    [SerializeField]
    private Material wisdomPotionMaterial;
    #endregion
    
    #region Level7
    [SerializeField]
    private Material invisibilityPotionMaterial;
    [SerializeField]
    private Material oblivionPotionMaterial; 
    [SerializeField]
    private Material temporaryInvulnerabilityPotionMaterial;
    #endregion
    
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

        InstallTools();
        InstallIngredients();
        InstallPotions();
        InstallMortarTransformation();
        InstallAlembicTransformation();
    }

    private void InstallTools()
    {
        Container.Bind<Firepit>().AsTransient();
        Container.Bind<Cauldron>().AsTransient();
        Container.Bind<Bottle>().AsTransient();
        Container.Bind<Mortar>().AsTransient();
        Container.Bind<Alembic>().AsTransient();

        Container.BindInterfacesAndSelfTo<FirepitViewModel>().AsSingle();
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

        #region Level1
        var ash = Container.Resolve<Ash>();
        var bayLeafs = Container.Resolve<BayLeafs>();
        var cattailCob = Container.Resolve<CattailCob>();
        #endregion
        
        #region Level2
        var pineCone = Container.Resolve<PineCone>();
        var salt = Container.Resolve<Salt>();
        var paprika = Container.Resolve<Paprika>();
        #endregion
        
        #region Level3
        var herringSkin = Container.Resolve<HerringSkin>();
        var flyAgaric = Container.Resolve<FlyAgaric>();
        var licoriceRoot = Container.Resolve<LicoriceRoot>();
        #endregion
        
        #region Level4
        var groundBayLeafs = Container.Resolve<GroundBayLeafs>();
        var groundCattailCob = Container.Resolve<GroundCattailCob>();
        var groundFlyAgaric = Container.Resolve<GroundFlyAgaric>();
        var groundLicoriceRoot = Container.Resolve<GroundLicoriceRoot>();
        var groundPineCone = Container.Resolve<GroundPineCone>();
        var groundHerringSkin = Container.Resolve<GroundHerringSkin>();
        #endregion
        
        #region Level5
        var mint = Container.Resolve<Mint>();
        var beaverTail = Container.Resolve<BeaverTail>();
        var coal = Container.Resolve<Coal>();
        var groundMint = Container.Resolve<GroundMint>();
        var coalPowder = Container.Resolve<CoalPowder>();
        #endregion
        
        #region Level1
        Container.Bind<AbrasionsOintment>().FromMethod(x => new AbrasionsOintment(abrassionOintmentMaterial)).AsTransient();
        Container.Bind<BeeCatalyst>().FromMethod(x => new BeeCatalyst(beeCatalystMaterial)).AsTransient();
        Container.Bind<StrongFertilizer>().FromMethod(x => new StrongFertilizer(fertilizerMaterial)).AsTransient();
        Container.Bind<HealingPotion>().FromMethod(x => new HealingPotion(healingPotionMaterial)).AsTransient();
        Container.Bind<StaminaPotion>().FromMethod(x => new StaminaPotion(staminaPotionMaterial)).AsTransient();
        
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<AbrasionsOintment>())
                .RegisterIngredient(ash)
                .RegisterIngredient(bayLeafs));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<BeeCatalyst>())
                .RegisterIngredient(ash)
                .RegisterIngredient(cattailCob));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<StrongFertilizer>())
                .RegisterIngredient(ash)
                .RegisterIngredient(ash));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<HealingPotion>())
                .RegisterIngredient(bayLeafs)
                .RegisterIngredient(cattailCob));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<StaminaPotion>())
                .RegisterIngredient(cattailCob)
                .RegisterIngredient(cattailCob));
        #endregion
        
        #region Level2
        Container.Bind<InspirationPotion>().FromMethod(x => new InspirationPotion(inspirationPotionMaterial)).AsTransient();
        Container.Bind<MasteryPotion>().FromMethod(x => new MasteryPotion(masteryPotionMaterial)).AsTransient();
        Container.Bind<MindfulnessPotion>().FromMethod(x => new MindfulnessPotion(mindfullnessPotionMaterial)).AsTransient();
        
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<InspirationPotion>())
                .RegisterIngredient(pineCone)
                .RegisterIngredient(ash)
                .RegisterIngredient(cattailCob));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<MasteryPotion>())
                .RegisterIngredient(salt)
                .RegisterIngredient(paprika)
                .RegisterIngredient(salt));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<MindfulnessPotion>())
                .RegisterIngredient(paprika)
                .RegisterIngredient(salt)
                .RegisterIngredient(cattailCob));
        #endregion
        
        #region Level3
        Container.Bind<DefencePotion>().FromMethod(x => new DefencePotion(defencePotionMaterial)).AsTransient();
        Container.Bind<PerseverancePotion>().FromMethod(x => new PerseverancePotion(perseverancePotionMaterial)).AsTransient();
        Container.Bind<StrengthPotion>().FromMethod(x => new StrengthPotion(strengthPotionMaterial)).AsTransient();
        
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<DefencePotion>())
                .RegisterIngredient(herringSkin)
                .RegisterIngredient(ash)
                .RegisterIngredient(paprika)
                .RegisterIngredient(salt));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<PerseverancePotion>())
                .RegisterIngredient(flyAgaric)
                .RegisterIngredient(salt)
                .RegisterIngredient(licoriceRoot)
                .RegisterIngredient(cattailCob));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<StrengthPotion>())
                .RegisterIngredient(flyAgaric)
                .RegisterIngredient(ash)
                .RegisterIngredient(licoriceRoot)
                .RegisterIngredient(paprika));
        #endregion
        
        #region Level4
        Container.Bind<CharismaPotion>().FromMethod(x => new CharismaPotion(charismaPotionMaterial)).AsTransient();
        Container.Bind<DeceptionProtectionPotion>().FromMethod(x => new DeceptionProtectionPotion(deceptionProtectionPotionMaterial)).AsTransient();
        Container.Bind<StealthPotion>().FromMethod(x => new StealthPotion(stealthPotionMaterial)).AsTransient();
        
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<CharismaPotion>())
                .RegisterIngredient(groundBayLeafs)
                .RegisterIngredient(ash)
                .RegisterIngredient(licoriceRoot)
                .RegisterIngredient(salt)
                .RegisterIngredient(groundCattailCob)
                .RegisterIngredient(flyAgaric)
                .RegisterIngredient(paprika));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<DeceptionProtectionPotion>())
                .RegisterIngredient(groundFlyAgaric)
                .RegisterIngredient(groundHerringSkin)
                .RegisterIngredient(groundLicoriceRoot)
                .RegisterIngredient(cattailCob)
                .RegisterIngredient(salt)
                .RegisterIngredient(pineCone)
                .RegisterIngredient(groundBayLeafs));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<StealthPotion>())
                .RegisterIngredient(groundPineCone)
                .RegisterIngredient(paprika)
                .RegisterIngredient(licoriceRoot)
                .RegisterIngredient(ash)
                .RegisterIngredient(flyAgaric)
                .RegisterIngredient(herringSkin)
                .RegisterIngredient(salt));
        #endregion
        
        #region Level5
        Container.Bind<CalmingPotion>().FromMethod(x => new CalmingPotion(calmingPotionMaterial)).AsTransient();
        Container.Bind<MentalClarityPotion>().FromMethod(x => new MentalClarityPotion(mentalClarityPotionMaterial)).AsTransient();
        Container.Bind<SpiritStrengtheningPotion>().FromMethod(x => new SpiritStrengtheningPotion(spiritStrengthPotionMaterial)).AsTransient();
        
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<CalmingPotion>())
                .RegisterIngredient(mint)
                .RegisterIngredient(flyAgaric)
                .RegisterIngredient(groundBayLeafs)
                .RegisterIngredient(coal)
                .RegisterIngredient(coalPowder)
                .RegisterIngredient(pineCone)
                .RegisterIngredient(ash)
                .RegisterIngredient(cattailCob)
                .RegisterIngredient(paprika));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<MentalClarityPotion>())
                .RegisterIngredient(beaverTail)
                .RegisterIngredient(coal)
                .RegisterIngredient(pineCone)
                .RegisterIngredient(mint)
                .RegisterIngredient(groundBayLeafs)
                .RegisterIngredient(groundLicoriceRoot)
                .RegisterIngredient(salt)
                .RegisterIngredient(paprika)
                .RegisterIngredient(herringSkin));
        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<SpiritStrengtheningPotion>())
                .RegisterIngredient(groundMint)
                .RegisterIngredient(groundBayLeafs)
                .RegisterIngredient(herringSkin)
                .RegisterIngredient(salt)
                .RegisterIngredient(ash)
                .RegisterIngredient(beaverTail)
                .RegisterIngredient(groundCattailCob)
                .RegisterIngredient(pineCone)
                .RegisterIngredient(groundFlyAgaric));
        #endregion
        
        #region Level6
        Container.Bind<CharmPotion>().FromMethod(x => new CharmPotion(charmPotionMaterial)).AsTransient();
        Container.Bind<MemoryPotion>().FromMethod(x => new MemoryPotion(memoryPotionMaterial)).AsTransient();
        Container.Bind<RejuvenationPotion>().FromMethod(x => new RejuvenationPotion(rejuvenationPotionMaterial)).AsTransient();
        Container.Bind<WisdomPotion>().FromMethod(x => new WisdomPotion(wisdomPotionMaterial)).AsTransient();
        #endregion
        
        #region Level7
        Container.Bind<InvisibilityPotion>().FromMethod(x => new InvisibilityPotion(invisibilityPotionMaterial)).AsTransient();
        Container.Bind<OblivionPotion>().FromMethod(x => new OblivionPotion(oblivionPotionMaterial)).AsTransient();
        Container.Bind<TemporaryInvulnerabilityPotion>().FromMethod(x => new TemporaryInvulnerabilityPotion(temporaryInvulnerabilityPotionMaterial)).AsTransient();
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

        var spiritStrengtheningPotion = Container.Resolve<SpiritStrengtheningPotion>();
        var mentalClarityPotion = Container.Resolve<MentalClarityPotion>();
        var stealthPotion = Container.Resolve<StealthPotion>();
        var healingPotion = Container.Resolve<HealingPotion>();
        
        var charmPotion = Container.Resolve<CharmPotion>();
        var memoryPotion = Container.Resolve<MemoryPotion>();
        var rejuvenationPotion = Container.Resolve<RejuvenationPotion>();
        var wisdomPotion = Container.Resolve<WisdomPotion>();
        
        var invisibilityPotion = Container.Resolve<InvisibilityPotion>();
        var oblivionPotion = Container.Resolve<OblivionPotion>();
        var temporaryInvulnerabilityPotion = Container.Resolve<TemporaryInvulnerabilityPotion>();

        alembicService.RegisterTransformation(new PotionTransformation(mentalClarityPotion, charmPotion));
        alembicService.RegisterTransformation(new PotionTransformation(spiritStrengtheningPotion, memoryPotion));
        alembicService.RegisterTransformation(new PotionTransformation(healingPotion, rejuvenationPotion));
        alembicService.RegisterTransformation(new PotionTransformation(memoryPotion, wisdomPotion));
        
        alembicService.RegisterTransformation(new PotionTransformation(stealthPotion, invisibilityPotion));
        alembicService.RegisterTransformation(new PotionTransformation(wisdomPotion, oblivionPotion));
        alembicService.RegisterTransformation(new PotionTransformation(rejuvenationPotion, temporaryInvulnerabilityPotion));
    }
}