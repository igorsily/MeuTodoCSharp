using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuTodo.Data;
using MeuTodo.Models;
using MeuTodo.Services;

namespace MeuTodo.Controllers
{
    [Route("api/v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/v1/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            var todos = await _todoService.FindAllTask();
            return Ok(todos);
        }

        // GET: api/v1/todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo([FromRoute] int id)
        {
            var todo = await _todoService.FindById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT:api/v1/todos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo([FromRoute] int id, [FromBody] Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            var status = await _todoService.UpdateTodo(todo);

            if (status == null) return BadRequest();

            return NoContent();
        }

        // POST:api/v1/todos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo([FromBody] Todo todo)
        {
            var todoCreated = await _todoService.CreateTodo(todo);


            return Created("/api/todos/" + todoCreated.Id, todoCreated);
        }

        // DELETE: api/v1/todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            await _todoService.DeleteTodo(id);
            return NoContent();
        }
    }
}