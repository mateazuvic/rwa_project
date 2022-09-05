using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija.Models.customHtmlHelper
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString DDLPotkategorije(this HtmlHelper html, List<Potkategorija> potkategorije, int selected)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "Potk.IDPotkategorija");
            selectTag.MergeAttribute("name", "Potk.IDPotkategorija");
            selectTag.AddCssClass("form-control");

            foreach (Potkategorija p in potkategorije)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", p.IDPotkategorija.ToString());
                if (p.IDPotkategorija == selected)
                {
                    optionTag.MergeAttribute("selected", true.ToString());
                }
                optionTag.SetInnerText(p.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }

            return new MvcHtmlString(selectTag.ToString());
        }
    }
}