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

        public FirepitViewModel viewModel { get; private set; }


        [Inject]
        private void Init(FirepitViewModel firepitController)
        {
            viewModel = firepitController;
        }

        private void Start()
        {
            viewModel.PropertyChanged += OnPropertyChanged;

            OnBurnChanged(viewModel.IsBurn);
            OnFuelChanged(viewModel.FuelCount);
        }

        private void OnDestroy()
        {
            viewModel.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(viewModel.IsBurn):
                    OnBurnChanged(viewModel.IsBurn);
                    break;

                case nameof(viewModel.FuelCount):
                    OnFuelChanged(viewModel.FuelCount);
                    break;
            }
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
                interactable.Interact(viewModel);
        }
    }
}
