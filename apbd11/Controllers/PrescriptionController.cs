using apbd11.DAL;
using apbd11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private PharmacyDbContext _dbContext;

    public PrescriptionController(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var prescriptions = await _dbContext.Prescriptions.ToListAsync(cancellationToken);
        return Ok(prescriptions);
    }
}