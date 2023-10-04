using CDS_Hooks.DBContext;
using CDS_Hooks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CDS_Hooks.Controllers
{
    
    [ApiController]
    [Route("api/cds-services")]
    public class CdsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Services>>> GetCdsServices()
        {
            var services = await _context.Services
                .Include(s => s.Prefetch) 
                .ToListAsync();

            return Ok(services);
        }


        [HttpPost]
        public async Task<ActionResult<Services>> PostCdsService(Services services)
        {
            if (services != null)
            {
                var res = new Services
                {
                    Description = services.Description,
                    Hook = services.Hook,
                    Id = services.Id,
                    Title = services.Title,
                    UsageRequirements = services.UsageRequirements,
                    Prefetch = new Prefetch
                    {
                        Id = services.Prefetch.Id,
                        Medications = services.Prefetch.Medications,
                        PatientToGreet = services.Prefetch.PatientToGreet,
                        Patient = services.Prefetch.Patient
                    }
                };

                if (res != null) 
                {
                    await _context.Services.AddAsync(res);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("PostCdsService", new { id = res.Id }, res);
                }
                else
                {
                    return StatusCode(500, "Internal Server Error: Database context is null.");
                }
            }
            else
            {
                return BadRequest();
            }
        }

      
    }
}
