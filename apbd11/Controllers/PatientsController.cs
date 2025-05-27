using apbd11.DAL;
using apbd11.DTOs;
using apbd11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly PharmacyDbContext _dbContext;

    public PatientsController(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var patients = await _dbContext.Patients.ToListAsync(cancellationToken: cancellationToken);
        
        return Ok(patients);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatient(CancellationToken cancellationToken, int id)
    {
        
        var patient = await _dbContext
            .Patients
            .Where(p => p.IdPatient == id)
            .Select(p => new PatientWithPrescriptionsDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescriptions = p.Prescriptions
                                 .OrderBy(pr=> pr.DueDate)
                                 .Select(pr => new PatientPrescriptionDto
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new PatientMedicamentDto
                    {
                        IdMedicament = pm.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description
                    }).ToList(),
                    Doctor = new PatientDoctorDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName
                    }
                }).ToList()
            }).SingleOrDefaultAsync(cancellationToken);
        
        if (patient == null)
        {
            return NotFound($"Patient with Id {id} was not found.");
        }
            
        return Ok(patient);
    }
    
    
}