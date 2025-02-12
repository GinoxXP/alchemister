﻿using Ginox.BlackCauldron.Alchemy.Controllers;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class FirelogView : MonoBehaviour, IFirepitInteractable
    {
        public void Interact(FirepitController controller)
        {
            if (controller.TryAddFuel())
                Destroy(gameObject);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
