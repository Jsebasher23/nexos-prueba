using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nexos_test.Contexts;
using nexos_test.Models;

namespace nexos_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacientesModel>>> GetPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacientesModel>> GetPacientesModel(int id)
        {
            var pacientesModel = await _context.Pacientes.FindAsync(id);

            if (pacientesModel == null)
            {
                return NotFound();
            }

            return pacientesModel;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacientesModel(int id, PacientesModel pacientesModel)
        {
            if (id != pacientesModel.PacienteID)
            {
                return BadRequest();
            }

            _context.Entry(pacientesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientesModelExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PacientesModel>> PostPacientesModel(PacientesModel pacientesModel)
        {
            using (var t = _context.Database.BeginTransaction())
            {
                _context.Pacientes.Add(pacientesModel);
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Doctores ON;");

                await _context.SaveChangesAsync();
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Doctores OFF;");
                t.Commit();

            }

            return CreatedAtAction("GetPacientesModel", new { id = pacientesModel.PacienteID }, pacientesModel);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PacientesModel>> DeletePacientesModel(int id)
        {
            var pacientesModel = await _context.Pacientes.FindAsync(id);
            if (pacientesModel == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(pacientesModel);
            await _context.SaveChangesAsync();

            return pacientesModel;
        }

        private bool PacientesModelExists(int id)
        {
            return _context.Pacientes.Any(e => e.PacienteID == id);
        }
    }
}
