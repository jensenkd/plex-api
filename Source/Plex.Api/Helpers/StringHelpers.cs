namespace Plex.Api.Helpers
{
    using System.Text.RegularExpressions;

    public static class StringHelpers
    {
        public static string CamelCase(string s)
        {
            var x = s.Replace("_", "");
            if (x.Length == 0) return "null";
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            return char.ToLower(x[0]) + x.Substring(1);
        }
    }
}
