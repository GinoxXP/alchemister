using Ginox.BlackCauldron.Alchemy.Models;
using System;

namespace Ginox.BlackCauldron.Trading.Services
{
    public class TradingService
    {
        private readonly APotion[] potions;

        public APotion RequirmentPotion { get; private set; }

        public event Action NewTradeAvailabled;

        public event Action TradeDone;

        public TradingService(APotion[] potions)
        {
            this.potions = potions;
            CreateNewTrade();
        }

        private void CreateNewTrade()
        {
            var randomIndex = UnityEngine.Random.Range(0, potions.Length);
            RequirmentPotion = potions[randomIndex];

            NewTradeAvailabled?.Invoke();
        }

        public void Trade()
        {
            TradeDone?.Invoke();
            CreateNewTrade();
        }
    }
}
