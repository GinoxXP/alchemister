using Ginox.BlackCauldron.Alchemy.Views;
using System.Linq;
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
            var scoopable = other.GetComponentsInParent<MonoBehaviour>().OfType<IScoopCauldron>().FirstOrDefault();

            if (scoopable != null)
                scoopable.Scoop(cauldron);
        }
    }
}
