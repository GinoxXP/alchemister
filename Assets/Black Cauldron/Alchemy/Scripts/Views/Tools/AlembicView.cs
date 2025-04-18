﻿using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using UnityEngine;
using Zenject;

namespace Ginox.BlackCauldron.Views.Tools
{
    public class AlembicView : MonoBehaviour
    {
        [SerializeField]
        private GameObject coalPile;
        [SerializeField]
        private GameObject fireParticles;

        private AlembicViewModel controller;

        [Inject]
        private void Init(AlembicViewModel controller)
        {
            this.controller = controller;
        }

        private void Start()
        {
            controller.HasFuelChanged += OnFuelChanged;
            controller.BurnChanged += OnBurnChanged;

            coalPile.SetActive(false);
            fireParticles.SetActive(false);
        }

        private void OnDestroy()
        {
            controller.HasFuelChanged -= OnFuelChanged;
            controller.BurnChanged -= OnBurnChanged;
        }

        private void OnFuelChanged(bool state)
            => coalPile.SetActive(state);

        private void OnBurnChanged(bool state)
            => fireParticles.SetActive(state);   
    }
}
