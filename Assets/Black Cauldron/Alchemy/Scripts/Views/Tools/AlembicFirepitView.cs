using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicFirepitView : MonoBehaviour
    {
        private AlembicViewModel controller;

        [Inject]
        private void Init(AlembicViewModel Controller)
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
