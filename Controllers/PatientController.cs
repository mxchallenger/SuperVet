using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SuperVet.DTOs;

namespace SuperVet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
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
            _logger.LogInformation("Request received for GetPatients");

            var patients = await _patientService.GetPatients();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult<PatientDTO> GetPatientById(int id)
        {
            _logger.LogInformation($"Request received for GetPatientByIdAsync for id: {id}");

            var patient = _patientService.GetPatientByIdAsync(id).Result;
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Ok(patientDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatientAsync([FromBody] PatientDTO newPatientObj)
        {
            var newPatient = _mapper.Map<Patient>(newPatientObj);

            _logger.LogInformation("Request received for CreatePatientAsync");

            var patient = await _patientService.CreatePatientAsync(newPatient);
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Created("/patients", patientDTO);
        }


        // TODO: [HttpPut]
        //[HttpPut]

        // TODO: [HttpDelete]
        //[HttpDelete]
    }
}

