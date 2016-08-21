using System;
using System.Text.RegularExpressions;

namespace Birchy.GatewayCodeGen.Core
{
    public static class StringHelpers
    {
        public static string ToCamelCase(this string source)
        {
            var generateSlug = source.GenerateSlug();
            if (generateSlug == source.ToLowerInvariant())
            {
                var charArray = source.ToCharArray();
                charArray[0] = char.ToLower(charArray[0]);
                return new string(charArray);
            }
            var generateSlugArray = generateSlug.ToCharArray();
            MakeWordsUpperCase(generateSlug, generateSlugArray);
            return new string(generateSlugArray).Replace("-","");
        }

        private static void MakeWordsUpperCase(string generateSlug, char[] generateSlugArray)
        {
            int dashindex = 0;
            while (dashindex >= 0)
            {
                dashindex = generateSlug.IndexOf("-", dashindex + 1, StringComparison.Ordinal);
                if (dashindex == -1)
                    break;
                generateSlugArray[dashindex + 1] = Char.ToUpper(generateSlugArray[dashindex + 1]);
            }
        }

        public static string ToPascalCase(this string source)
        {
            var camelCase = source.ToCamelCase().ToCharArray();
            camelCase[0] = Char.ToUpper(camelCase[0]);
            return new string(camelCase);

        }
        //From: http://predicatet.blogspot.com/2009/04/improved-c-slug-generator-or-how-to.html
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();
            str = str.Replace("_", " ");
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}