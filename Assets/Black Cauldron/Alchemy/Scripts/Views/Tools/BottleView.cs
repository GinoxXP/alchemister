using Ginox.BlackCauldron.Alchemy.ViewModels.Tools;
using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Core;
using UnityEngine;
using Zenject;
using UnityEngine.Localization;

namespace Ginox.BlackCauldron.Alchemy.Views.Tools
{
    [RequireComponent(typeof(Rigidbody))]
    public class BottleView : MonoBehaviour, IScoopCauldron, IPourAlembic, IPokeIndicatorDisplay
    {
        [SerializeField]
        private MeshRenderer fillingMaterial;

        private BottleViewModel bottleViewModel;
        private TurnOverBehaviour turnOverBehaviour;
        private ImpactBehaviour impactBehaviour;
        private LocalizedString localizedName;

        public BottleViewModel BottleViewModel => bottleViewModel;

        public string DisplayableText { get; private set; }

        public APotion ContainedPotion => bottleViewModel.Potion;

        [Inject]
        private void Init(BottleViewModel bottleViewModel)
        {
            this.bottleViewModel = bottleViewModel;
        }

        private void Start()
        {
            turnOverBehaviour = GetComponent<TurnOverBehaviour>();
            turnOverBehaviour.TurnOverStateChanged += OnTurnOverStateChanged;

            impactBehaviour = GetComponent<ImpactBehaviour>();
            impactBehaviour.Impacted += OnImpacted;

            if (BottleViewModel.Potion != null)
                localizedName = new LocalizedString("Potions", BottleViewModel.Potion.NameKey);
            else
                localizedName = new LocalizedString();

            localizedName.StringChanged += OnStringChanged;
        }

        private void OnDestroy()
        {
            localizedName.StringChanged -= OnStringChanged;
        }

        private void OnStringChanged(string value)
        {
            DisplayableText = value;
        }

        public void Scoop(CauldronView cauldronView)
        {
            var potion = cauldronView.Finish();

            if (potion == null)
            {
                Destroy(gameObject);
                return;
            }

            SetPotion(potion);
        }

        public void Pour(AlembicViewModel alembicController)
        {
            if (BottleViewModel.Potion == null)
                return;

            alembicController.TryAddPotion(BottleViewModel.Potion);
            BottleViewModel.Potion = null;
            fillingMaterial.gameObject.SetActive(false);
        }

        public void SetPotion(APotion potion)
        {
            BottleViewModel.Potion = potion;
            fillingMaterial.material = potion.Material;
            fillingMaterial.gameObject.SetActive(true);

            localizedName = new LocalizedString("Potions", BottleViewModel.Potion.NameKey);
            DisplayableText = localizedName.GetLocalizedString();
        }

        private void OnTurnOverStateChanged(bool state)
        {
            if (BottleViewModel.Potion == null)
                return;

            if (state)
                Drain();
        }

        private void OnImpacted(float impulse)
        {
            if (impulse <= impactBehaviour.Fragility)
                return;

            Destruct();
        }

        private void Destruct()
        {
            impactBehaviour.Fracture();
            Destroy(gameObject);
        }

        private void Drain()
        {
            var castExists = Physics.Raycast(turnOverBehaviour.Offset.position, Vector3.down, out var hit);
            if (!castExists || !hit.collider.TryGetComponent<AlembicBottleNeckView>(out var alembicBottleNeck))
                return;

            alembicBottleNeck.Pour(this);
        }

        public class Factory<T> : PlaceholderFactory<T>
        {

        }
    }
}
