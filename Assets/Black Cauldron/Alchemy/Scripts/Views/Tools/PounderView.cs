using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class PounderView : MonoBehaviour, IMortarInteractable
    {
        public void Interact(MortarController controller)
        {
            controller.Perform();
        }
    }
}
