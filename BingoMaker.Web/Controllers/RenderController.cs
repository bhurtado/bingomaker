using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BingoMaker.Web.Models;

namespace BingoMaker.Web.Controllers
{
    public class RenderController : Controller
    {
        public ActionResult Index(BingoSettings settings)
        {
            settings.WordList = settings.WordListBlob.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).ToArray();

            var pageCount = settings.CardCount / 4;
            var pages = new StringBuilder();
            for (int i = 0; i < pageCount; i++)
            {
                pages.Append(string.Format(HtmlPage, GetSingleCardHtml(settings), GetSingleCardHtml(settings), GetSingleCardHtml(settings), GetSingleCardHtml(settings)));
            }
            var wordListPage = GetWordListPage(settings);
            return View(new RenderModel { Font = settings.Font, WordListHtml = new HtmlString(wordListPage), CardsHtml = new HtmlString(pages.ToString()) });
        }

        public string WordListPage =
    @"<div class='page'>
	<h1>Word list</h1>
	<ol class='wordList'>
	{0}
	</ol>
</div>";

        public string HtmlPage =
    @"<div class='page'>
	<table class='cards'>
		<tr>
			<td>
			{0}
			</td>
			<td>
			{1}
			</td>
		</tr>
		<tr>
			<td>
			{2}
			</td>
			<td>
			{3}
			</td>
		</tr>
	</table>
</div>";

        public string HtmlCard =
    @"<div class='card'>
	<h1>{0}</h1>
	<h2>{1}</h2>
	<table>
		{2}
	</table>
</div>";

        private Random random = new Random(Environment.TickCount);

        public string GetWordListPage(BingoSettings settings)
        {
            var words = new StringBuilder();

            foreach (var word in settings.WordList.OrderBy(w => w))
            {
                words.AppendFormat("<li class='word'>{0}</li>", word);
            }

            return string.Format(WordListPage, words.ToString());
        }

        public string GetSingleCardHtml(BingoSettings settings)
        {
            string rows = string.Empty;
            var words = GetWords(settings);
            for (int i = 0; i < 25; i++)
            {
                if (i % 5 == 0) rows += "<tr>";
                rows += "<td>" + words[i] + "</td>";
                if (i % 5 == 4) rows += "</tr>";
            }
            return string.Format(HtmlCard, settings.Title, settings.Subtitle, rows);
        }

        public string[] GetWords(BingoSettings settings)
        {
            var words = settings.WordList.TakeRandom(25).ToArray();
            words.Shuffle();
            words[12] = settings.FreeText;
            return words;
        }

    }
}
