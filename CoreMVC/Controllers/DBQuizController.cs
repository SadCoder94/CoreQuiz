﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using CoreAPI;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Web;

namespace CoreMVC.Controllers
{
    public class DBQuizController : Controller
    {
        private readonly IDBClient _client;

        public DBQuizController(IDBClient client)
        {
            _client = client;
        }

        //GET: Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Question> questions = new List<Question>();
            HttpResponseMessage res = await _client.GetData(@"/api/QuizDB");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                questions = JsonConvert.DeserializeObject<List<Question>>(response);
            }

            return View(questions);

        }

        // GET: api/DBQuiz/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage res = await _client.GetDataEdit(String.Format(@"/api/QuizDB/{0}",id));
            Question question = new Question();
            if (res.IsSuccessStatusCode)
            {
                string response = res.Content.ReadAsStringAsync().Result;
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
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,Question_statement,Time,CorrectAnswer,Options,Question_type,QuizId")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resultContent = await _client.PutAsJsonAsync<Question>(String.Format(@"/api/QuizDB/{0}", id), question);
                if (resultContent.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Question() { Time=DateTime.UtcNow});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuizId,Question_statement,Time,CorrectAnswer,Options,Question_type")] Question question)
        {
            if (ModelState.IsValid)
            {
                var resultContent = await _client.PostAsync("api/QuizDB", question);
                if (resultContent.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "DBQuiz");
                }
                return RedirectToAction("Create", "DBQuiz");
            }

            return View(question);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            HttpResponseMessage res = await _client.PostAsync(String.Format(@"/api/QuizDB/{0}", id));
            Question question = new Question();
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            if (ModelState.IsValid)
            {
                var resultContent = await _client.PostAsync(String.Format(@"/api/QuizDB/{0}", id));
                if (resultContent.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult QuizReport()
        {
            return Ok();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Basic application showing implementation of MVC, Web API and EntityFramework.";

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
