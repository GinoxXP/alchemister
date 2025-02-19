using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicFirepitView : MonoBehaviour
    {
        private AlembicController controller;

        [Inject]
        private void Init(AlembicController Controller)
        {
            this.controller = Controller;
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IAlembicFirepitInteract>().FirstOrDefault();

            if (interactable != null)
                interactable.Interact(controller);
        }
    }
}
