using System.Text;
using System.Text.RegularExpressions;

namespace Unicamente.Repository.Uteis
{
    public static class RemoveAcentuacao
    {
        public static string RemoveAcentos(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                sb.Append(s_Accents[text[i]]);

            return sb.ToString();
        }

        public static string RemoveEspacos(this string text)
        {
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

        public static string RemoveAcentosTrim(this string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                sb.Append(s_Accents[text[i]].ToString().Trim());

            return sb.ToString();
        }


        private static readonly char[] s_Accents = GetAccents();

        private static char[] GetAccents()
        {
            char[] accents = new char[256];

            for (int i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';
            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';
            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';
            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';
            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';
            accents[(byte)'ç'] = 'c';
            accents[(byte)'Ç'] = 'C';
            accents[(byte)'ñ'] = 'n';
            accents[(byte)'Ñ'] = 'N';
            accents[(byte)'´'] = ' ';
            accents[(byte)'`'] = ' ';
            accents[(byte)'*'] = ' ';
            accents[(byte)'('] = ' ';
            accents[(byte)')'] = ' ';
            accents[(byte)']'] = ' ';
            accents[(byte)'+'] = ' ';
            accents[(byte)'/'] = ' ';
            accents[(byte)'\\'] = ' ';
            accents[(byte)':'] = ' ';
            accents[(byte)'>'] = ' ';
            accents[(byte)'<'] = ' ';
            accents[(byte)'='] = ' ';
            accents[(byte)'?'] = ' ';
            accents[(byte)'!'] = ' ';
            accents[(byte)'@'] = ' ';
            accents[(byte)'#'] = ' ';
            accents[(byte)'$'] = ' ';
            accents[(byte)'%'] = ' ';
            accents[(byte)'¨'] = ' ';
            accents[(byte)'_'] = ' ';
            accents[(byte)'-'] = ' ';
            accents[(byte)'\''] = ' ';
            accents[(byte)'"'] = ' ';
            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
            accents[(byte)'Ý'] = 'Y';
            accents[(byte)'.'] = ' ';

            return accents;
        }

        //public string RemoverAcentos( string texto)
        //{
        //    string s = texto.Normalize(NormalizationForm.FormD);

        //    StringBuilder sb = new StringBuilder();

        //    for (int k = 0; k < s.Length; k++)
        //    {
        //        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
        //        if (uc != UnicodeCategory.NonSpacingMark)
        //        {
        //            sb.Append(s[k]);
        //        }
        //    }
        //    return sb.ToString();
        ////}
    }
}
