using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Ginox.BlackCauldron.Core
{
    public class PokeIndicator : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text indicator;

        private void Awake()
        {
            indicator.text = string.Empty;
        }

        public void OnHoverEntered(HoverEnterEventArgs args)
        {
            if (!args.interactableObject.transform.TryGetComponent<IPokeIndicatorDisplay>(out var pokeIndicatorDisplay))
                return;

            var displayableText = pokeIndicatorDisplay.DisplayableText;
            indicator.text = displayableText;
        }

        public void OnHoverExited(HoverExitEventArgs args)
        {
            indicator.text = string.Empty;
        }
    }
}
