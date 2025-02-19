using Ginox.BlackCauldron.Alchemy.Controllers;
using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class TorchView : MonoBehaviour, IFirepitInteractable, IAlembicFirepitInteract
    {
        public void Interact(FirepitController controller)
        {
            controller.Burn();
        }

        public void Interact(AlembicController alembicController)
        {
            alembicController.TryBurn();
        }
    }
}
