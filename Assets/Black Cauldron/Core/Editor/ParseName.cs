using System.Linq;

namespace Ginox.BlackCauldron.Core.Editor
{
    public class ParseName
    {
        public static string Parse(string s)
        {
            var result = s;

            var words = s.Split(' ');

            var capitalizedWords = words.Select(word => word.First().ToString().ToUpper() + word.Substring(1).ToLower());
            result = string.Join("", capitalizedWords);
            result = result.Replace(" ", string.Empty);

            return result;
        }
    }
}
