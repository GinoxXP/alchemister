using System.Linq;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class CauldronCollider : MonoBehaviour
    {
        private CauldronView cauldron;

        private void Start()
        {
            cauldron = GetComponentInParent<CauldronView>();
        }

        public void Pour(IPourCauldron pourCauldron)
        {
            pourCauldron.Pour(cauldron);
        }

        private void OnTriggerEnter(Collider other)
        {
            var scoopable = other.GetComponentsInParent<MonoBehaviour>().OfType<IScoopCauldron>().FirstOrDefault();

            if (scoopable != null)
                scoopable.Scoop(cauldron);
        }
    }
}
