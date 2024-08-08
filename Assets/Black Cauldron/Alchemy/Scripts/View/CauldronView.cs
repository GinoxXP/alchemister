using Ginox.BlackCauldron.Alchemy.Model;
using Ginox.BlackCauldron.Alchemy.ViewModel;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.View
{
    public class CauldronView : MonoBehaviour
    {
        [SerializeField]
        private Material waterMaterial;
        [SerializeField]
        private MeshRenderer liquidSurface;
        [SerializeField]
        private List<Material> prepotionsMaterials;

        private CauldronViewModel cauldronViewModel;

        [Inject]
        private void Init(CauldronViewModel cauldronViewModel)
        {
            this.cauldronViewModel = cauldronViewModel;
        }

        public void PutIn(AIngredient ingredient)
        {
            cauldronViewModel.PutIn(ingredient);
            var potion = cauldronViewModel.CheckPotion();

            if (potion == null)
            {
                Random.InitState((int)Time.time);
                var randomIndex = Random.Range(0, prepotionsMaterials.Count - 1);
                liquidSurface.material = prepotionsMaterials[randomIndex];
            }
            else
            {
                liquidSurface.material = potion.Material;
            }
            
        }

        public APotion Finish()
        {
            liquidSurface.material = waterMaterial;
            return cauldronViewModel.Finish();
        }
    }
}
