﻿using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(IngredientSpawner))]
    public class MortarView : MonoBehaviour, IPourCauldron
    {
        private const float MAX_ANGLE_FOR_CONTAIN = 30f;

        [SerializeField]
        private Transform ingredientHolder;

        private IngredientSpawner spawner;
        private IEnumerator waitAfterDropIngredient;
        private GameObject performedIngredient;

        public MortarController Controller { get; private set; }

        [Inject]
        private void Init(MortarController controller)
        {
            Controller = controller;
        }

        private void Start ()
        {
            spawner = GetComponent<IngredientSpawner>();

            Controller.HangedIngredientChanged += OnHangedIngredientChanged;
            Controller.PerformedIngredientChanged += OnPerformedIngredientChanged;
        }

        private void OnDestroy()
        {
            Controller.HangedIngredientChanged -= OnHangedIngredientChanged;
            Controller.PerformedIngredientChanged -= OnPerformedIngredientChanged;
        }

        private void OnPerformedIngredientChanged(Models.AIngredient ingredient)
        {
            if (ingredient == null)
                return;

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

        private void Update()
        {
            var angle = 180 - Vector3.Angle(transform.up, Vector3.down);

            if (angle >= MAX_ANGLE_FOR_CONTAIN)
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
                return;

            if(!hit.collider.TryGetComponent<CauldronCollider>(out var cauldronCollider))
                return;

            cauldronCollider.Pour(this);
        }

        private IEnumerator WaitAfterDropIngredient()
        {
            Controller.IsReadyForAddIngredient = false;
            yield return new WaitForSeconds(1);
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
