using Ginox.BlackCauldron.Progression.Services;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Progression
{
    public class AvailableLevelView : MonoBehaviour
    {
        [SerializeField]
        private int activationLevel;

        private ProgressionService progressionService;

        [Inject]
        private void Init(ProgressionService progressionService)
        {
            this.progressionService = progressionService;
            progressionService.NewLevelAllowed += OnNewLevelAllowed;
        }

        private void Awake()
        {
            if (progressionService.Level < activationLevel)
                gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            progressionService.NewLevelAllowed -= OnNewLevelAllowed;
        }

        private void OnNewLevelAllowed(int level)
        {
            if (level >= activationLevel)
                gameObject.SetActive(true);
        }
    }
}
