using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI;
using QuizLibrary;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizDBController : Controller
    {
        private readonly CoreDatabaseContext _context;

        public QuizDBController(CoreDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DBQuestions
        [HttpGet]
        public IEnumerable<Question> GetQuestion()
        {
            //return _context.Question_set;
            return _context.Question
                           .FromSql("Select * from dbo.Question")
                           .ToList();
        }

        // GET: api/DBQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] int id)
        {
            var question=new Question();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var question = _context.Question_set
            //                        .FromSql($"Select * from Question where QuestionId = {id}")
            //                        .ToList()[0];
            try
            {
                question = _context.Question
                                        .FromSql($"GetBasicQuestionById {id}")
                                        .ToList()[0];
            }
            catch(Exception e)
            {
                return NoContent();
            }
            //var question = await _context.Question_set.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/QuizDB/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                var stat = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Forbid();
                }
            }

            return Ok();
        }

        // POST: api/DBQuestions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Question.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/DBQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId.Equals(id));
        }
    }
}