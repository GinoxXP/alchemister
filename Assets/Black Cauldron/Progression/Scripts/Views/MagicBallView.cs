using Ginox.BlackCauldron.Progression.ViewModels;
using TMPro;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Progression.Views
{
    public class MagicBallView : MonoBehaviour
    {
        private readonly string progressionFormat = "{0} / {1}";

        [SerializeField]
        private TMP_Text currentLevelIndicator;
        [SerializeField]
        private TMP_Text progressIndicator;
        [SerializeField]
        private GameObject indicator;

        private MagicBallViewModel viewModel;

        [Inject]
        private void Init(MagicBallViewModel viewModel)
        {
            this.viewModel = viewModel;
            viewModel.PropertyChanged += OnPropertyChanged;
        }

        private void Awake()
        {
            indicator.SetActive(false);

            ChangeCurrentLevelIndicator(viewModel.CurrentLevel);
            ChangeProgressIndicator(viewModel.XP, viewModel.PassXP);
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(viewModel.CurrentLevel):
                    ChangeCurrentLevelIndicator(viewModel.CurrentLevel);
                    break;

                case nameof(viewModel.XP):
                case nameof(viewModel.PassXP):
                    ChangeProgressIndicator(viewModel.XP, viewModel.PassXP);
                    break;
            }
        }

        private void ChangeCurrentLevelIndicator(int? level)
        {
            currentLevelIndicator.text = level.ToString();
        }

        private void ChangeProgressIndicator(int? xp, int? passXp)
        {
            progressIndicator.text = string.Format(progressionFormat, xp, passXp);
        }

        public void ShowIndicator()
        {
            indicator.SetActive(true);
        }

        public void HideIndicator()
        {
            indicator.SetActive(false);
        }
    }
}
