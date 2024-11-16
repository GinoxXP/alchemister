using Ginox.BlackCauldron.Alchemy.Views.Tools;
using Ginox.BlackCauldron.Trading.Services;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Trading.Views
{
    public class TradingZoneView : MonoBehaviour
    {
        private TradingService tradingServices;

        [Inject]
        private void Init(TradingService tradingServices)
        {
            this.tradingServices = tradingServices;
        }

        private void OnTriggerEnter(Collider other)
        {
            var bottle = other.GetComponentInParent<BottleView>();
            if (bottle != null)
            {
                if (bottle.BottleController.Potion.ToString() == tradingServices.RequirmentPotion.ToString())
                {
                    tradingServices.Trade();
                    Destroy(bottle.gameObject);
                }
            }
        }
    }
}
