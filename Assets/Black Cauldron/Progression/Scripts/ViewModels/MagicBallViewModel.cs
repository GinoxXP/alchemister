using Ginox.BlackCauldron.Core;
using Ginox.BlackCauldron.Progression.Models;
using Ginox.BlackCauldron.Progression.Services;

namespace Ginox.BlackCauldron.Progression.ViewModels
{
    public class MagicBallViewModel : ViewModel
    {
        private MagicBall model;
        private ProgressionService service;

        public int CurrentLevel
        {
            get => model.CurrentLevel;
            private set
            {
                model.CurrentLevel = value;
                OnPropertyChanged();
            }
        }

        public MagicBallViewModel(
            MagicBall model,
            ProgressionService service)
        {
            this.model = model;
            this.service = service;

            service.NewLevelAllowed += OnNewLevelAllowed;
            OnNewLevelAllowed(service.Level);
        }

        private void OnNewLevelAllowed(int level)
            => CurrentLevel = level;
    }
}
