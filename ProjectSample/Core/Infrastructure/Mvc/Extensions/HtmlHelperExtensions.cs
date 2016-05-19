using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ProjectSample.Core.Infrastructure.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RenderPartials<T>(this HtmlHelper htmlHelper, string start, IEnumerable<T> models, string end)
        {
            if (models == null) return MvcHtmlString.Empty;

            var renderedPartials = new List<MvcHtmlString> {new MvcHtmlString(start)};

            var partials = 
                    models
                        .Select(model => new {model, partialViewName = model.GetType().Name})
                        .Select(t => htmlHelper.DisplayForModel(t.partialViewName,t.model));
            renderedPartials.AddRange(partials);
            renderedPartials.Add(new MvcHtmlString(end));

            var result = renderedPartials.Aggregate(string.Empty,
                (current, mvcHtmlString) => $"{current}{mvcHtmlString.ToHtmlString()}");

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString RenderPartials<T>(this HtmlHelper htmlHelper, IEnumerable<T> models)
            => RenderPartials(htmlHelper, string.Empty, models, string.Empty);
    }
}