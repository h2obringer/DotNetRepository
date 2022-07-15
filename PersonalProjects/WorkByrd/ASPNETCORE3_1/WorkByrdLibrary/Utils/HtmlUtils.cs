using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace WorkByrdLibrary.Utils
{
    public class HtmlUtils
    {
        public class HtmlSelectElement
        {
            public HtmlSelectElement(object htmlAttributes)
            {
                if (htmlAttributes == null)
                {
                    return;
                }

                object token = "";

                RouteValueDictionary map = AnonymousObjectToHtmlAttributes(htmlAttributes);

                if (map.TryGetValue("class", out token))
                {
                    @class = token.ToString();
                    if (!@class.Contains("workbyrd-dropdown")) //default class
                    {
                        @class += " workbyrd-dropdown";
                    }
                    if (!@class.Contains("form-control")) //default class
                    {
                        @class += " form-control";
                    }

                }
                else
                {
                    @class = "workbyrd-dropdown form-control"; //default classes
                }

                if (map.TryGetValue("disabled", out token))
                {
                    disabled = token.ToString();
                }

                if (map.TryGetValue("required", out token))
                {
                    required = token.ToString();
                }
            }

            public string @class { get; set; }
            public string disabled { get; set; }
            public string required { get; set; }
        }

        public static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            RouteValueDictionary result = new RouteValueDictionary();

            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }

            return result;
        }

        //extension method
        public static IHtmlContent WorkByrdDropDownList(string id, IEnumerable<SelectListItem> items, bool isrequired, object htmlAttributes)
        {
            HtmlSelectElement element = new HtmlSelectElement(htmlAttributes);

            StringBuilder html = new StringBuilder();
            html.Append($"<select id=\"{id}\" name=\"{id}\"");

            if (!string.IsNullOrWhiteSpace(element.@class))
            {
                html.Append($" class=\"{element.@class}\"");
            }

            if (!string.IsNullOrWhiteSpace(element.disabled))
            {
                html.Append($" disabled=\"{element.disabled}\"");
            }

            if (!string.IsNullOrWhiteSpace(element.required) || isrequired)
            {
                html.Append($" required=\"{element.required}\"");
            }

            html.Append(">");

            if(items == null)
            {
                html.Append($"<option value=\"\" selected=\"\"></option>");
            }
            else
            {
                foreach (SelectListItem item in items)
                {
                    html.Append($"<option value=\"{item.Value}\"");
                    if (item.Selected)
                    {
                        html.Append(" selected=\"selected\"");
                    }                    
                    html.Append($">{item.Text}</option>");
                }
            }
            html.Append("</select>");

            return new HtmlString(html.ToString());
        }
    }
}