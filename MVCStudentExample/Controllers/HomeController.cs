using CountriesMVC.NETDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountriesMVC.NETDemo.Controllers
{
    public class HomeController : Controller
    {
        private CountriesRepository cr = new CountriesRepository(new CountriesContext());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MapChart()
        {
            var list = cr.getBarChartData();
            return Json(list);
        }
        public ActionResult BarChart()
        {
            var list = cr.getBarChartData();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TableChart()
        {
            var list = cr.getTableChartData();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PieChart()
        {
            var list = cr.getPieChartData();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}