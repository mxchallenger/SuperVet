using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperVet.Models
{
    public class Encounter : BaseEntity
    {
        [Column("PatientId")]
        public int PatientId { get; set; }
        public string? ChiefComplaint { get; set; }
        public DateTime Date { get { return DateTime.Today; } }
        public string? Provider { get; set; }
        public string? PhysicalExamNotes { get; set; }
        public string? DiagnosticNotes { get; set; }
        public string? TreatmentPlan { get; set; }
        public double TotalCost { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public Encounter()
        {
            Patients = new List<Patient>();
        }
    }
}
