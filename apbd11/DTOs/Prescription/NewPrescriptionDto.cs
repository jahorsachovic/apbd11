namespace apbd11.DTOs.Prescription;

public class NewPrescriptionDto
{
    public PrescriptionPatientDto Patient { get; set; }
    public int IdDoctor { get; set; }

    public List<PrescriptionMedicamentDto>? PrescriptionMedicaments { get; set; }
    
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}