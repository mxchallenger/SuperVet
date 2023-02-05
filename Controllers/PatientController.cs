using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SuperVet.DTOs;

namespace SuperVet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        private static List<Patient> patients = new List<Patient>
        {
            new Patient {
                Id = 1,
                Type ="Dog",
                Name = "Bailey",
                Sex = "Female",
                Birthdate = "Jan 29, 2006",
                Age = 15,
                Altered = "altered",
                MicrochipId = "000000",
                DateCreated = new DateTime(2001, 08, 10),
                DateModified = null,          
            },
            new Patient {
                Id = 2,
                Type ="Panda",
                Name = "Mei Mei",
                Sex = "Female",
                Birthdate = "Feb 20, 2006",
                Age = 15,
                Altered = "unaltered",
                DateCreated = new DateTime(2022, 08, 10),
                DateModified = null,
            },

        };

        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger, IMapper mapper)
        {
            _patientService = patientService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }

        // TODO: [HttpPost]

        // TODO: [HttpPut]

        // TODO: [HttpDelete]
    }
}

