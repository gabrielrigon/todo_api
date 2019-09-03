using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoApi.Models;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
      _context = context;

      if (_context.TodoItems.Count() == 0)
      {
        _context.TodoItems.Add(new TodoItem { Name = "Item 1" });
        _context.SaveChanges();
      }
    }

    // GET: api/Todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
    {
      return await _context.TodoItems.ToListAsync();
    }
  }
}