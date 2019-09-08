using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private readonly ToDoListContext _context;

        public ToDoListController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> Get()
        {
            //return new string[] { "value1", "value2" };
            return await _context.ToDoList
                            .Include( a => a.ToDoListItems)
                            .ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoList>> Get(long id)
        {
            //var toDoList = await _context.ToDoList.FindAsync(id);
            var toDoList = await _context.ToDoList
                                        .Include(a => a.ToDoListItems)
                                        .SingleOrDefaultAsync(a => a.Id == id);

            if (toDoList == null)
                return NotFound();

            return toDoList;
        }

        // GET api/<controller>/5/ListItems
        // Gets all list items from a particular list
        [HttpGet("{id}/ListItems")]
        public async Task<ActionResult<IEnumerable<ToDoListItem>>> GetListItems(long id)
        {
            var toDoListItems = await _context.ToDoListItem.Where(a => a.ToDoListId == id).ToListAsync();

            if (toDoListItems == null)
                return NotFound();

            return toDoListItems;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<ToDoList>> Post([FromBody]ToDoList list)
        {
            //Manually setting the ID because server not setting it, otherwise
            //returns 500 server error with duplicate id
            list.Id = _context.ToDoList.Max(a => a.Id) + 1;
            _context.ToDoList.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = list.Id }, list);
        }
        
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]string value)
        {
        }

        //[HttpPut("{id}/ListItems")]
        //public async Task<IActionResult> PutToDoItem(int id)
        //{

        //}

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
