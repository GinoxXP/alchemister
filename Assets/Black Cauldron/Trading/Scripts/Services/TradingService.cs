using Ginox.BlackCauldron.Alchemy.Models;
using System;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Trading.Services
{
    public class TradingService
    {
        private readonly List<APotion[]> potions = new();

        private int level;
        
        public APotion RequirmentPotion { get; private set; }

        public event Action NewTradeAvailabled;

        public event Action TradeDone;

        public TradingService RegisterPotions(APotion[] potions)
        {
            this.potions.Add(potions);
            return this;
        }

        public void SetLevel(int level)
            => this.level = level;
        
        public void Trade()
        {
            TradeDone?.Invoke();
            CreateNewTrade();
        }

        private void CreateNewTrade()
        {
            var randomIndex = UnityEngine.Random.Range(0, potions[level].Length);
            RequirmentPotion = potions[level][randomIndex];

            NewTradeAvailabled?.Invoke();
        }
    }
}
