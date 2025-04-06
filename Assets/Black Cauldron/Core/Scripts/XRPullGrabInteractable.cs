
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Ginox.BlackCauldron.Core
{
    public class XRPullGrabInteractable : XRGrabInteractable
    {
        [SerializeField]
        private float velocityTrashold = 2;
        [SerializeField]
        private float jumpAngleDegree = 60f;

        private XRRayInteractor rayInteractor;
        private Vector3 previousPosition;
        private Rigidbody interactableRigidbody;
        private bool isCanJump = true;

        protected override void Awake()
        {
            base.Awake();
            interactableRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (isSelected && firstInteractorSelecting is XRRayInteractor && isCanJump)
            {
                var velocity = (rayInteractor.transform.position - previousPosition) / Time.deltaTime;
                previousPosition = rayInteractor.transform.position;

                if (velocity.magnitude > velocityTrashold)
                {
                    Drop();
                    interactableRigidbody.linearVelocity = ComputeVelocity();
                    isCanJump = false;
                }
            }
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            var isRayInteractor = args.interactorObject is XRRayInteractor;
            trackPosition = !isRayInteractor;
            trackRotation = !isRayInteractor;
            throwOnDetach = !isRayInteractor;

            if (isRayInteractor)
            {
                rayInteractor = (XRRayInteractor)args.interactorObject;
                previousPosition = rayInteractor.transform.position;
                isCanJump = true;
            }

            base.OnSelectEntered(args);
        }

        private Vector3 ComputeVelocity()
        {
            var diff = rayInteractor.transform.position - transform.position;
            var diffXZ = new Vector3(diff.x, 0, diff.z);
            var diffXZLength = diffXZ.magnitude;
            var diffYLength = diff.y;

            var angleRadian = jumpAngleDegree * Mathf.Deg2Rad;
            var jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(diffXZLength, 2) / (2 * Mathf.Cos(angleRadian) * Mathf.Cos(angleRadian) * (diffXZ.magnitude * Mathf.Tan(angleRadian) - diffYLength)));

            var jumpVelocityVector = diffXZ.normalized * Mathf.Cos(angleRadian) * jumpSpeed + Vector3.up * Mathf.Sin(angleRadian) * jumpSpeed;

            if (jumpVelocityVector == new Vector3(float.NaN, float.NaN, float.NaN))
                return interactableRigidbody.linearVelocity;

            return jumpVelocityVector;
        }
    }
}
