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
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly MyStoreContext _context;

        public TimeSheetsController(MyStoreContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> GetTimeSheets()
        {
            return await _context.TimeSheets.ToListAsync();
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(long id)
        {
            var timeSheet = await _context.TimeSheets.FindAsync(id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            return timeSheet;
        }

        // PUT: api/TimeSheets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheet(long id, TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
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

        // POST: api/TimeSheets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> PostTimeSheet(TimeSheet timeSheet)
        {
            _context.TimeSheets.Add(timeSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSheet", new { id = timeSheet.Id }, timeSheet);
        }

        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSheet>> DeleteTimeSheet(long id)
        {
            var timeSheet = await _context.TimeSheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            _context.TimeSheets.Remove(timeSheet);
            await _context.SaveChangesAsync();

            return timeSheet;
        }

        private bool TimeSheetExists(long id)
        {
            return _context.TimeSheets.Any(e => e.Id == id);
        }
    }
}
