using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningASPCORE.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString DisabledIfStatement(this IHtmlHelper html, bool Condition)
        {
            return new HtmlString(Condition ? "class=\"btn btn-info btn-lg disabled\"" : "\btn btn-info\"");
        }
    }
}
