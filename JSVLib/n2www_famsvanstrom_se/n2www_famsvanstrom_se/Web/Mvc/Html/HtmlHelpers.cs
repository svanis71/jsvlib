using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace n2www_famsvanstrom.se.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static IHtmlString LightbulbCheckboxFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
                                                                          Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> htmlAttributes = null)
        {
            var inputBuilder = new TagBuilder("input");
            var model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var rnd = new Random();

            string id = "checkbox_" + rnd.Next();
            string title = string.Empty;

            if (htmlAttributes != null) 
                inputBuilder.MergeAttributes(htmlAttributes);
            title = inputBuilder.Attributes["title"];

            inputBuilder.Attributes.Add("type", "checkbox");
            if((bool)model.Model)
                inputBuilder.Attributes.Add("checked", "");

            inputBuilder.AddCssClass("lightbulb");
            
            if (!inputBuilder.Attributes.ContainsKey("id"))
                inputBuilder.Attributes.Add("id", id);
            else
                id = inputBuilder.Attributes["id"];

            
            var labelBuilder = new TagBuilder("label");
            labelBuilder.Attributes.Add("for", id);

            var titleBuilder = new TagBuilder("span");
            titleBuilder.SetInnerText(title);

            labelBuilder.InnerHtml = titleBuilder.ToString();

            var html = new StringBuilder(inputBuilder.ToString());
            html.Append(labelBuilder.ToString());
            return new MvcHtmlString(html.ToString());
        }
    }
}