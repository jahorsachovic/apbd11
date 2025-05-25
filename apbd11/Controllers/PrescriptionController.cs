using apbd11.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd11.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
}