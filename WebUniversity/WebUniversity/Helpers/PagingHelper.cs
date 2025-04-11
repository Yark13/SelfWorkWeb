using System.Web.Mvc;
using System.Web;
using System.Text;
using WebUniversity.ViewModels;
using System.Linq;


//namespace WebUniversity.Helpers
//{
//    public static class PagingHelper
//    {
//        public static MvcHtmlString PageLinks(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, PageInfo page, Func<int, string> pageUrl)
//        {
//            TagBuilder pageLinks = new TagBuilder("a");

//            for (int i = 1; i < page.PageSize; i++)
//            {
//                var tag = new TagBuilder("a");
//                tag.Attributes["href"] = pageUrl(i);
//                tag.InnerHtml += i.ToString();

//                if (i == page.PageNumber)
//                {
//                    tag.AddCssClass("selected");
//                    tag.AddCssClass("btn-primary");
//                }
//                tag.AddCssClass("btn btn-default");

//                pageLinks = tag;
//            }

//            return new MvcHtmlString(pageLinks.ToString()) ;
//        }
//    }
//}

