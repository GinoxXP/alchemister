using Ginox.BlackCauldron.Alchemy.Models;
using UnityEngine;

namespace Ginox.BlackCauldron.Trading.Services
{
    public class TradingService
    {
        private APotion[] potions;

        public APotion RequirmentPotion { get; private set; }

        public event System.Action NewTradeAvailabled;

        public TradingService(APotion[] potions)
        {
            this.potions = potions;
            CreateNewTrade();
        }

        private void CreateNewTrade()
        {
            var randomIndex = Random.Range(0, potions.Length);
            RequirmentPotion = potions[randomIndex];

            NewTradeAvailabled?.Invoke();
        }

        public void Trade(APotion potion)
        {
            CreateNewTrade();
        }
    }
}
