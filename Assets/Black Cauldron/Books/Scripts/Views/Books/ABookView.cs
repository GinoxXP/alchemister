using Ginox.BlackCauldron.Books.ViewModels.Books;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.XR.Interaction.Toolkit;

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

        private ABookViewModel viewModel;
        private Animator animator;
        private Camera mainCamera;
        private XRBaseInteractable xrBaseInteractable;

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

            xrBaseInteractable = GetComponent<XRBaseInteractable>();
            xrBaseInteractable.activated.AddListener(Activated());
            xrBaseInteractable.deactivated.AddListener(Deactivated());

            LocalizationSettings.Instance.OnSelectedLocaleChanged += OnSelectedLocaleChanged;
            RenderPage();
        }

        private void OnDestroy()
        {
            xrBaseInteractable.activated.RemoveListener(Activated());
            xrBaseInteractable.deactivated.RemoveListener(Deactivated());

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

        private UnityAction<ActivateEventArgs> Activated()
        {
            void Target(ActivateEventArgs args)
            {
                isGrabed = true;
                isGrabStateChanged = true;
            }

            var action = new UnityAction<ActivateEventArgs>(Target);
            return action;
        }

        private UnityAction<DeactivateEventArgs> Deactivated()
        {
            void Target(DeactivateEventArgs args)
            {
                isGrabed = false;
                isGrabStateChanged = false;
            }

            var action = new UnityAction<DeactivateEventArgs>(Target);
            return action;
        }

        private void OnSelectedLocaleChanged(Locale obj)
        {
            RenderPage();
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

        private void RenderPage()
        {
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
