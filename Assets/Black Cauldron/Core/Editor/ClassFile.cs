using System.IO;

namespace Ginox.BlackCauldron.Core.Editor
{
    public class ClassFile
    {
        public static void SaveClassFile(string name, string path, string code)
        {
            var file = $@"{name}.cs";
            var filePath = path + file;

            File.WriteAllText(filePath, code);
            File.SetAttributes(filePath, FileAttributes.Normal);
        }
    }
}
