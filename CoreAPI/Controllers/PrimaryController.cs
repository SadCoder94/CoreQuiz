using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuizLibrary;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryController : ControllerBase
    {
        public static QuizManager NewQuiz = new QuizManager();
        
        // GET: api/Primary
        [HttpGet]
        public IActionResult Get()
        {
            List<Question> NewList = NewQuiz.GetAllQuestions();
            if (NewList==null)
            {
                return NotFound();
            }
           
            return Ok(NewQuiz.GetAllQuestions());
        }

        // GET: api/Primary/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(String id)
        {
            Question GotQuestion = NewQuiz.GetQuestionById(id);
            if (GotQuestion==null)
            {
                return NotFound();
            }
            return Ok(GotQuestion);
        }

        // POST: api/Primary
        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            NewQuiz.AddQuestion(question);
            return CreatedAtAction("Added Question", question.Id);
        }
        
        // DELETE: api/Primary/Q_5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            NewQuiz.DeleteQuestion(id);
            return CreatedAtAction("Deleted Question", new {id=0});
        }
    }
}
