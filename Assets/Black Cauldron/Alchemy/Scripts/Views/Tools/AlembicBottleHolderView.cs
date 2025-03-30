using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleHolderView : XRSocketInteractor
    {
        private AlembicViewModel controller;

        [Inject]
        private void Init(AlembicViewModel controller)
        {
            this.controller = controller;
        }

        public void SelectEnter(SelectEnterEventArgs args)
        {
            var bottleView = args.interactableObject.transform.GetComponent<BottleView>();
            controller.TryAddBottle(bottleView);
        }
        
        public void SelectExit(SelectExitEventArgs args)
        {
            controller.TryRemoveBottle();
        }
    }
}
