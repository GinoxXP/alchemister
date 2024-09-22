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
            Container.Bind<TradingService>().FromMethod(x =>
            {
                var blueUselessPotion = Container.Resolve<BlueUselessPotion>();
                var cyanStrangePotion = Container.Resolve<CyanStrangePotion>();
                var greenSweetPotion = Container.Resolve<GreenSweetPotion>();
                var orangeSaltyPotion = Container.Resolve<OrangeSaltyPotion>();
                var pinkMysteryPotion = Container.Resolve<PinkMysteryPotion>();
                var redCommonPotion = Container.Resolve<RedCommonPotion>();
                var yellowFoulSmellingPotion = Container.Resolve<YellowFoulSmellingPotion>();

                var potions = new APotion[]
                {
                    blueUselessPotion,
                    cyanStrangePotion,
                    greenSweetPotion,
                    orangeSaltyPotion,
                    pinkMysteryPotion,
                    redCommonPotion,
                    yellowFoulSmellingPotion,
                };

                return new TradingService(potions);
            }).AsSingle();
        }
    }
}
