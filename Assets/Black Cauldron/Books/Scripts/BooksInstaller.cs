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
            var brewingService = Container.Resolve<IBrewingService>();
            var alembicService = Container.Resolve<IAlembicService>();

            #region Level1

            Container.Bind<BasicHerbsSimpleRemediesGuide>().AsSingle();
            Container.Bind<BasicHerbsSimpleRemediesGuideViewModel>().AsSingle();
            
            var abrasionsOintment = brewingService.GetRecipe(Container.Resolve<AbrasionsOintment>());
            var beeCatalyst = brewingService.GetRecipe(Container.Resolve<BeeCatalyst>());
            var strongFertilizer = brewingService.GetRecipe(Container.Resolve<StrongFertilizer>());
            var healingPotion = brewingService.GetRecipe(Container.Resolve<HealingPotion>());
            var staminaPotion = brewingService.GetRecipe(Container.Resolve<StaminaPotion>());
            
            var basicHerbsSimpleRemediesGuideViewModel = Container.Resolve<BasicHerbsSimpleRemediesGuideViewModel>();
            basicHerbsSimpleRemediesGuideViewModel.RegisterRecipe(abrasionsOintment);
            basicHerbsSimpleRemediesGuideViewModel.RegisterRecipe(beeCatalyst);
            basicHerbsSimpleRemediesGuideViewModel.RegisterRecipe(strongFertilizer);
            basicHerbsSimpleRemediesGuideViewModel.RegisterRecipe(healingPotion);
            basicHerbsSimpleRemediesGuideViewModel.RegisterRecipe(staminaPotion);

            #endregion

            #region Level2

            Container.Bind<PracticeAlchemy>().AsSingle();
            Container.Bind<PracticeAlchemyViewModel>().AsSingle();
            
            var inspirationPotion = brewingService.GetRecipe(Container.Resolve<InspirationPotion>());
            var masteryPotion = brewingService.GetRecipe(Container.Resolve<MasteryPotion>());
            var mindfulnessPotion = brewingService.GetRecipe(Container.Resolve<MindfulnessPotion>());
            
            var practiceAlchemyViewModel = Container.Resolve<PracticeAlchemyViewModel>();
            practiceAlchemyViewModel.RegisterRecipe(inspirationPotion);
            practiceAlchemyViewModel.RegisterRecipe(masteryPotion);
            practiceAlchemyViewModel.RegisterRecipe(mindfulnessPotion);

            #endregion
            
            #region Level3
            
            Container.Bind<CombatPotions>().AsSingle();
            Container.Bind<CombatPotionsViewModel>().AsSingle();
            
            var defencePotion = brewingService.GetRecipe(Container.Resolve<DefencePotion>());
            var perseverancePotion = brewingService.GetRecipe(Container.Resolve<PerseverancePotion>());
            var strengthPotion = brewingService.GetRecipe(Container.Resolve<StrengthPotion>());
            
            var combatPotionsViewModel = Container.Resolve<CombatPotionsViewModel>();
            combatPotionsViewModel.RegisterRecipe(defencePotion);
            combatPotionsViewModel.RegisterRecipe(perseverancePotion);
            combatPotionsViewModel.RegisterRecipe(strengthPotion);
            
            #endregion
            
            #region Level4
            
            Container.Bind<TradePotions>().AsSingle();
            Container.Bind<TradePotionsViewModel>().AsSingle();
            
            var charismaPotion = brewingService.GetRecipe(Container.Resolve<CharismaPotion>());
            var deceptionProtectionPotion = brewingService.GetRecipe(Container.Resolve<DeceptionProtectionPotion>());
            var stealthPotion = brewingService.GetRecipe(Container.Resolve<StealthPotion>());
            
            var tradePotionsViewModel = Container.Resolve<TradePotionsViewModel>();
            tradePotionsViewModel.RegisterRecipe(charismaPotion);
            tradePotionsViewModel.RegisterRecipe(deceptionProtectionPotion);
            tradePotionsViewModel.RegisterRecipe(stealthPotion);
            
            #endregion
            
            #region Level5
            
            Container.Bind<SacredPotions>().AsSingle();
            Container.Bind<SacredPotionsViewModel>().AsSingle();
            
            var calmingPotion = brewingService.GetRecipe(Container.Resolve<CalmingPotion>());
            var mentalClarityPotion = brewingService.GetRecipe(Container.Resolve<MentalClarityPotion>());
            var spiritStrengtheningPotion = brewingService.GetRecipe(Container.Resolve<SpiritStrengtheningPotion>());
            
            var sacredPotionsViewModel = Container.Resolve<SacredPotionsViewModel>();
            sacredPotionsViewModel.RegisterRecipe(calmingPotion);
            sacredPotionsViewModel.RegisterRecipe(mentalClarityPotion);
            sacredPotionsViewModel.RegisterRecipe(spiritStrengtheningPotion);
            
            #endregion
            
            #region Level6
            
            Container.Bind<CourtAlchemySecrets>().AsSingle();
            Container.Bind<CourtAlchemySecretsViewModel>().AsSingle();
            
            var charmPotionTransformation = alembicService.GetTransformation(Container.Resolve<CharmPotion>());
            var memoryPotionTransformation = alembicService.GetTransformation(Container.Resolve<MemoryPotion>());
            var rejuvenationPotionTransformation = alembicService.GetTransformation(Container.Resolve<RejuvenationPotion>());
            var wisdomPotionTransformation = alembicService.GetTransformation(Container.Resolve<WisdomPotion>());
            
            var courtAlchemySecretsViewModel = Container.Resolve<CourtAlchemySecretsViewModel>();
            courtAlchemySecretsViewModel.RegisterTransformation(charmPotionTransformation);
            courtAlchemySecretsViewModel.RegisterTransformation(memoryPotionTransformation);
            courtAlchemySecretsViewModel.RegisterTransformation(rejuvenationPotionTransformation);
            courtAlchemySecretsViewModel.RegisterTransformation(wisdomPotionTransformation);
            
            #endregion
            
            #region Level7
            
            Container.Bind<GodsAlchemy>().AsSingle();
            Container.Bind<GodsAlchemyViewModel>().AsSingle();
            
            var invisibilityPotionTransformation  = alembicService.GetTransformation(Container.Resolve<InvisibilityPotion>());
            var oblivionPotionTransformation  = alembicService.GetTransformation(Container.Resolve<OblivionPotion>());
            var temporaryInvulnerabilityPotionTransformation  = alembicService.GetTransformation(Container.Resolve<TemporaryInvulnerabilityPotion>());
            
            var godsAlchemyViewModel = Container.Resolve<GodsAlchemyViewModel>();
            godsAlchemyViewModel.RegisterTransformation(invisibilityPotionTransformation);
            godsAlchemyViewModel.RegisterTransformation(oblivionPotionTransformation);
            godsAlchemyViewModel.RegisterTransformation(temporaryInvulnerabilityPotionTransformation);
            
            #endregion
        }
    }
}
