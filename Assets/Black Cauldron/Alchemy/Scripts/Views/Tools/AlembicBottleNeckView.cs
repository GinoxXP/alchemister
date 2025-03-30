using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleNeckView : MonoBehaviour
    {
        private AlembicViewModel alembicController;

        [Inject]
        private void Init(AlembicViewModel alembicController)
        {
            this.alembicController = alembicController;
        }

        public void Pour(IPourAlembic pourable)
            => pourable.Pour(alembicController);
    }
}
