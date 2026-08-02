using System.Text.RegularExpressions;

namespace Drezzma.Application.Common.Helpers
{
    public static class SlugHelper
    {
        public static string Generate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var slug = text.Trim().ToLowerInvariant();

            // Replace one or more spaces with a single hyphen
            slug = Regex.Replace(slug, @"\s+", "-");

            // Remove invalid characters
            slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");

            // Remove duplicate hyphens
            slug = Regex.Replace(slug, @"-+", "-");

            return slug.Trim('-');
        }
    }
}
