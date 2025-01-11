using UnityEngine;

namespace Ginox.BlackCauldron.Decorations
{
    public class PigView : MonoBehaviour
    {
        private Animator animator;
        private AudioSource audioSource;

        private void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        public void Press()
        {
            animator.SetTrigger("Press");
            audioSource.Play();
        }

        public void Release()
        {
            animator.SetTrigger("Release");
        }
    }
}
