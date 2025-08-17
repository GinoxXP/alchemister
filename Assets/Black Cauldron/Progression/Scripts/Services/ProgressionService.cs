using Ginox.BlackCauldron.Progression.Models;
using Ginox.BlackCauldron.Trading.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ginox.BlackCauldron.Progression.Services
{
    public class ProgressionService
    {
        private readonly TradingService tradingService;
        private readonly List<Level> levels = new List<Level>();

        private int xp;

        public int Level { get; private set; } = 7;

        public int XP
        {
            get => xp;
            private set
            {
                xp = value;
                XpChanged?.Invoke(xp, PassXP);
            }
        }

        public int? PassXP
        {
            get
            {
                try
                {
                    return levels[Level - 1].PassExperience;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }
        }

        public event Action<int> NewLevelAllowed;

        public event Action<int, int?> XpChanged;

        public ProgressionService(TradingService tradingService)
        {
            this.tradingService = tradingService;
            tradingService.TradeDone += OnTradeDone;
        }

        public ProgressionService AddLevel(Level level)
        {
            levels.Add(level);
            return this;
        }

        private void CheckNewLevel()
        {
            var currentLevel = levels.ElementAt(Level - 1);

            if (currentLevel.PassExperience <= XP)
            {
                XP -= currentLevel.PassExperience;
                
                if (Level + 1 >= levels.Count)
                    return;
                Level++;

                NewLevelAllowed?.Invoke(Level);
                tradingService.SetLevel(Level-1);
                CheckNewLevel();
            }
        }

        private void OnTradeDone()
        {
            XP++;
            CheckNewLevel();
        }
    }
}
