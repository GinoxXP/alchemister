using Ginox.BlackCauldron.Alchemy.ViewModels;
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
        [SerializeField]
        private GameObject[] firelogs;

        public FirepitViewModel Controller { get; private set; }


        [Inject]
        private void Init(FirepitViewModel firepitController)
        {
            Controller = firepitController;
        }

        private void Start()
        {
            Controller.BurnChanged += OnBurnChanged;
            Controller.FuelChanged += OnFuelChanged;

            OnBurnChanged(Controller.IsBurn);
            OnFuelChanged(Controller.FuelCount);
        }

        private void OnDestroy()
        {
            Controller.BurnChanged -= OnBurnChanged;
            Controller.FuelChanged -= OnFuelChanged;
        }

        private void OnFuelChanged(int fuelCount)
        {
            for(int i = 0; i < firelogs.Length; i++)
                firelogs[i].SetActive(i < fuelCount);
        }

        private void OnBurnChanged(bool isBurn)
        {
            SetFireActive(isBurn);
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
