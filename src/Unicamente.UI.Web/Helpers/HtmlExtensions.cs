using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unicamente.UI.Web.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlContent DisabledIf(this IHtmlHelper htmlHelper,
                                             bool condition)
       => new HtmlString(condition ? "disabled=\"disabled\"" : "");
    }
}
