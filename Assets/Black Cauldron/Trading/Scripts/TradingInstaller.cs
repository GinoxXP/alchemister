using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Models.Potions;
using Ginox.BlackCauldron.Trading.Services;
using Zenject;

namespace Ginox.BlackCauldron.Trading.Trading
{
    public class TradingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TradingService>().AsSingle();
            
            var abrasionsOintment = Container.Resolve<AbrasionsOintment>();
            var beeCatalyst = Container.Resolve<BeeCatalyst>();
            var strongFertilizer = Container.Resolve<StrongFertilizer>();
            var healingPotion = Container.Resolve<HealingPotion>();
            var staminaPotion = Container.Resolve<StaminaPotion>();
            var inspirationPotion = Container.Resolve<InspirationPotion>();
            var masteryPotion = Container.Resolve<MasteryPotion>();
            var mindfulnessPotion = Container.Resolve<MindfulnessPotion>();
            var defencePotion = Container.Resolve<DefencePotion>();
            var perseverancePotion = Container.Resolve<PerseverancePotion>();
            var strengthPotion = Container.Resolve<StrengthPotion>();
            var charismaPotion = Container.Resolve<CharismaPotion>();
            var deceptionProtectionPotion = Container.Resolve<DeceptionProtectionPotion>();
            var stealthPotion = Container.Resolve<StealthPotion>();
            var calmingPotion = Container.Resolve<CalmingPotion>();
            var mentalClarityPotion = Container.Resolve<MentalClarityPotion>();
            var spiritStrengtheningPotion = Container.Resolve<SpiritStrengtheningPotion>();
            var charmPotion = Container.Resolve<CharmPotion>();
            var memoryPotion = Container.Resolve<MemoryPotion>();
            var rejuvenationPotion = Container.Resolve<RejuvenationPotion>();
            var wisdomPotion = Container.Resolve<WisdomPotion>();
            var invisibilityPotion = Container.Resolve<InvisibilityPotion>();
            var oblivionPotion = Container.Resolve<OblivionPotion>();
            var temporaryInvulnerabilityPotion = Container.Resolve<TemporaryInvulnerabilityPotion>();

            var potionsLevel1 = new APotion[] { abrasionsOintment, beeCatalyst, strongFertilizer, healingPotion, staminaPotion};
            var potionsLevel2 = new APotion[] { inspirationPotion, masteryPotion, mindfulnessPotion};
            var potionsLevel3 = new APotion[] { defencePotion, perseverancePotion, strengthPotion };
            var potionsLevel4 = new APotion[] { charismaPotion, deceptionProtectionPotion, stealthPotion };
            var potionsLevel5 = new APotion[] { calmingPotion, mentalClarityPotion, spiritStrengtheningPotion };
            var potionsLevel6 = new APotion[] { charmPotion, memoryPotion, rejuvenationPotion, wisdomPotion };
            var potionsLevel7 = new APotion[] { invisibilityPotion, oblivionPotion, temporaryInvulnerabilityPotion};
            
            var tradingService = Container.Resolve<TradingService>();
            tradingService
                .RegisterPotions(potionsLevel1)
                .RegisterPotions(potionsLevel2)
                .RegisterPotions(potionsLevel3)
                .RegisterPotions(potionsLevel4)
                .RegisterPotions(potionsLevel5)
                .RegisterPotions(potionsLevel6)
                .RegisterPotions(potionsLevel7);
            
            tradingService.Trade();
        }
    }
}
