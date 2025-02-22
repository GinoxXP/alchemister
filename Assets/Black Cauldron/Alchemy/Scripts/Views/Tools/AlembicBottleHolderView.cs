using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleHolderView : MonoBehaviour
    {
        private AlembicController controller;

        [Inject]
        private void Inject(AlembicController controller)
        {
            this.controller = controller;
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IAlembicBottleInteract>().FirstOrDefault();

            if (interactable == null)
                return;

            interactable.PlugIn(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IAlembicBottleInteract>().FirstOrDefault();

            if (interactable == null)
                return;

            interactable.PlugOut();
        }
    }
}
