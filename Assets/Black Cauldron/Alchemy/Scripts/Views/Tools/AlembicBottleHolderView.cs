using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleHolderView : XRSocketInteractor
    {
        private AlembicController controller;
        private BottleView bottle;

        [Inject]
        private void Inject(AlembicController controller)
        {
            this.controller = controller;
        }

        public void SelectEnter(SelectEnterEventArgs args)
        {
            // Add bottle
        }
        
        public void SelectExit(SelectExitEventArgs args)
        {
            // Remove bottle
        }
    }
}
