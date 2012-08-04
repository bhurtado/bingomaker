using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoMaker.Web.Models
{
    public class RenderModel
    {
        public string Font { get; set; }
        public HtmlString WordListHtml { get; set; }
        public HtmlString CardsHtml { get; set; }
    }
}