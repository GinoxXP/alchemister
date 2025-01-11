using UnityEngine;

namespace Ginox.BlackCauldron.Decorations.Views
{
    public class SkibidiView : MonoBehaviour
    {
        private AudioSource source;
        private Animator animator;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetTrigger("Rise");
            source.Play();
        }

        public void Sleep()
        {
            animator.SetTrigger("Sleep");
            source.Stop();
        }
    }
}
