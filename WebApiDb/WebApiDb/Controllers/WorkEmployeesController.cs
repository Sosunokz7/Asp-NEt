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
    public class WorkEmployeesController : ControllerBase
    {
        private readonly analysis_workersContext _context;

        public WorkEmployeesController(analysis_workersContext context)
        {
            _context = context;
        }

        // GET: api/WorkEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkEmployee>>> GetWorkEmployee()
        {
            return await _context.WorkEmployee.ToListAsync();
        }

        // GET: api/WorkEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkEmployee>> GetWorkEmployee(uint id)
        {
            var workEmployee = await _context.WorkEmployee.FindAsync(id);

            if (workEmployee == null)
            {
                return NotFound();
            }

            return workEmployee;
        }

        // PUT: api/WorkEmployees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkEmployee(uint id, WorkEmployee workEmployee)
        {
            if (id != workEmployee.IdEmploye)
            {
                return BadRequest();
            }

            _context.Entry(workEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkEmployeeExists(id))
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

        // POST: api/WorkEmployees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkEmployee>> PostWorkEmployee(WorkEmployee workEmployee)
        {
            _context.WorkEmployee.Add(workEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkEmployee", new { id = workEmployee.IdEmploye }, workEmployee);
        }

        // DELETE: api/WorkEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkEmployee>> DeleteWorkEmployee(uint id)
        {
            var workEmployee = await _context.WorkEmployee.FindAsync(id);
            if (workEmployee == null)
            {
                return NotFound();
            }

            _context.WorkEmployee.Remove(workEmployee);
            await _context.SaveChangesAsync();

            return workEmployee;
        }

        private bool WorkEmployeeExists(uint id)
        {
            return _context.WorkEmployee.Any(e => e.IdEmploye == id);
        }
    }
}
