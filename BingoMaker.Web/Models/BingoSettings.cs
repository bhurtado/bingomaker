using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoMaker.Web.Models
{
    public class BingoSettings
    {
        public string Font { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string FreeText { get; set; }

        [DataType(DataType.MultilineText)]
        public string WordListBlob { get; set; }

        public string[] WordList { get; set; }

        public int CardCount { get; set; }

        public BingoSettings()
        {
            this.Font = "Arial";
        }
    }
}