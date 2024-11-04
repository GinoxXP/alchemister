using System.Linq;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class CauldronCollider : MonoBehaviour
    {
        public CauldronView Cauldron { get; private set; }

        private void Start()
        {
            Cauldron = GetComponentInParent<CauldronView>();
        }

        public void Pour(IPourCauldron pourCauldron)
        {
            pourCauldron.Pour(Cauldron);
        }

        private void OnTriggerEnter(Collider other)
        {
            var scoopable = other.GetComponentsInParent<MonoBehaviour>().OfType<IScoopCauldron>().FirstOrDefault();

            if (scoopable != null)
                scoopable.Scoop(Cauldron);
        }
    }
}
