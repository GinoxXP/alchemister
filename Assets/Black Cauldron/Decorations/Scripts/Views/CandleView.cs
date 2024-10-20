using UnityEngine;

namespace Ginox.BlackCauldron.Decorations
{
    public class CandleView : MonoBehaviour
    {
        [SerializeField]
        private float minLightIntencity;
        [SerializeField]
        private float maxLightIntencity;
        [SerializeField]
        private float minLightRange;
        [SerializeField]
        private float maxLightRange;
        [Space]
        [SerializeField]
        private float speedDifferential;

        [SerializeField]
        private new Light light;

        private float startSeed;

        private void Start ()
        {
            startSeed = Random.Range(-1f, 1f);
        }

        private void Update()
        {
            var x = (Time.time + startSeed) * speedDifferential;
            var perlin = Mathf.PerlinNoise1D(x);

            var intensity = Mathf.Lerp(minLightIntencity, maxLightIntencity, perlin);
            var range = Mathf.Lerp(minLightRange, maxLightRange, perlin);

            light.intensity = intensity;
            light.range = range;
        }
    }
}
