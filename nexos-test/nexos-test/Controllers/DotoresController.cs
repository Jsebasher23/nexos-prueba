using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nexos_test.Contexts;
using nexos_test.Models;

namespace nexos_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public DotoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctoresModel>>> Get()
        {
            return await context.Doctores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctoresModel>> GetDoctorDetail(int id)
        {
            var doctorDetail = await context.Doctores.FindAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }
            return doctorDetail;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorDetail(int id, DoctoresModel doctor)
        {
            if (id != doctor.DoctorID)
            {
                return BadRequest();
            }

            context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        [HttpPost]
        public async Task<ActionResult<DoctoresModel>> PostPaymentDetail(DoctoresModel doctorDetail)
        {
            context.Doctores.Add(doctorDetail);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = doctorDetail.DoctorID }, doctorDetail);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            var doctorDetail = await context.Doctores.FindAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            context.Doctores.Remove(doctorDetail);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return context.Doctores.Any(e => e.DoctorID == id);
        }

    }
}
