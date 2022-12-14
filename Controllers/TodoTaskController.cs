using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTodoAuth.Models;
using SimpleTodoAuth.SimpleTodoDbContext;

namespace SimpleTodoAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTaskModel>>> GetTodoTaskModel()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        // GET: api/TodoTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTaskModel>> GetTodoTaskModel(int id)
        {
            var todoTaskModel = await _context.TodoTasks.FindAsync(id);

            if (todoTaskModel == null)
            {
                return NotFound();
            }

            return todoTaskModel;
        }

        // PUT: api/TodoTask/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoTaskModel(int id, TodoTaskModel todoTaskModel)
        {
            if (id != todoTaskModel.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(todoTaskModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTaskModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoTask
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoTaskModel>> PostTodoTaskModel(TodoTaskModel todoTaskModel)
        {
            _context.TodoTasks.Add(todoTaskModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoTaskModel", new { id = todoTaskModel.TaskId }, todoTaskModel);
        }

        // DELETE: api/TodoTask/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoTaskModel>> DeleteTodoTaskModel(int id)
        {
            var todoTaskModel = await _context.TodoTasks.FindAsync(id);
            if (todoTaskModel == null)
            {
                return NotFound();
            }

            _context.TodoTasks.Remove(todoTaskModel);
            await _context.SaveChangesAsync();

            return todoTaskModel;
        }

        private bool TodoTaskModelExists(int id)
        {
            return _context.TodoTasks.Any(e => e.TaskId == id);
        }
    }
}
