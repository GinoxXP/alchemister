using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class FirelogView : MonoBehaviour, IFuel
    {
        public void PutFuel(FirepitView view)
        {
            view.Controller.AddFuel();
            Destroy(gameObject);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
