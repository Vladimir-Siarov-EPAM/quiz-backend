using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend.DAL;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizContext context;


        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }


        // GET api/questions
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return this.context.Questions;
        }

        // POST api/questions
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Question question)
        {
            context.Questions.Add(question);
            await context.SaveChangesAsync();

            return Ok(question);
        }

        // PUT api/questions/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Question question)
        {
            // var dbQuestion = await this.context.Questions.SingleOrDefaultAsync(q => q.ID == id);

            if (id != question.ID)
                return BadRequest();

            this.context.Entry(question).State = EntityState.Modified;

            await this.context.SaveChangesAsync();

            return Ok(question);
        }
    }
}