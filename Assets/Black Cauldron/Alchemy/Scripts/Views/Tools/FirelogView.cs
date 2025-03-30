using Ginox.BlackCauldron.Alchemy.ViewModels;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class FirelogView : MonoBehaviour, IFirepitInteractable
    {
        public void Interact(FirepitViewModel controller)
        {
            if (controller.TryAddFuel())
                Destroy(gameObject);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
