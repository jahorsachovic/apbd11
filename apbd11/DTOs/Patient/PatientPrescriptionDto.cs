namespace apbd11.DTOs;

public class PatientPrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public List<PatientMedicamentDto>? Medicaments { get; set; }
    public PatientDoctorDto Doctor { get; set; }
}
