namespace apbd11.DTOs;

public class PatientWithPrescriptionsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public List<PatientPrescriptionDto>? Prescriptions { get; set; }
}
