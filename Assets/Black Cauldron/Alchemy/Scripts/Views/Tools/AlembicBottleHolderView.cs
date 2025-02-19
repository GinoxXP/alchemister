using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Linq;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleHolderView : MonoBehaviour
    {
        public AlembicController Controller;

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IAlembicBottleInteract>().FirstOrDefault();

            if (interactable != null)
                interactable.Subscribe(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IAlembicBottleInteract>().FirstOrDefault();

            if (interactable != null)
                interactable.Unsubscribe();
        }
    }
}
