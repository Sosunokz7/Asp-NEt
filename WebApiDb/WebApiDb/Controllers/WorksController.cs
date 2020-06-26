using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDb.Models;

namespace WebApiDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly analysis_workersContext _context;

        public WorksController(analysis_workersContext context)
        {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWork()
        {
            return await _context.Work.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(uint id)
        {
            var work = await _context.Work.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(uint id, Work work)
        {
            if (id != work.IdWork)
            {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Works
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Work>> PostWork(Work work)
        {
            _context.Work.Add(work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.IdWork }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Work>> DeleteWork(uint id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Work.Remove(work);
            await _context.SaveChangesAsync();

            return work;
        }

        private bool WorkExists(uint id)
        {
            return _context.Work.Any(e => e.IdWork == id);
        }
    }
}
