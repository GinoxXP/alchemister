using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class BroomView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<GarbageView>(out var garbage))
            {
                Destroy(garbage.gameObject);
            }
        }
    }
}
