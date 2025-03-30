using Ginox.BlackCauldron.Alchemy.Views.Tools;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class BottleSpawner : XRBaseInteractable
    {
        private BottleView.Factory<BottleView> factory;

        [Inject]
        private void Init(BottleView.Factory<BottleView> factory)
        {
            this.factory = factory;
        }

        public void Create(SelectEnterEventArgs args)
        {
            var bottle = factory.Create();

            bottle.transform.position = transform.position;

            var interactable = bottle.GetComponent<XRGrabInteractable>();
            interactionManager.SelectEnter(args.interactorObject, interactable);
        }
    }
}
