using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.Helpers
{
    public static class CustomHtmlHelper
    {
        //        public static HtmlString CustomTextBoxFor<TModel, TProperty>(
        //        this HtmlHelper<TModel> htmlHelper,
        //        Expression<Func<TModel, TProperty>> expression,
        //        string textLabel,
        //        string @class,
        //        bool required)
        //        {
        //            MvcHtmlString label = htmlHelper.LabelFor(expression, textLabel);
        //            MvcHtmlString textBox = htmlHelper.TextBoxFor(expression, new { @class, required = required ? "required" : null });
        //            MvcHtmlString validationMessage = htmlHelper.ValidationMessageFor(expression);

        //            return HtmlString(label.ToString() + textBox.ToString() + validationMessage.ToString());
        //        }

        public static HtmlString CreateList(this IHtmlHelper html, IEnumerable<Group> groups)
        {
            var result = "<select>";

            foreach (var group in groups)
            {
                result = $"{result}<option>{group.Id}</option>";
            }

            result = $"{result}</select>";
            return new HtmlString(result);
        }
    }

}
