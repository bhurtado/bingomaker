using System.Linq;
using System.Web.Mvc;
using BingoMaker.Web.Models;

namespace BingoMaker.Web.Controllers
{
    public class HomeController : Controller
    {
        public static string[] Fonts = {
            "cursive",
            "monospace",
            "serif",
            "sans-serif",
            "fantasy",
            "Arial",
            "Arial Black",
            "Arial Narrow",
            "Bookman Old Style",
            "Bradley Hand ITC",
            "Century",
            "Century Gothic",
            "Comic Sans MS",
            "Courier",
            "Courier New",
            "Georgia",
            "Impact",
            "Lucida Console",
            "Monotype Corsiva",
            "Papyrus",
            "Tahoma",
            "Times",
            "Times New Roman",
            "Trebuchet MS",
            "Verdana"
        };

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var settings = new BingoSettings();

            settings.Fonts = Fonts.Select(f => new SelectListItem() { Text = f, Value = f });

            return View(settings);
        }
    }
}
