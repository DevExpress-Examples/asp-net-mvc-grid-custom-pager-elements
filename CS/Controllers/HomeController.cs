using System;
using System.Web.Mvc;

namespace T155783.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial() {
            return PartialView(NorthwindDataProvider.GetProducts());
        }

        public ActionResult GridViewCallbackPartial(int? pageSize) {
            ViewData["pageSize"] = pageSize;
            return PartialView("GridViewPartial", NorthwindDataProvider.GetProducts());
        }

        public ActionResult FooterRowPartial() {
            return PartialView();
        }
    }
}