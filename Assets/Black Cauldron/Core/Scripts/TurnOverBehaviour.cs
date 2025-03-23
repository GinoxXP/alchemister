using System;
using UnityEngine;

namespace Ginox.BlackCauldron.Core
{
    public class TurnOverBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float angleForActivation = 30;
        [SerializeField]
        private Transform offset;

        private bool isTurnedOver;

        public Transform Offset => offset;

        private void Start()
        {
            if (offset == null)
                offset = transform;
        }

        public bool IsTurnedOver
        {
            get => isTurnedOver;
            private set
            {
                if (value == isTurnedOver)
                    return;

                isTurnedOver = value;
                TurnOverStateChanged?.Invoke(this);
            }
        }
        public event Action<bool> TurnOverStateChanged;

        private void Update()
        {
            var angle = 180 - Vector3.Angle(transform.up, Vector3.down);

            IsTurnedOver = angle >= angleForActivation;
        }
    }
}
