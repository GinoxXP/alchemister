using Ginox.BlackCauldron.Alchemy.ViewModel;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public class BottleView : MonoBehaviour, IScoopCauldron
    {
        private BottleViewModel bottleViewModel;

        [Inject]
        private void Init(BottleViewModel bottleViewModel)
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
        }
    }
}
