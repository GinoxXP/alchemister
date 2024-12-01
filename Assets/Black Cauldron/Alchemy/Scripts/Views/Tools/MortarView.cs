using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class MortarView : MonoBehaviour
    {
        [SerializeField]
        private GameObject pile;

        private MortarController controller;

        [Inject]
        private void Init(MortarController controller)
        {
            this.controller = controller;
        }

        private void Start ()
        {
            pile.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IMortarInteractable>().FirstOrDefault();

            interactable?.Interact(controller);
        }
    }
}
