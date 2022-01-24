using Microsoft.AspNetCore.Mvc;
using MultipleLanguagesDictionary1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace MultipleLanguagesDictionary1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string word)
        {
            // // string replace = HttpContext.Session.GetString("replace");
            // try
            // {
            //     if (word == "" || word == null || word == " ")
            //     {
            //         string path = "https://api.dictionaryapi.dev/api/v2/entries/en/hello";

            //         object dictionary = getDictionary(path);

            //         JArray jArray = JArray.Parse(dictionary.ToString());

            //         IList<Dictionary> dictionaries = JsonConvert.DeserializeObject<IList<Dictionary>>(jArray.ToString());

            //         var meanings = dictionaries[0].meanings;

            //         var countDic = dictionaries.Count();

            //         var countPart = dictionaries[0].meanings.Select(s => s.partOfSpeech).Count();
            //         ViewBag.countPart = countPart;

            //         ViewBag.data = dictionaries;

            //         ViewBag.mean = meanings;

            //         ViewBag.count = countDic;

            //         return View();
            //     }
            //     else
            //     {
            //         string path = "https://api.dictionaryapi.dev/api/v2/entries/en/hello";
            //         string replace = path.Replace("hello", word);
            //         object dictionary = getDictionary(replace);

            //         JArray jArray = JArray.Parse(dictionary.ToString());

            //         IList<Dictionary> dictionaries = JsonConvert.DeserializeObject<IList<Dictionary>>(jArray.ToString());

            //         var meanings = dictionaries[0].meanings;

            //         var countDic = dictionaries.Count();

            //         var countPart = dictionaries[0].meanings.Select(s => s.partOfSpeech).Count();
            //         ViewBag.countPart = countPart;

            //         ViewBag.data = dictionaries;

            //         ViewBag.mean = meanings;

            //         ViewBag.count = countDic;
            //         return View();
            //     }
            // }catch(JsonReaderException e){
            //     ViewData["data"] = "null";
            //     ViewData["mean"] = "null";
            //     return View();
            // }
            return View();
        }

        public object getDictionary(string path)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    return JsonConvert.DeserializeObject<object>(
                        webClient.DownloadString(path)
                    );
                }
            }
            catch (WebException e)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}