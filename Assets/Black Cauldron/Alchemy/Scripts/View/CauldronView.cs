using Ginox.BlackCauldron.Alchemy.Model;
using Ginox.BlackCauldron.Alchemy.ViewModel;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public class CauldronView : MonoBehaviour
    {
        private CauldronViewModel cauldronViewModel;

        [Inject]
        private void Init(CauldronViewModel cauldronViewModel)
        {
            this.cauldronViewModel = cauldronViewModel;
        }

        public void PutIn(AIngredient ingredient)
            => cauldronViewModel.PutIn(ingredient);
    }
}
