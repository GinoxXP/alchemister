using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class WaterBarrelView : MonoBehaviour
    {
        private const string REFILL_TRIGGER = "Refill";
        private Animator animator;

        private void Start ()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PotView>(out var pot))
                return;

            if (pot.IsFilled)
                return;

            pot.Fill();
            animator.SetTrigger(REFILL_TRIGGER);
        }
    }
}
