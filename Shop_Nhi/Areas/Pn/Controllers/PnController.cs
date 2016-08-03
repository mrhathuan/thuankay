using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Nhi.Areas.Pn.Controllers
{
    public class PnController : BaseController
    {
        //
        // GET: /Pn/Pn/
        public ActionResult Index()
        {
            return View();
        }

        //Top left
        [ChildActionOnly]
        public ActionResult _TopLeft()
        {
            return PartialView();
        }

        //menu left
        [ChildActionOnly]
        public ActionResult _MenuLeft()
        {
            return PartialView();
        }

        //menu left
        [ChildActionOnly]
        public ActionResult _TopAdmin()
        {
            return PartialView();
        }
	}
}