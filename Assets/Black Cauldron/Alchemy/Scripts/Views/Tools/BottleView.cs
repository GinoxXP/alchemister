using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class BottleView : MonoBehaviour, IScoopCauldron
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleController bottleController;

        public BottleController BottleController => bottleController;

        [Inject]
        private void Init(BottleController bottleViewModel)
        {
            this.bottleController = bottleViewModel;
        }

        public void Scoop(CauldronView cauldronView)
        {
            var potion = cauldronView.Finish();

            if (potion == null)
            {
                Destroy(gameObject);
                return;
            }

            bottleController.Potion = potion;
            fillingMaterial.material = potion.Material;
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
