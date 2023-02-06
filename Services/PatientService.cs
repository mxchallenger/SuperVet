using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Data.Filters;
using SuperVet.DTOs;
using AutoMapper;

namespace SuperVet.Services
{
	public class PatientService : IPatientService
	{
		private readonly VetContext _ctx;
        private readonly IMapper _mapper;

		public PatientService(VetContext ctx, IMapper mapper)
		{
            _ctx = ctx;
		}

		public async Task<IEnumerable<Patient>> GetPatients()
		{
			return await _ctx.Patients
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToListAsync();
		}

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _ctx.Patients
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            if (patient == null)
                return null;

            return patient;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _ctx.Patients.Add(patient);
            await _ctx.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> UpdatePatientByIdAsync(Patient newPatient, int id)
        {
            var patient = await _ctx.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return null;
            }

            patient.Id = id;
            patient.DateModified = DateTime.UtcNow;
            patient.Name = newPatient.Name;
            patient.Type = newPatient.Type;
            patient.Age = newPatient.Age;
            patient.Sex = newPatient.Sex;
            patient.Birthdate = newPatient.Birthdate;
            patient.Age = newPatient.Age;
            patient.Altered = newPatient.Altered;
            patient.MicrochipId = newPatient.MicrochipId;

            await _ctx.SaveChangesAsync();
            return patient;
        }
        public async Task DeletePatientByIdAsync(int id)
        {
            var existingPatient = await GetPatientByIdAsync(id);

            if (existingPatient == null)
            {
                throw new ArgumentException("Patient with the specified ID was not found.");
            }

            _ctx.Patients.Remove(existingPatient);
            await _ctx.SaveChangesAsync();
        }

    }
}

