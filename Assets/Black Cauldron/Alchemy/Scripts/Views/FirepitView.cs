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

        public bool IsFireActive { get; private set; }

        [Inject]
        private void Init(FirepitController firepitController)
        {
            Controller = firepitController;
        }

        private void Start()
        {
            Controller.FuelChanged += OnFuelChanged;

            OnFuelChanged(Controller.FuelCount);
        }

        private void OnDestroy()
        {
            Controller.FuelChanged -= OnFuelChanged;
        }

        private void OnFuelChanged(int fuelCount)
        {
            SetFireActive(fuelCount != 0);
        }

        private void SetFireActive(bool state)
        {
            light.SetActive(state);
            IsFireActive = state;
        }

        private void OnTriggerEnter(Collider other)
        {
            var fuel = other.GetComponentsInParent<MonoBehaviour>().OfType<IFuel>().FirstOrDefault();

            if (fuel != null)
                fuel.PutFuel(this);
        }
    }
}
