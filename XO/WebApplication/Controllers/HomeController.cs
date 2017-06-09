using Newtonsoft.Json;
using System.Web.Mvc;
using WebApplication.Models;
using XO;


namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new StatisticsModels());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

         [HttpPost]
        public bool SaveGameInfo([System.Web.Http.FromBody]dynamic stat)
        {
            var newStat = JsonConvert.DeserializeObject<Statistcs>(stat.StatisticsList);
            return StatisticsModels.AddStatistics(newStat);
        }

        [HttpGet]
        public string GetGameInfo()
        {
            return JsonConvert.SerializeObject(new StatisticsModels().StatisticsList);
        }

    }
}