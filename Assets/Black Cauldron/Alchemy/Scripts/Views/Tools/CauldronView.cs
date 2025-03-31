using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Alchemy.ViewModels;
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
        [SerializeField]
        private FirepitView firepitView;

        private CauldronViewModel cauldronViewModel;
        private Animator animator;
        private FirepitViewModel firepitViewModel;

        private bool isBoiling;
        private bool isFilled;
        private bool isHasFire;

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
        private void Init(CauldronViewModel cauldronViewModel)
        {
            this.cauldronViewModel = cauldronViewModel;
        }

        private void Awake()
        {
            IsFilled = false;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            firepitViewModel = firepitView.viewModel;
            firepitViewModel.PropertyChanged += OnPropertyChanged;

            OnFuelChanged(firepitViewModel.FuelCount);
        }

        private void OnDestroy()
        {
            firepitViewModel.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(firepitViewModel.FuelCount):
                    OnFuelChanged(firepitViewModel.FuelCount);
                    break;
            }
        }

        private void OnFuelChanged(int count)
        {
            isHasFire = count > 0;
        }

        public void PutIn(AIngredientViewModel ingredient)
        {
            PutIn(ingredient.Model);
            ingredient.Destroy();
        }

        public void PutIn(AIngredient ingredient)
        {
            if (!isFilled || !isHasFire)
                return;

            if (!isBoiling)
            {
                visualEffect.SendEvent(START_BOILING_EVENT);
                isBoiling = true;
            }

            cauldronViewModel.PutIn(ingredient);

            var potion = cauldronViewModel.CompleatedPotion;

            if (potion == null)
                SetMaterialPotionInProcess();
            else
                SetMaterialCompleatedPotion(potion);
        }

        public APotion Finish()
        {
            var potion = cauldronViewModel.CompleatedPotion;

            SetMaterialClearWater();
            cauldronViewModel.Finish();

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
