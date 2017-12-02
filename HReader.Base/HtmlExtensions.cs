using AngleSharp.Dom;

namespace HReader.Base
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Gets the <c>TextContent</c> of the given <see cref="IElement"/>, returns <c>string.Empty</c> for null references
        /// and trims the result.
        /// </summary>
        public static string TextSane(this IElement @this, bool trim = true)
        {
            var s = @this?.TextContent;
            if (trim)
            {
                s = s?.Trim();
            }
            return s ?? string.Empty;
        }
    }
}
