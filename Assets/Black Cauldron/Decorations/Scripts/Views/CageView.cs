using Ginox.BlackCauldron.Alchemy.Views;
using System.Linq;
using UnityEngine;

namespace Ginox.BlackCauldron.Decorations.Views
{
    public class CageView : MonoBehaviour
    {
        private static readonly string CRASH_TRIGGER = "IsCrash";

        private Animator animator;

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var ingredient = other.GetComponentsInParent<MonoBehaviour>().OfType<AIngredientView>().FirstOrDefault();
            if (ingredient != null)
            {
                Destroy(ingredient.gameObject);
                animator.SetTrigger(CRASH_TRIGGER);
            }
        }
    }
}