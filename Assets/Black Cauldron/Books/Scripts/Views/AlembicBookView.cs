using Ginox.BlackCauldron.Books.ViewModels;
using Ginox.BlackCauldron.Core;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Ginox.BlackCauldron.Books.Views
{
    //TODO Literally clone RecipeBookView. Some day I change it but not today :P
    public class AlembicBookView : MonoBehaviour, IPokeIndicatorDisplay
    {
        private static readonly string OPEN_BOOK_TRIGGER = "OpenTrigger";
        private static readonly string CLOSE_BOOK_TRIGGER = "CloseTrigger";
        private static readonly string DISTILL_KEY = "Distill";

        [SerializeField]
        private TMP_Text title;
        [SerializeField]
        private TMP_Text leftContent;
        [SerializeField]
        private TMP_Text rightContent;
        [SerializeField]
        private TMP_Text pageIndex;
        [SerializeField]
        private Button prevButton;
        [SerializeField]
        private Button nextButton;

        private AAlembicBookViewModel viewModel;
        private Animator animator;
        private Camera mainCamera;

        private int page;
        private bool isGrabed;
        private bool isGrabStateChanged;
        private string displayableText;

        private LocalizedString localizedName;

        public string DisplayableText 
        {
            get => displayableText;
            private set
            {
                displayableText = value;
                title.text = value;
            }
        }

        protected void Init(AAlembicBookViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();

            mainCamera = Camera.main;

            LocalizationSettings.Instance.OnSelectedLocaleChanged += OnSelectedLocaleChanged;

            localizedName = new LocalizedString("Books", viewModel.Model.NameKey);
            localizedName.StringChanged += OnStringChanged;

            RenderPage();
            
            nextButton.onClick.AddListener(OnNextPage);
            prevButton.onClick.AddListener(OnPreviousPage);
        }

        private void OnStringChanged(string value)
            => DisplayableText = value;

        private void OnDestroy()
        {
            LocalizationSettings.Instance.OnSelectedLocaleChanged -= OnSelectedLocaleChanged;
            
            nextButton.onClick.RemoveListener(OnNextPage);
            prevButton.onClick.RemoveListener(OnPreviousPage);
        }

        private void Update()
        {
            if (!isGrabed)
            {
                SetState();
            }
            else if(isGrabStateChanged)
            {
                isGrabStateChanged = false;
                Close();
            }
        }

        public void Activated()
        {
            isGrabStateChanged = !isGrabed;
            isGrabed = true;
        }

        public void Deactivated()
        {
            isGrabStateChanged = isGrabed;
            isGrabed = false;
        }
        
        private void OnNextPage()
        {
            page++;
            RenderPage();
        }

        private void OnPreviousPage()
        {
            page--;
            RenderPage();
        }

        private void SetState()
        {
            if (Vector3.Distance(mainCamera.transform.position, transform.position) < 0.5f)
                Open();
            else if (Vector3.Distance(mainCamera.transform.position, transform.position) > 1f)
                Close();
        }

        private void Open()
            => animator.SetTrigger(OPEN_BOOK_TRIGGER);

        private void Close()
            => animator.SetTrigger(CLOSE_BOOK_TRIGGER);

        private void OnSelectedLocaleChanged(Locale obj)
        {
            RenderPage();
        }

        private void RenderPage()
        {
            prevButton.interactable = page > 0;
            nextButton.interactable = page < viewModel.Transformations.Count - 1;

            var transformation = viewModel.Transformations[page];
            var inputPotionNameKey = transformation.InputPotion.NameKey;
            var outputPotionNameKey = transformation.OutputPotion.NameKey;

            var outputPotionLocalizedName = new LocalizedString("Potions", outputPotionNameKey);
            leftContent.text = outputPotionLocalizedName.GetLocalizedString();
            
            var inputPotionLocalizedName = new LocalizedString("Potions", inputPotionNameKey);
            var distillLocalizedName = new LocalizedString("Potions", DISTILL_KEY);
            
            var potionTransformation = $"{distillLocalizedName.GetLocalizedString()}: {inputPotionLocalizedName.GetLocalizedString()}";

            rightContent.text = potionTransformation;

            pageIndex.text = $"{page + 1}";
        }
    }
}