using System;
using UnityEngine;

namespace Ginox.BlackCauldron.Core
{
    public class ImpactBehaviour : MonoBehaviour
    {
        [SerializeField]
        private FragilityType fragility;
        [SerializeField]
        private GameObject[] fragments;

        public int Fragility => (int)fragility;

        public event Action<float> Impacted;

        private void OnCollisionEnter(Collision collision)
        {
            var impulse = collision.impulse.magnitude / Time.fixedDeltaTime;
            impulse /= 100f; // kg * m / s
            Debug.Log($"Impulse detected: {impulse}");
            Impacted?.Invoke(impulse);
        }

        public void Fracture()
        {
            foreach(var fragment in fragments)
            {
                fragment.transform.parent = null;
                fragment.SetActive(true);
            }
        }

        [Serializable]
        public enum FragilityType
        {
            ExtremeFragile = 1,
            Fragile = 2,                    // Glass
            Normal = 3,
            Durable = 5,                    // Brick
            ExtremeDurable = 10,
            VirtuallyIndestructible = 20,
        }
    }
}
