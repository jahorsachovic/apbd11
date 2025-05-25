using apbd11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd11.DAL;

public class PharmacyDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }

    protected PharmacyDbContext()
    {
    }

    public PharmacyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seed tables
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@fake.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@fake.com"
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "K",
                LastName = "N",
                Birthdate = new DateTime(1998, 6, 5)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Gon",
                LastName = "Freecss",
                Birthdate = new DateTime(1987, 5, 5)
            }
            
            
            );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2020, 9, 9),
                DueDate = new DateTime(2021, 7, 7),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2015, 4, 4),
                DueDate = new DateTime(2018, 6, 6),
                IdPatient = 2,
                IdDoctor = 2
            }
            );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament
            {
                IdMedicament = 1,
                Name = "Cope",
                Description = "It's Cope",
                Type = "Inhaler"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Music",
                Description = "It's Music",
                Type = "Injection"
            }
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 5,
                Details = "Inhale two times daily before meal"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 6,
                Details = "Inject daily before sleep"
            }
            );
    }
}