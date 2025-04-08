using Ginox.BlackCauldron.Progression.ViewModels;
using TMPro;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Progression.Views
{
    public class MagicBallView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text indicatorText;
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
            ChangeIndicator(viewModel.CurrentLevel);
        }

        private void Start()
        {
            //ChangeIndicator(viewModel.CurrentLevel);
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(viewModel.CurrentLevel):
                    ChangeIndicator(viewModel.CurrentLevel);
                    break;
            }
        }

        private void ChangeIndicator(int level)
        {
            indicatorText.text = level.ToString();
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
