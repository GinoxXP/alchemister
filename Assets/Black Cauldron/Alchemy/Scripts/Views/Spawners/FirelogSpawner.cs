using Ginox.BlackCauldron.Alchemy.Views.Tools;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Spawners
{
    public class FirelogSpawner : XRBaseInteractable
    {
        private FirelogView.Factory<FirelogView> factory;

        [Inject]
        private void Init(FirelogView.Factory<FirelogView> factory)
        {
            this.factory = factory;
        }

        public void Create(SelectEnterEventArgs args)
        {
            var firelog = factory.Create();

            firelog.transform.position = transform.position;

            var interactable = firelog.GetComponent<XRGrabInteractable>();
            interactionManager.SelectEnter(args.interactorObject, interactable);
        }
    }
}
