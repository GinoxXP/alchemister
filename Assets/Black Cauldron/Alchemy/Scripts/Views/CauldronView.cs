using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Controllers;
using UnityEngine;
using Zenject;
using UnityEngine.VFX;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class CauldronView : MonoBehaviour
    {
        private static readonly string START_BOILING_EVENT = "OnStartBoiling";
        private static readonly string STOP_BOILING_EVENT = "OnStopBoiling";

        [SerializeField]
        private Material waterMaterial;
        [SerializeField]
        private MeshRenderer liquidSurface;
        [SerializeField]
        private Material prepotionMaterial;
        [SerializeField]
        private VisualEffect visualEffect;

        private CauldronController cauldronController;

        private bool isBoiling;

        [Inject]
        private void Init(CauldronController cauldronViewModel)
        {
            this.cauldronController = cauldronViewModel;
        }

        public void PutIn(AIngredient ingredient)
        {
            if (!isBoiling)
            {
                visualEffect.SendEvent(START_BOILING_EVENT);
                isBoiling = true;
            }

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

            visualEffect.SendEvent(STOP_BOILING_EVENT);
            isBoiling = false;
            return potion;
        }

        private void SetMaterialCompleatedPotion(APotion potion)
        {
            visualEffect.SendEvent(STOP_BOILING_EVENT);
            isBoiling = false;

            liquidSurface.material = potion.Material;
        }

        private void SetMaterialPotionInProcess()
        {
            liquidSurface.material = prepotionMaterial;
        }

        private void SetMaterialClearWater()
        {
            liquidSurface.material = waterMaterial;
        }
    }
}
