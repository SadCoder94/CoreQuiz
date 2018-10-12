using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVC.Models;
using QuizLibrary;
using System.Net;
using System.Net.Http;

namespace CoreMVC.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly CoreMVCContext _context;

        public QuestionsController(CoreMVCContext context)
        {
            _context = context;
        }

        // GET: Questions
        //public async Task<IActionResult> Index()
        //{
        //    var movies = from q in _context.Question
        //                 select q;

        //    return View(await movies.ToListAsync());
        //}

        public async Task<IActionResult> Index(string MVCQType, string id)
        {

            IQueryable<string> qTypeListQuery = from q in _context.Question
                                           orderby q.Question_type
                                           select q.Question_type;

            var questions = from q in _context.Question
                            select q;

            if (!String.IsNullOrEmpty(MVCQType))
            {
                questions = questions.Where(que=> que.Question_type==MVCQType);
            }

            if (!String.IsNullOrEmpty(id))
            {
                questions = questions.Where(que=>que.Question_statement.Contains(id));
            }

            var MVCQTypeVM = new MVCQTypeViewModel
            {
                Types = new SelectList(await qTypeListQuery.Distinct().ToListAsync()),
                questions = await questions.ToListAsync()
            };
            return View(MVCQTypeVM);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question_statement,Time,CorrectAnswer,Options,Question_type")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove((QuizLibrary.Question)question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(string id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}
