using Ginox.BlackCauldron.Core;
using UnityEngine;
using UnityEngine.VFX;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(TurnOverBehaviour))]
    public class PotView : MonoBehaviour, IPourCauldron
    {
        private const string START_FLOW = "OnStartFlow";
        private const string STOP_FLOW = "OnStopFlow";

        [SerializeField]
        private GameObject waterSurface;
        [SerializeField]
        private VisualEffect waterFlowVFX;

        private TurnOverBehaviour turnOverBehaviour;

        private bool isFilled;

        public bool IsFilled { 
            get => isFilled;
            set
            {
                isFilled = value;
                waterSurface.SetActive(value);
            }
        }

        private void Awake()
        {
            waterSurface.SetActive(false);
        }

        private void Start()
        {
            turnOverBehaviour = GetComponent<TurnOverBehaviour>();
            turnOverBehaviour.TurnOverStateChanged += OnTurnOverStateChanged;
        }

        private void OnTurnOverStateChanged(bool state)
        {
            if (!IsFilled)
                return;

            if (state)
                Drain();
            else
                waterFlowVFX.SendEvent(STOP_FLOW);
        }

        private void OnDestroy()
        {
            turnOverBehaviour.TurnOverStateChanged -= OnTurnOverStateChanged;
        }

        public void Fill()
        {
            IsFilled = true;
        }

        public void Drain()
        {
            IsFilled = false;
            waterFlowVFX.SendEvent(START_FLOW);

            var castExists = Physics.Raycast(transform.position, Vector3.down, out var hit);
            if (!castExists || !hit.collider.TryGetComponent<CauldronCollider>(out var cauldronCollider))
                return;

            cauldronCollider.Pour(this);
            
        }

        public void Pour(CauldronView cauldronView)
        {
            cauldronView.Fill();
        }
    }
}
