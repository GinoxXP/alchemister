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

        public int? XP
        {
            get => model.XP;
            private set
            {
                model.XP = value;
                OnPropertyChanged();
            }
        }

        public int? PassXP
        {
            get => model.PassXP;
            private set
            {
                model.PassXP = value;
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
            service.XpChanged += OnXpChanged;

            OnNewLevelAllowed(service.Level);
            OnXpChanged(service.XP, service.PassXP);
        }

        private void OnXpChanged(int xp, int? passXp)
        {
            XP = xp;
            PassXP = passXp;
        }

        private void OnNewLevelAllowed(int level)
            => CurrentLevel = level;
    }
}
