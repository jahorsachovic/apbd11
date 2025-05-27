using apbd11.DAL;
using apbd11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly PharmacyDbContext _dbContext;

    public PatientController(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var patients = await _dbContext.Patients.ToListAsync();
        
        return Ok(patients);
    }
    
    [HttpGet]
    
    
}