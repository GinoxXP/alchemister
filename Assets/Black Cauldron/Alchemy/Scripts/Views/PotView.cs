using UnityEngine;
using UnityEngine.VFX;

namespace Ginox.BlackCauldron.Alchemy.Views
{
    public class PotView : MonoBehaviour, IPourCauldron
    {
        private const string START_FLOW = "OnStartFlow";
        private const string STOP_FLOW = "OnStopFlow";
        private const float MAX_ANGLE_FOR_CONTAIN_WATER = 30f;

        [SerializeField]
        private GameObject waterSurface;
        [SerializeField]
        private VisualEffect waterFlowVFX;

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

        private void Update()
        {
            if (!IsFilled)
                return;

            var angle = 180 - Vector3.Angle(transform.up, Vector3.down);

            if (angle >= MAX_ANGLE_FOR_CONTAIN_WATER)
                Drain();
            else
                waterFlowVFX.SendEvent(STOP_FLOW);
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
