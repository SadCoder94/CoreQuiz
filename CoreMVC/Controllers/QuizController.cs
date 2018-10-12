using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using QuizLibrary;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreMVC.Controllers
{
    public class QuizController : Controller
    {
        readonly string BaseURL = "https://localhost:44347/";
        HttpClient client;
        private IQuiz _Quiz; 
        public QuizController(IQuiz Quiz)
        {
            _Quiz = Quiz;
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //GET: Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Question> questions = new List<Question>();
            //_Quiz.
            HttpResponseMessage res = await client.GetAsync("api/QuizJSON");

            if (res.IsSuccessStatusCode)
            {
                    var response = res.Content.ReadAsStringAsync().Result;
                    questions = JsonConvert.DeserializeObject<List<Question>>(response);
            }

            return View(questions);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage res =  await client.GetAsync("api/QuizJSON/"+id);
            Question question=new Question();
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                question = JsonConvert.DeserializeObject<Question>(response);
            }

            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Question_statement,Time,CorrectAnswer,Options,Question_type")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }
   
            if (ModelState.IsValid)
            {
                var resultContent = await client.PutAsJsonAsync<JObject>("api/QuizJSON", JObject.FromObject(question));
                if (resultContent.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
            //return View(question);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question_statement,Time,CorrectAnswer,Options,Question_type")] Question question)
        {
            var content = JsonConvert.SerializeObject(question);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (ModelState.IsValid)
            {
                var resultContent = await client.PostAsync("api/QuizJSON", byteContent);
                return RedirectToAction("Index", "Quiz");
            }
            
            return View(question);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
            
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult Looper(string toLoop="nothing",int numTimes=1)
        {
            ViewData["Message"] = toLoop;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
