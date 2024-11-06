using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.Controllers;
using UnityEngine;
using Zenject;
using UnityEngine.VFX;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class CauldronView : MonoBehaviour
    {
        private const string START_BOILING_EVENT = "OnStartBoiling";
        private const string STOP_BOILING_EVENT = "OnStopBoiling";
        private const string FILL_TRIGGER = "Fill";

        [SerializeField]
        private Material waterMaterial;
        [SerializeField]
        private MeshRenderer liquidSurface;
        [SerializeField]
        private Material prepotionMaterial;
        [SerializeField]
        private VisualEffect visualEffect;

        private CauldronController cauldronController;
        private Animator animator;

        private bool isBoiling;
        private bool isFilled;

        private bool IsFilled
        {
            get => isFilled;
            set
            {
                isFilled = value;
                liquidSurface.gameObject.SetActive(value);
                if (value)
                    animator.SetTrigger(FILL_TRIGGER);
            }
        }

        [Inject]
        private void Init(CauldronController cauldronViewModel)
        {
            this.cauldronController = cauldronViewModel;
        }

        private void Awake()
        {
            IsFilled = false;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void PutIn(AIngredient ingredient)
        {
            if (!isFilled)
                return;

            if (!isBoiling)
            {
                visualEffect.SendEvent(START_BOILING_EVENT);
                isBoiling = true;
            }

            cauldronController.PutIn(ingredient);
            ingredient.Destroy();

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

            Drain();

            return potion;
        }

        public void Fill()
        {
            IsFilled = true;
        }

        public void Drain()
        {
            IsFilled = false;
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
