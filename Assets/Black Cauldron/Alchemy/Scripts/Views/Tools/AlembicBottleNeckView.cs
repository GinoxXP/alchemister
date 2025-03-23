using Ginox.BlackCauldron.Alchemy.Controllers.Tools;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    public class AlembicBottleNeckView : MonoBehaviour
    {
        private AlembicController alembicController;

        [Inject]
        private void Init(AlembicController alembicController)
        {
            this.alembicController = alembicController;
        }

        public void Pour(IPourAlembic pourable)
            => pourable.Pour(alembicController);
    }
}
