using Ginox.BlackCauldron.Core.Editor;
using System;
using UnityEditor;
using UnityEngine;

namespace Ginox.BlackCauldron.Books.Editor
{
    public class CreateBookWindow : EditorWindow
    {
        private static readonly string BOOKS_PATH = Environment.CurrentDirectory + "\\" + "Assets\\Black Cauldron\\Books\\Scripts\\";
        private static readonly string BOOK_PATH = "Books\\";
        private static readonly string VIEW_MODELS_PATH = BOOKS_PATH + "ViewModels\\" + BOOK_PATH;
        private static readonly string VIEWS_PATH = BOOKS_PATH + "Views\\" + BOOK_PATH;

        private string bookName;

        [MenuItem("Code Generation/Create book")]
        static void ShowWindow()
        {
            GetWindow<CreateBookWindow>("Create book");
        }

        private void OnGUI()
        {
            bookName = GUILayout.TextField(bookName);
            if (GUILayout.Button("Create"))
                Generate(bookName);
        }

        public void Generate(string bookName)
        {
            var book = ParseName.Parse(bookName);
            var viewModelClassName = $"{book}ViewModel";
            var viewClassName = $"{book}View";

            var controller =
$@"//<auto-generated/>
namespace Ginox.BlackCauldron.Books.ViewModels.Books
{{
    public class {viewModelClassName} : ABookViewModel
    {{
        public {viewModelClassName}(ABookModel model)
        {{
            Model = model;
        }}
    }}
}}
";

            var view =
$@"//<auto-generated/>
using Ginox.BlackCauldron.Books.ViewModels.Books;
using Zenject;

namespace Ginox.BlackCauldron.Books.Views.Books
{{
    public class {viewClassName} : ABookView
    {{
        [Inject]
        private void Init({viewModelClassName} viewModel)
        {{
            base.Init(viewModel);
        }}
    }}
}}
";
            ClassFile.SaveClassFile(viewModelClassName, VIEW_MODELS_PATH, controller);
            ClassFile.SaveClassFile(viewClassName, VIEWS_PATH, view);
        }
    }
}
