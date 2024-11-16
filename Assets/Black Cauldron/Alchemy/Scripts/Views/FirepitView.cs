using Ginox.BlackCauldron.Alchemy.Controllers;
using Ginox.BlackCauldron.Alchemy.Views;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy
{
    public class FirepitView : MonoBehaviour
    {
        [SerializeField]
        private new GameObject light;

        public FirepitController Controller { get; private set; }


        [Inject]
        private void Init(FirepitController firepitController)
        {
            Controller = firepitController;
        }

        private void Start()
        {
            Controller.BurnChanged += OnBurnChanged;

            OnBurnChanged(Controller.IsBurn);
        }

        private void OnBurnChanged(bool isBurn)
        {
            SetFireActive(isBurn);
        }

        private void OnDestroy()
        {
            Controller.BurnChanged -= OnBurnChanged;
        }


        private void SetFireActive(bool state)
        {
            light.SetActive(state);
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IFirepitInteractable>().FirstOrDefault();

            if (interactable != null)
                interactable.Interact(Controller);
        }
    }
}
