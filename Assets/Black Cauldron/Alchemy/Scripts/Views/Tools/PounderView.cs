using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Collections;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class PounderView : MonoBehaviour, IMortarInteractable
    {
        private const float INTERACT_DELAY = 1f;

        private bool isCanInteract = true;
        private IEnumerator waitAfterInteract;

        public void Interact(MortarController controller)
        {
            if (!isCanInteract)
                return;

            controller.Perform();

            waitAfterInteract = WaitAfterInteract();
            StartCoroutine(waitAfterInteract);
        }

        private IEnumerator WaitAfterInteract()
        {
            isCanInteract = false;

            yield return new WaitForSeconds(INTERACT_DELAY);

            isCanInteract = true;
        }
    }
}
