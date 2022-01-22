using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultipleLanguagesDictionary1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace MultipleLanguagesDictionary1.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class DictionaryController : Controller
    {
        private readonly ILogger<DictionaryController> _logger;

        public DictionaryController(ILogger<DictionaryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string path = "https://api.dictionaryapi.dev/api/v2/entries/en/dog";
            object dictionary = getDictionary(path);

            // object dictionary = (Array)getDictionary(path);

            // JObject jObject = JObject.Parse(dictionary.ToString());

            // JArray jArray = JArray.Parse(dictionary.ToString());

            // ViewBag.data = jObject["meanings"];

            var value = JArray.Parse(dictionary.ToString()).Children()["meanings"][0]["definitions"][0]["definition"].First();

            ViewBag.data = value;

            return View();
        }

        public object getDictionary(string path)
        {
            
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<object>(
                    webClient.DownloadString(path)
                );
            }

        }


    }
}