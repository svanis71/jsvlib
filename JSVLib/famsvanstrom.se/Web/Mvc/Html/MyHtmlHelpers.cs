// // famsvanstrom.se: MyHtmlHelpers.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dinamico.Models;
using N2;

#endregion

namespace famsvanstrom.se.Web.Mvc.Html
{
    public class JsvMenu
    {
        public string label;
        public string link;
        public bool current;
        public JsvMenu[] subitems;

    }

    public static class MyHtmlHelpers
    {
        public const string BreadcrumbClass = "breadcrumb";
        public const string BreadcrumbItemClass = "breadcrumb-item";
        public const string BreadcrumbSeparatorClass = "breadcrumb-separator";

        public static IHtmlString Breadcrumb(this HtmlHelper helper, ContentItem current, object htmlAttributes = null)
        {
            if (current.GetContentType() == typeof(StartPage))
                return new MvcHtmlString("");
            var section = new TagBuilder("section");
            var sectionHtml = new StringBuilder();
            var greater = new TagBuilder("span");
            greater.AddCssClass(BreadcrumbSeparatorClass);
            greater.SetInnerText(">>");
            section.AddCssClass(BreadcrumbClass);
            foreach (var page in N2.Find.EnumerateParents(current, N2.Find.StartPage).Reverse())
            {
                var a = new TagBuilder("a");
                a.AddCssClass(BreadcrumbItemClass);
                a.Attributes.Add("href", page.Url);
                a.Attributes.Add("title", page.Title);
                a.SetInnerText(page.Title);
                if (sectionHtml.Length > 0)
                    sectionHtml.Append(greater.ToString());
                sectionHtml.Append(a.ToString());
            }
            // Extra >> berfore current page.
            sectionHtml.Append(greater.ToString());
            var currPageSpan = new TagBuilder("span");
            currPageSpan.AddCssClass(BreadcrumbItemClass);
            currPageSpan.SetInnerText(current.Title);
            sectionHtml.Append(currPageSpan.ToString());

            section.InnerHtml = sectionHtml.ToString();
            return new MvcHtmlString(section.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id,
                                          object htmlAttributes)
        {
            return helper.Image(id, "", "", null, htmlAttributes);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string url, string altText, string onclickLink, object htmlAttributes)
        {
            var html = CreateImageTag(id, url, altText, onclickLink, htmlAttributes);

            return new MvcHtmlString(html);
        }

        private static string CreateImageTag(string id, string url, string altText, string onclickLink, object htmlAttributes)
        {
            var html = string.Empty;
            var builder = new TagBuilder("img");
            builder.GenerateId(id);
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", altText);
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            if (onclickLink != null)
            {
                var anch = new TagBuilder("a");
                anch.GenerateId("a_" + id);

                anch.MergeAttribute("href", onclickLink);
                anch.InnerHtml = builder.ToString(TagRenderMode.SelfClosing);
                html = anch.ToString();
            }
            else
                html = builder.ToString(TagRenderMode.SelfClosing);
            return html;
        }

        public static MvcHtmlString BigBoxList(this HtmlHelper helper, IEnumerable<ContentItem> items)
        {
            var result = string.Empty;
            var secBuilder = new TagBuilder("section");
            var innerHtml = new StringBuilder();

            secBuilder.AddCssClass("big-boxes");

            foreach (var itm in items)
            {
                var contentPage = itm as ContentPage;
                var ddBuilder = new TagBuilder("dd");
                var anchor = new TagBuilder("a");
                anchor.MergeAttribute("href", itm.Url);

                var divBuilder = new TagBuilder("div");
                divBuilder.AddCssClass("item-box");
                var imgDivBuilder = new TagBuilder("section");
                imgDivBuilder.AddCssClass("item-box-img-container");
                var img = new TagBuilder("img");
                img.MergeAttribute("src", itm.IconUrl);
                img.MergeAttribute("alt", itm.Title);
                img.MergeAttribute("title", itm.Title);
                imgDivBuilder.InnerHtml = img.ToString(TagRenderMode.SelfClosing);
                var textBoxContainer = new TagBuilder("section");
                textBoxContainer.AddCssClass("item-box-text-container");
                // Add title
                var titleBox = new TagBuilder("header");
                titleBox.AddCssClass("item-box-text-title");
                titleBox.InnerHtml = itm.Title;
                // Summary box
                var summaryBox = new TagBuilder("article");
                summaryBox.AddCssClass("item-box-text-summary");
                if (contentPage != null) summaryBox.InnerHtml = contentPage.Summary;
                textBoxContainer.InnerHtml = titleBox.ToString() + summaryBox.ToString();

                divBuilder.InnerHtml = imgDivBuilder.ToString() + textBoxContainer.ToString();
                anchor.InnerHtml = divBuilder.ToString();
                ddBuilder.InnerHtml = anchor.ToString();

                innerHtml.Append(ddBuilder.ToString());
            }
            if (innerHtml.Length != 0)
            {
                secBuilder.InnerHtml = innerHtml.ToString();
                return new MvcHtmlString(secBuilder.ToString(TagRenderMode.Normal));
            }
            else
                return MvcHtmlString.Empty;
        }
        
        //public static MvcHtmlString MenuJson(this HtmlHelper helper, ContentItem start)
        //{
        //    ILogger logger = new Logger(typeof(MyHtmlHelpers));

        //    logger.Debug("Html.MenuJson enter");
        //    List<JsvMenu> items = new List<JsvMenu>();
        //    var rowNum = 0;
        //    var itemNum = 0;
        //    var subitemNum = 0;
        //    try
        //    {
        //        items.Add(new JsvMenu()
        //                      {
        //                          label = Content.Traverse.StartPage.Title,
        //                          link = Content.Traverse.StartPage.Url,
        //                          current = Content.Current.Item == Content.Traverse.StartPage
        //                      });
        //        rowNum++;
        //        foreach (
        //            var item in
        //                Content.Traverse.StartPage.GetChildren().Where(p => p.Visible && !string.IsNullOrEmpty(p.Title))
        //            )
        //        {
        //            logger.Debug("{1}: item.Visible = {0}", item.Visible, item.Title);
        //            itemNum++;   
        //            logger.Debug("Content.Current == null -> {0}", Content.Current == null);
        //            logger.Debug("Content.Current.Item == null -> {0}", Content.Current.Item == null);
        //            var i = new JsvMenu()
        //                        {
        //                            label = item.Title,
        //                            link = item.Url,
        //                            current = Content.Current.Item == item || (Content.Current.Item != null && Content.Current.Item.Parent == item)
        //                        };
        //            logger.Debug("item.GetChildren() == null -> {0}", item.GetChildren() == null);
        //            if (item.GetChildren() != null && item.GetChildren().Count > 0)
        //            {
        //                var sublist = new List<JsvMenu>();
        //                subitemNum = 0;
        //                foreach (
        //                    var subitem in item.GetChildren().Where(p => p.Visible && !string.IsNullOrEmpty(p.Title)))
        //                {
        //                    sublist.Add(new JsvMenu()
        //                                    {
        //                                        label = subitem.Title,
        //                                        link = subitem.Url
        //                                    });
        //                    subitemNum++;
        //                }
        //                i.subitems = sublist.ToArray();
        //            }
        //            rowNum++;
        //            items.Add(i);
        //        }
        //        rowNum++;
        //    }
        //    catch (NullReferenceException nex)
        //    {
        //        // Bug caught
        //        logger.Debug("NullReferenceException in MenuJson last position was rowNum: {0}, itemNum: {1}, subItem: {2}", rowNum, itemNum, subitemNum);
        //        logger.Debug(nex.ToString());
        //        throw new ApplicationException("Oj något gick fel när meny skapades.");
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Debug("{2} in MenuJson last position was {0}, {1}", rowNum, subitemNum, ex.GetType().Name);
        //        logger.Debug(ex.ToString());
        //        throw new ApplicationException("Oj något gick fel när meny skapades.");
        //    }
        //    var result = JsonConvert.SerializeObject(items);
        //    logger.Debug("Html.MenuJson exit");
        //    return new MvcHtmlString(result);
        //}

    }

}