using Ginox.BlackCauldron.Alchemy.ViewModels;
using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class TorchView : MonoBehaviour, IFirepitInteractable, IAlembicFirepitInteract
    {
        public void Interact(FirepitViewModel controller)
        {
            controller.Burn();
        }

        public void Interact(AlembicViewModel alembicController)
        {
            alembicController.TryBurn();
        }
    }
}
