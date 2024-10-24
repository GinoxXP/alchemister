using Ginox.BlackCauldron.Progression.Models;
using Ginox.BlackCauldron.Progression.Services;
using Ginox.BlackCauldron.Trading.Services;
using Zenject;

namespace Ginox.BlackCauldron.Progression
{
    public class ProgressionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProgressionService>().FromMethod(x =>
            {
                var tradingService = Container.Resolve<TradingService>();

                var progressionService = new ProgressionService(tradingService);

                progressionService
                    .AddLevel(new Level(3))
                    .AddLevel(new Level(5));

                return progressionService;
            }).AsSingle();
        }
    }
}