
namespace InvoicesAPI.Business.Operations
{
    public static class NameOperation
    {
        public static string ChracterRegulatory(string name)
            => name.Replace("/", "")
            .Replace("*", "")
            .Replace("-", "")
            .Replace("+", "")
            .Replace("é", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("!", "")
            .Replace("'", "")
            .Replace("£", "")
            .Replace("^", "")
            .Replace("#", "")
            .Replace("$", "")
            .Replace("%", "")
            .Replace("½", "")
            .Replace("&", "")
            .Replace("{", "")
            .Replace("}", "")
            .Replace("/", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("[", "")
            .Replace("]", "")
            .Replace("=", "")
            .Replace("?", "")
            .Replace("", "")
            .Replace("_", "")
            .Replace(",", "")
            .Replace(";", "")
            .Replace("``", "")
            .Replace("~", "")
            .Replace(".", "")
            .Replace(":", "")
            .Replace("ç", "c")
            .Replace("Ç", "C")
            .Replace("Ö", "Ö")
            .Replace("ö", "ö")
            .Replace("ü", "u")
            .Replace("Ü", "U")
            .Replace("ğ", "g")
            .Replace("Ğ", "G")
            .Replace("ş", "s")
            .Replace("Ş", "S")
            .Replace("İ", "I")
            .Replace("ı", "İ")
            .Replace("@", "")
            .Replace("€", "")
            .Replace("₺", "")
            .Replace("¨", "")
            .Replace("æ", "")
            .Replace("ß", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "");
    }
}
