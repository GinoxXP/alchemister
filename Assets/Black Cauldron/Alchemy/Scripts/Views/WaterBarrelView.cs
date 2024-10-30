using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class WaterBarrelView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PotView>(out var pot))
                return;

            if (pot.IsFilled)
                return;

            pot.Fill();
        }
    }
}
