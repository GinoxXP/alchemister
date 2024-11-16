using Ginox.BlackCauldron.Alchemy.Controllers;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class TorchView : MonoBehaviour, IFirepitInteractable
    {
        public void Interact(FirepitController controller)
        {
            controller.Burn();
        }
    }
}
