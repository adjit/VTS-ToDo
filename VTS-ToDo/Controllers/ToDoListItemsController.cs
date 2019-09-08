using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListItemsController : ControllerBase
    {
        private readonly ToDoListContext _context;

        public ToDoListItemsController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: api/ToDoListItems
        [HttpGet]
        public IEnumerable<ToDoListItem> GetToDoListItem()
        {
            return _context.ToDoListItem;
        }

        // GET: api/ToDoListItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoListItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoListItem = await _context.ToDoListItem.FindAsync(id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            return Ok(toDoListItem);
        }

        // PUT: api/ToDoListItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoListItem([FromRoute] long id, [FromBody] ToDoListItem toDoListItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoListItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoListItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListItemExists(id))
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

        // POST: api/ToDoListItems
        [HttpPost]
        public async Task<IActionResult> PostToDoListItem([FromBody] ToDoListItem toDoListItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Manually setting the ID because server not setting it, otherwise
            //returns 500 server error with duplicate id
            toDoListItem.Id = _context.ToDoListItem.Max(a => a.Id) + 1;

            _context.ToDoListItem.Add(toDoListItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoListItem", new { id = toDoListItem.Id }, toDoListItem);
        }

        // DELETE: api/ToDoListItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoListItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoListItem = await _context.ToDoListItem.FindAsync(id);
            if (toDoListItem == null)
            {
                return NotFound();
            }

            _context.ToDoListItem.Remove(toDoListItem);
            await _context.SaveChangesAsync();

            return Ok(toDoListItem);
        }

        private bool ToDoListItemExists(long id)
        {
            return _context.ToDoListItem.Any(e => e.Id == id);
        }
    }
}