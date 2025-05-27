using apbd11.DAL;
using apbd11.DTOs.Prescription;
using apbd11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly PharmacyDbContext _dbContext;

    public PrescriptionsController(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Test endpoint
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var prescriptions = await _dbContext.Prescriptions.ToListAsync(cancellationToken);
        return Ok(prescriptions);
    }

    [HttpPost]
    public async Task<IActionResult> Post(NewPrescriptionDto request, CancellationToken cancellationToken)
    {

        if (request.Date > request.DueDate)
        {
            return BadRequest("DueDate must be after Date.");
        }

        if (request.PrescriptionMedicaments.ToList().Count > 10)
        {
            return BadRequest("Prescription can not be for more than 10 medicaments.");
        }

        foreach (var medicament in request.PrescriptionMedicaments.ToList())
        {
            var existingMedicament = await _dbContext.Medicaments.
                SingleOrDefaultAsync(m => m.IdMedicament == medicament.IdMedicament, cancellationToken: cancellationToken);

            if (existingMedicament == null)
            {
                return BadRequest($"There is no medicament with Id {medicament.IdMedicament}.");
            }
        }
        
        var existingPatient = await _dbContext.Patients
            .SingleOrDefaultAsync(p => p.IdPatient == request.Patient.IdPatient, cancellationToken);

        if (existingPatient == null)
        {
            var newPatient = new Patient
            {
                IdPatient = request.Patient.IdPatient,
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };

            var connection = _dbContext.Database.GetDbConnection();
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Patients ON", cancellationToken);
            await _dbContext.Patients.AddAsync(newPatient, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Patients OFF", cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        
        var prescription = new Prescription()
        {
            IdPatient = request.Patient.IdPatient,
            IdDoctor = request.IdDoctor,
            PrescriptionMedicaments = request.PrescriptionMedicaments.Select(m => new PrescriptionMedicament()
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Details = m.Details
            }).ToList(),
            Date = request.Date,
            DueDate = request.DueDate,
        };

        
        
        await _dbContext.Prescriptions.AddAsync(prescription, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok();
    }
}