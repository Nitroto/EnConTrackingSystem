using System.Web.Mvc;

namespace EnConTrackingSystem.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Dropdown()
        {
            var list = new string[] { };
            ViewBag.languageList = new SelectList(list);
            return View();
        }
    }
}