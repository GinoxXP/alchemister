using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Trading.Services;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Zenject;

namespace Ginox.BlackCauldron.Trading.Views
{
    public class TradeDisplayView : MonoBehaviour
    {
        private TMP_Text text;
        private TradingService tradingServices;

        [Inject]
        private void Init(TradingService tradingServices)
        {
            this.tradingServices = tradingServices;
        }

        private void Start()
        {
            text = GetComponent<TMP_Text>();
            tradingServices.NewTradeAvailabled += OnNewTradeAvailabled;
            LocalizationSettings.Instance.OnSelectedLocaleChanged += OnSelectedLocaleChanged;

            Render();
        }

        private void OnDestroy()
        {
            tradingServices.NewTradeAvailabled -= OnNewTradeAvailabled;
            LocalizationSettings.Instance.OnSelectedLocaleChanged -= OnSelectedLocaleChanged;
        }

        private void OnNewTradeAvailabled()
        {
            Render();
        }

        private void OnSelectedLocaleChanged(Locale obj)
        {
            Render();
        }

        private void Render()
        {
            var potionNameKey = tradingServices.RequirmentPotion.NameKey;
            var potionLocalizedName = new LocalizedString("Potions", potionNameKey);
            text.text = potionLocalizedName.GetLocalizedString();
        }
    }
}
