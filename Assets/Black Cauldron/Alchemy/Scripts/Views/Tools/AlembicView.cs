using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Views.Tools
{
    public class AlembicView : MonoBehaviour
    {
        [SerializeField]
        private GameObject coalPile;
        [SerializeField]
        private GameObject firelight;

        private AlembicController controller;

        [Inject]
        private void Init(AlembicController controller)
        {
            this.controller = controller;
        }

        private void Start()
        {
            controller.HasFuelChanged += OnFuelChanged;
            controller.BurnChanged += OnBurnChanged;
            controller.HasBottleChanged += OnHasBottleChanged;

            coalPile.SetActive(false);
            firelight.SetActive(false);
        }

        private void OnDestroy()
        {
            controller.HasFuelChanged -= OnFuelChanged;
            controller.BurnChanged -= OnBurnChanged;
            controller.HasBottleChanged -= OnHasBottleChanged;
        }

        private void OnFuelChanged(bool state)
            => coalPile.SetActive(state);

        private void OnBurnChanged(bool state)
            => firelight.SetActive(state);

        private void OnHasBottleChanged(bool state)
        {

        }    
    }
}
