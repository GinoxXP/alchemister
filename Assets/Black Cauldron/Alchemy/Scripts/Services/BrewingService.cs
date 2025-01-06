using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public class BrewingService 
    {
        private static readonly Root root = new();

        private ANode currentNode;

        public APotion CompleatedPotion { get; private set; }

        public List<Recipe> Recipes { get; private set; } = new();

        public void RegisterRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
            CreateGraph(recipe);
        }

        public Recipe GetRecipe(APotion potion)
            => Recipes.FirstOrDefault(x => x.Potion.ToString() == potion.ToString());

        public void Brew(AIngredient ingredient)
        {
            currentNode ??= root;

            var targetType = ingredient.GetType();

            var node = currentNode.Nodes.FirstOrDefault(x => ((Node)x).Ingredient.GetType() == targetType);
            if (node == null)
            {
                Reset();
            }
            else
            {
                currentNode = node;
                if (currentNode.Nodes[0] is Leaf)
                    CompleatePotion(((Leaf)currentNode.Nodes.FirstOrDefault()).Potion);
            }
        }

        private void Reset()
        {
            // TODO Something
            CompleatedPotion = null;
            currentNode = null;
        }

        private void CompleatePotion(APotion potion)
        {
            // TODO Something
            CompleatedPotion = potion;
        }

        public void FinishBrew()
        {
            Reset();
        }

        private void CreateGraph(Recipe recipe)
        {
            var targetIngredient = recipe.Ingredients[0];
            var targetType = targetIngredient.GetType();

            var node = root.Nodes.FirstOrDefault(x => ((Node)x).Ingredient.GetType() == targetType);
            if (node == null)
            {
                node = new Node(targetIngredient);
                root.Nodes.Add(node);
            }

            CreateGraph(recipe, node, 1);
        }

        private void CreateGraph(Recipe recipe, ANode currentNode, int deep)
        {
            if (deep >= recipe.Ingredients.Count)
            {
                var leaf = new Leaf(recipe.Potion);
                currentNode.Nodes.Add(leaf);
                return;
            }

            var targetIngredient = recipe.Ingredients[deep];
            var targetType = targetIngredient.GetType();

            var node = currentNode.Nodes.FirstOrDefault(x => ((Node)x).Ingredient.GetType() == targetType);
            if (node == null)
            {
                node = new Node(targetIngredient);
                currentNode.Nodes.Add(node);
            }

            CreateGraph(recipe, node, deep + 1);
        }

        private abstract class ANode
        {
            public List<ANode> Nodes { get; } = new();
        }

        private class Root : ANode
        {
        }

        private class Node : ANode
        {
            public Node(AIngredient ingredient)
            {
                Ingredient = ingredient;
            }

            public AIngredient Ingredient { get; set; }

        }

        private class Leaf : ANode
        {
            public Leaf(APotion potion)
            {
                Potion = potion;
            }

            public APotion Potion { get; set; }
        }
    }
}
