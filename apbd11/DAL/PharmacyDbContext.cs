using apbd11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd11.DAL;

public class PharmacyDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected PharmacyDbContext()
    {
    }

    public PharmacyDbContext(DbContextOptions options) : base(options)
    {
    }
    
}