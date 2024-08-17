using Ginox.BlackCauldron.Alchemy.Service;
using Ginox.BlackCauldron.Alchemy.ViewModel;
using Ginox.BlackCauldron.Alchemy.Model;
using Ginox.BlackCauldron.Alchemy.Model.Potions;
using Ginox.BlackCauldron.Alchemy.Model.Ingredients;
using Zenject;
using Ginox.BlackCauldron.Alchemy.ViewModel.Ingredients;
using UnityEngine;

public class AlchemyInstaller : MonoInstaller
{
    [SerializeField]
    private Material beginerPotionMaterial;

    public override void InstallBindings()
    {
        InstallIngredients();
        InstallPotions();

        Container.Bind<CauldronViewModel>().AsTransient();
        Container.Bind<BrewingService>().AsSingle();
        Container.Bind<BottleViewModel>().AsTransient();
    }

    public override void Start()
    {
        var brewingService = Container.Resolve<BrewingService>();

        var ash = Container.Resolve<Ash>();
        var salt = Container.Resolve<Salt>();

        brewingService.RegisterRecipe(
            new Recipe(Container.Resolve<BeginerPotion>())
            .RegisterIngredient(ash)
            .RegisterIngredient(salt)
        );
    }

    private void InstallIngredients()
    {
        Container.Bind<Ash>().AsTransient();
        Container.Bind<Salt>().AsTransient();

        Container.Bind<AshViewModel>().AsTransient();
        Container.Bind<SaltViewModel>().AsTransient();
    }

    private void InstallPotions()
    {
        Container.Bind<BeginerPotion>().FromMethod(x => new BeginerPotion(beginerPotionMaterial)).AsTransient();
    }
}