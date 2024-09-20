using Ginox.BlackCauldron.Alchemy.Controllers;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class BottleView : MonoBehaviour, IScoopCauldron
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleController bottleViewModel;

        [Inject]
        private void Init(BottleController bottleViewModel)
        {
            this.bottleViewModel = bottleViewModel;
        }

        public void Scoop(CauldronView cauldronView)
        {
            var potion = cauldronView.Finish();

            if (potion == null)
            {
                Destroy(gameObject);
                return;
            }

            bottleViewModel.Potion = potion;
            fillingMaterial.material = potion.Material;
        }
    }
}
