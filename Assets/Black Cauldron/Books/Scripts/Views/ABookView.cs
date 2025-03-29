using Ginox.BlackCauldron.Books.ViewModels;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Ginox.BlackCauldron.Books.Views
{
    public class ABookView : MonoBehaviour
    {
        private static readonly string OPEN_BOOK_TRIGGER = "OpenTrigger";
        private static readonly string CLOSE_BOOK_TRIGGER = "CloseTrigger";

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

        private ABookViewModel viewModel;
        private Animator animator;
        private Camera mainCamera;

        private int page;
        private bool isGrabed;
        private bool isGrabStateChanged;

        protected void Init(ABookViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();

            mainCamera = Camera.main;

            LocalizationSettings.Instance.OnSelectedLocaleChanged += OnSelectedLocaleChanged;
            RenderPage();
        }

        private void OnDestroy()
        {
            LocalizationSettings.Instance.OnSelectedLocaleChanged -= OnSelectedLocaleChanged;
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

        public void OnNextPage()
        {
            page++;
            RenderPage();
        }

        public void OnPreviousPage()
        {
            page--;
            RenderPage();
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
            nextButton.interactable = page < viewModel.Recipes.Count - 1;

            var recipe = viewModel.Recipes[page];
            var potionNameKey = recipe.Potion.NameKey;

            var potionLocalizedName = new LocalizedString("Potions", potionNameKey);
            leftContent.text = potionLocalizedName.GetLocalizedString();

            var ingredientsKeyNames = recipe.Ingredients.Select(x => x.NameKey).ToList();

            var ingredientsNames = new List<string>();
            for (int i = 0; i < ingredientsKeyNames.Count; i++)
            {
                var localizedName = new LocalizedString("Ingredients", ingredientsKeyNames[i]);
                var localizedString = localizedName.GetLocalizedString();

                if (i != 0)
                    localizedString = localizedString[..1].ToLowerInvariant() + localizedString[1..];

                ingredientsNames.Add(localizedString);
            }

            var potionRecpe = string.Empty;
            potionRecpe = string.Join(", ", ingredientsNames);

            rightContent.text = potionRecpe;

            pageIndex.text = $"{page + 1}";
        }
    }
}
