using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultipleLanguagesDictionary1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultipleLanguagesDictionary1.Controllers
{
    [Authorize(Roles = RoleName.Member)]
    [Route("/Dictionary/[action]")]
    public class DictionaryController : Controller
    {
        private readonly ILogger<DictionaryController> _logger;

        public DictionaryController(ILogger<DictionaryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string? word)
        {
            try
            {
                if (word == "" || word == null || word == " ")
                {
                    string path = "https://api.dictionaryapi.dev/api/v2/entries/en/hello";

                    object dictionary = getDictionary(path);

                    JArray jArray = JArray.Parse(dictionary.ToString());

                    IList<Dictionary> dictionaries = JsonConvert.DeserializeObject<IList<Dictionary>>(jArray.ToString());

                    var meanings = dictionaries[0].meanings;

                    var countDic = dictionaries.Count();

                    var countPart = dictionaries[0].meanings.Select(s => s.partOfSpeech).Count();
                    ViewBag.countPart = countPart;

                    ViewBag.data = dictionaries;

                    ViewBag.mean = meanings;

                    ViewBag.count = countDic;

                    return View();
                }
                else
                {
                    string path = "https://api.dictionaryapi.dev/api/v2/entries/en/hello";
                    string replace = path.Replace("hello", word);
                    object dictionary = getDictionary(replace);

                    JArray jArray = JArray.Parse(dictionary.ToString());

                    IList<Dictionary> dictionaries = JsonConvert.DeserializeObject<IList<Dictionary>>(jArray.ToString());

                    var meanings = dictionaries[0].meanings;

                    var countDic = dictionaries.Count();

                    var countPart = dictionaries[0].meanings.Select(s => s.partOfSpeech).Count();
                    ViewBag.countPart = countPart;

                    ViewBag.data = dictionaries;

                    ViewBag.mean = meanings;

                    ViewBag.count = countDic;
                    return View();
                }
            }catch(JsonReaderException e){
                ViewData["data"] = "null";
                ViewData["mean"] = "null";
                return View();
            }
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
                return RedirectToAction("Index", "Dictionary");
            }

        }

        public string getWord(string word)
        {
            string path = "https://api.dictionaryapi.dev/api/v2/entries/en/word";
            string replace = path.Replace("word", word);
            return replace;
        }

    }
}