using Newtonsoft.Json;
using PhongTot.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PhongTot.Web.Controllers
{
    public class HomeController : Controller
    {
        RoomsEntities db = new RoomsEntities();
        HttpClient client;
        string url = "http://localhost:33029/api";
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {
            //HttpResponseMessage response = client.GetAsync(url + "/info/getall").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseString = response.Content.ReadAsStringAsync().Result;
            //    var info = JsonConvert.DeserializeObject<List<InfoModel>>(responseString);
            //    return View(info);
            //}
            return View();
        }
        public ActionResult Category(int id)
        {
            return View();
        }
        public PartialViewResult _Header()
        {
            return PartialView();
        }
    }
}