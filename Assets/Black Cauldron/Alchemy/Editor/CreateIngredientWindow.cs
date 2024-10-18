using UnityEditor;
using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Editor
{
    public class CreateIngredientWindow : EditorWindow
    {
        private string ingredientName;

        [MenuItem("Code Generation/Create Ingredient")]
        static void ShowWindow()
        {
            GetWindow<CreateIngredientWindow>("Create Ingredient");
        }

        private void OnGUI()
        {
            ingredientName = GUILayout.TextField(ingredientName);
            if (GUILayout.Button("Create"))
            {
                var generator = new IngredientSourceGenerator();
                generator.Generate(ingredientName);
            }
        }
    }
}
