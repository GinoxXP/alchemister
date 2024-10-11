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

        private CauldronController cauldronController;

        [Inject]
        private void Init(CauldronController cauldronViewModel)
        {
            this.cauldronController = cauldronViewModel;
        }

        public void PutIn(AIngredient ingredient)
        {
            cauldronController.PutIn(ingredient);
            var potion = cauldronController.GetPotion();

            if (potion == null)
                SetMaterialPotionInProcess();
            else
                SetMaterialCompleatedPotion(potion);
        }

        public APotion Finish()
        {
            var potion = cauldronController.GetPotion();

            SetMaterialClearWater();
            cauldronController.Finish();

            return potion;
        }

        private void SetMaterialCompleatedPotion(APotion potion)
        {
            liquidSurface.material = potion.Material;
        }

        private void SetMaterialPotionInProcess()
        {
            Random.InitState((int)Time.time);
            var randomIndex = Random.Range(0, prepotionsMaterials.Count - 1);
            liquidSurface.material = prepotionsMaterials[randomIndex];
        }

        private void SetMaterialClearWater()
        {
            liquidSurface.material = waterMaterial;
        }
    }
}
