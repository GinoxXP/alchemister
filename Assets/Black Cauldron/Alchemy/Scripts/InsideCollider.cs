using Ginox.BlackCauldron.Alchemy.View;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy
{
    public class InsideCollider : MonoBehaviour
    {
        private CauldronView cauldron;

        private void Start()
        {
            cauldron = GetComponentInParent<CauldronView>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var ingredient = other.GetComponentInParent<AIngredientView>();

            if (ingredient != null)
            {
                cauldron.PutIn(ingredient.ViewModel.Model);
            }
        }
    }
}
