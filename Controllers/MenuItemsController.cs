using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;

namespace MyStore.Controllers
{
    [Route("api/Menus")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly MyStoreContext _context;

        public MenuItemsController(MyStoreContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet("MenuItems")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Menus/1/MenuItems
        [HttpGet("{id}/MenuItems")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(long id)
        {
            var menuItem = await _context.Items.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // PUT: api/Menus/1/MenuItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}/MenuItems")]
        public async Task<IActionResult> PutMenuItem(long id, MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
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

        // POST: api/Menus/1/MenuItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("{id}/MenuItems")]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            _context.Items.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItem", new { id = menuItem.Id }, menuItem);
        }

        // DELETE: api/Menus/1/MenuItems
        [HttpDelete("{id}/MenuItems")]
        public async Task<ActionResult<MenuItem>> DeleteMenuItem(long id)
        {
            var menuItem = await _context.Items.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(menuItem);
            await _context.SaveChangesAsync();

            return menuItem;
        }

        private bool MenuItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
