using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Core;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(IngredientSpawner))]
    [RequireComponent(typeof(TurnOverBehaviour))]
    public class MortarView : MonoBehaviour, IPourCauldron
    {
        private const float WAIT_AFTER_DROP_DELAY = 1;

        [SerializeField]
        private Transform ingredientHolder;

        private IngredientSpawner spawner;
        private TurnOverBehaviour turnOverBehaviour;
        private IEnumerator waitAfterDropIngredient;
        private GameObject performedIngredient;

        public MortarViewModel Controller { get; private set; }

        [Inject]
        private void Init(MortarViewModel controller)
        {
            Controller = controller;
        }

        private void Start ()
        {
            spawner = GetComponent<IngredientSpawner>();
            turnOverBehaviour = GetComponent<TurnOverBehaviour>();

            Controller.HangedIngredientChanged += OnHangedIngredientChanged;
            Controller.PerformedIngredientChanged += OnPerformedIngredientChanged;
            turnOverBehaviour.TurnOverStateChanged += OnTurnOverStateChanged;
        }

        private void OnDestroy()
        {
            Controller.HangedIngredientChanged -= OnHangedIngredientChanged;
            Controller.PerformedIngredientChanged -= OnPerformedIngredientChanged;
            turnOverBehaviour.TurnOverStateChanged -= OnTurnOverStateChanged;
        }

        private void OnPerformedIngredientChanged(Models.AIngredient ingredient)
        {
            if (ingredient == null)
            {
                Destroy(performedIngredient);
                return;
            }

            var ingredientName = ingredient.GetType().Name;
            var ingredientGameObject = spawner.CreateByName(ingredientName);

            var view = ingredientGameObject.GetComponent<AIngredientView>();
            view.SetInteractableState(false);
            Destroy(view);

            ingredientGameObject.transform.parent = ingredientHolder;
            ingredientGameObject.transform.localPosition = Vector3.zero;

            performedIngredient = ingredientGameObject;
        }

        private void OnHangedIngredientChanged(AIngredientView ingredientView)
        {
            var state = ingredientView != null;

            if (!state)
                return;

            ingredientView.SetInteractableState(!state);
            ingredientView.transform.parent = ingredientHolder;
            ingredientView.transform.localPosition = Vector3.zero;
            ingredientView.transform.localRotation = Quaternion.identity;
        }

        private void OnTurnOverStateChanged(bool state)
        {
            if (state)
                Drop();
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponentsInParent<MonoBehaviour>().OfType<IMortarInteractable>().FirstOrDefault();

            interactable?.Interact(Controller);
        }

        private void Drop()
        {
            if (Controller.HangedIngredient != null)
            {
                Controller.PutOut();

                waitAfterDropIngredient = WaitAfterDropIngredient();
                StartCoroutine(waitAfterDropIngredient);
                return;
            }

            var ray = new Ray(transform.position, Vector3.down);
            if (!Physics.Raycast(ray, out var hit))
            {
                Controller.Drop();
                return;
            }

            if(!hit.collider.TryGetComponent<CauldronCollider>(out var cauldronCollider))
            {
                Controller.Drop();
                return;
            }

            cauldronCollider.Pour(this);
        }

        private IEnumerator WaitAfterDropIngredient()
        {
            Controller.IsReadyForAddIngredient = false;
            yield return new WaitForSeconds(WAIT_AFTER_DROP_DELAY);
            Controller.IsReadyForAddIngredient = true;
        }

        public void Pour(CauldronView cauldronView)
        {
            var ingredinet = Controller.PutOut();

            Destroy(performedIngredient);
            cauldronView.PutIn(ingredinet);
        }
    }
}
