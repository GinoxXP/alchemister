using UnityEngine;
using UnityEngine.Localization;

namespace Ginox.BlackCauldron.Core
{
    public class BasicDisplayableText : MonoBehaviour, IPokeIndicatorDisplay
    {
        [SerializeField]
        private LocalizedString localizedName;

        public string DisplayableText => localizedName.GetLocalizedString();
    }
}
