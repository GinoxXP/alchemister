using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class CauldronView : MonoBehaviour
    {
        [SerializeField]
        private Material waterMaterial;
        [SerializeField]
        private MeshRenderer liquidSurface;
        [SerializeField]
        private List<Material> prepotionsMaterials;

        private CauldronController cauldronViewModel;

        [Inject]
        private void Init(CauldronController cauldronViewModel)
        {
            this.cauldronViewModel = cauldronViewModel;
        }

        public void PutIn(AIngredient ingredient)
        {
            cauldronViewModel.PutIn(ingredient);
            var potion = cauldronViewModel.GetPotion();

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
