using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        public async Task<ActionResult<PatientDTO>> GetPatientById(int id)
        {
            _logger.LogInformation($"Request received for GetPatientByIdAsync for id: {id}");

            var patient = await _patientService.GetPatientByIdAsync(id);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDTO>> UpdatePatientByIdAsync(Patient patient, int id)
        {
            _logger.LogInformation("Request received for UpdatePatientByIdAsync");
            try
            {
                var updatedPatient = await _patientService.UpdatePatientByIdAsync(patient, id);
                var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);
                return Ok(updatedPatient);
            }
            catch (System.ArgumentNullException)
            {
                return NotFound($"No patient with ID: {id} exists in the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDTO>> DeletePatient(int id)
        {
            _logger.LogInformation("Request received for DeletePatient");

            try
            {
                await _patientService.DeletePatientByIdAsync(id);
                return Ok();

            }
            catch (Exception)
            {
                return NotFound();

            }
        }
    }
}