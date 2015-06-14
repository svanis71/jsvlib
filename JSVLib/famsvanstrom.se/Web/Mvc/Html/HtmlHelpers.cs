// // famsvanstrom.se: HtmlHelpers.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using famsvanstrom.se.Svanstrom;

#endregion

namespace famsvanstrom.se.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static IHtmlString LightbulbCheckboxFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
                                                                          Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null)
        {
            var section = new TagBuilder("section");
            var inputBuilder = new TagBuilder("input");
            var model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var rnd = new Random();

            string id = "checkbox_" + rnd.Next();
            string title = string.Empty;

            if (htmlAttributes != null)
                inputBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            title = inputBuilder.Attributes["title"];

            inputBuilder.Attributes.Add("type", "checkbox");
            if (model.Model is DeviceStatus)
            {
                if((DeviceStatus)model.Model == DeviceStatus.On)
                    inputBuilder.Attributes.Add("checked", "");
            }
            else if(model.Model is bool)
            {
                if ((bool)model.Model)
                    inputBuilder.Attributes.Add("checked", "");
            }
            else
            {
                throw new ArgumentException("Model must be of type DeviceStatus or bool.");
            }

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

            var html = new StringBuilder(inputBuilder.ToString(TagRenderMode.SelfClosing));
            html.Append(labelBuilder.ToString());

            section.InnerHtml = html.ToString();
            section.AddCssClass("lightbulb-container");
            return new MvcHtmlString(section.ToString());
        }
    }
}