using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dinamico.Controllers;
using Dinamico.Models;
using MyLib.Logging;
using N2;
using N2.Definitions;
using Newtonsoft.Json;
using n2www_famsvanstrom.se.Web.Logging;

namespace n2www_famsvanstrom.se.Web.Mvc.Html
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
            var dlBuilder = new TagBuilder("dl");
            var dlHtml = new StringBuilder();

            dlBuilder.AddCssClass("big-box-list");

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

                dlHtml.Append(ddBuilder.ToString());
            }
            if (dlHtml.Length != 0)
            {
                dlBuilder.InnerHtml = dlHtml.ToString();
                return new MvcHtmlString(dlBuilder.ToString(TagRenderMode.Normal));
            }
            else
                return MvcHtmlString.Empty;
        }

        public static MvcHtmlString MenuJson(this HtmlHelper helper, ContentItem start)
        {
            IMyLogger logger = new MyLogger();

            logger.Debug("Html.MenuJson enter");
            List<JsvMenu> items = new List<JsvMenu>();
            var rowNum = 0;
            var itemNum = 0;
            var subitemNum = 0;
            try
            {
                items.Add(new JsvMenu()
                              {
                                  label = Content.Traverse.StartPage.Title,
                                  link = Content.Traverse.StartPage.Url,
                                  current = Content.Current.Item == Content.Traverse.StartPage
                              });
                rowNum++;
                foreach (
                    var item in
                        Content.Traverse.StartPage.GetChildren().Where(p => p.Visible && !string.IsNullOrEmpty(p.Title))
                    )
                {
                    logger.Debug("{1}: item.Visible = {0}", item.Visible, item.Title);
                    itemNum++;   
                    logger.Debug("Content.Current == null -> {0}", Content.Current == null);
                    logger.Debug("Content.Current.Item == null -> {0}", Content.Current.Item == null);
                    var i = new JsvMenu()
                                {
                                    label = item.Title,
                                    link = item.Url,
                                    current = Content.Current.Item == item || (Content.Current.Item != null && Content.Current.Item.Parent == item)
                                };
                    logger.Debug("item.GetChildren() == null -> {0}", item.GetChildren() == null);
                    if (item.GetChildren() != null && item.GetChildren().Count > 0)
                    {
                        var sublist = new List<JsvMenu>();
                        subitemNum = 0;
                        foreach (
                            var subitem in item.GetChildren().Where(p => p.Visible && !string.IsNullOrEmpty(p.Title)))
                        {
                            sublist.Add(new JsvMenu()
                                            {
                                                label = subitem.Title,
                                                link = subitem.Url
                                            });
                            subitemNum++;
                        }
                        i.subitems = sublist.ToArray();
                    }
                    rowNum++;
                    items.Add(i);
                }
                rowNum++;
            }
            catch (NullReferenceException nex)
            {
                // Bug caught
                logger.Debug("NullReferenceException in MenuJson last position was rowNum: {0}, itemNum: {1}, subItem: {2}", rowNum, itemNum, subitemNum);
                logger.Debug(nex.ToString());
                throw new ApplicationException("Oj något gick fel när meny skapades.");
            }
            catch (Exception ex)
            {
                logger.Debug("{2} in MenuJson last position was {0}, {1}", rowNum, subitemNum, ex.GetType().Name);
                logger.Debug(ex.ToString());
                throw new ApplicationException("Oj något gick fel när meny skapades.");
            }
            var result = JsonConvert.SerializeObject(items);
            logger.Debug("Html.MenuJson exit");
            return new MvcHtmlString(result);
        }

    }

}