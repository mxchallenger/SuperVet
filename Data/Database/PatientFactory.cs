using System;
using System.Text;
using System.Xml.Linq;

namespace SuperVet.Data
{
    public class PatientFactory
    {
        Random _rand = new();

        // randomly generated patient First Name
        private List<string> _patientFirst = new()
        {
            "Phillie",
            "Benny",
            "Mr",
            "Wally",
            "Jazz",
            "Puddles",
            "Raymond",
            "Bailey",
            "Rocky",
            "Brewers",
            "Jaxson",
            "Ralphie",
            "Vili",
            "Bevo",
            "Uga",
            "Nova",
            "Mike",
            "Dubs",
            "Reveille",
            "Rameses",
            "Sooner",
            "Traveler",
            "Lady",
        };
        private List<string> _patientAnimalType = new()
        {
            "Dog",
            "Cat",
            "Horse",
            "Bird",
            "Rodent",
            "Reptile",
            "Other"

        };
        private List<string> _patientSex = new()
        {
            "Male",
            "Female",
            "Unknown"
        };

        private List<string> _patientAltered = new()
        {
            "Altered",
            "Unaltered",
            "Unknown"
        };

        private string GetFirst() => _patientFirst[_rand.Next(0, _patientFirst.Count)];
        private string GetAnimalType() => _patientAnimalType[_rand.Next(0, _patientAnimalType.Count)];
        private string GetSex() => _patientSex[_rand.Next(0, _patientSex.Count)];
        private string GetAltered() => _patientAltered[_rand.Next(0, _patientAltered.Count)];

        private string GetRandomBirthdate()
        {
            var builder = new StringBuilder();
            builder.Append(_rand.Next(1, 13));
            builder.Append('-');
            builder.Append(_rand.Next(1, 32));
            builder.Append('-');
            builder.Append(_rand.Next(2000, 2023));

            return builder.ToString();
        }
        private string GetMicrochipId()
        {
            var builder = new StringBuilder();
            builder.Append(_rand.Next(10000, 100000));

            return builder.ToString();
        }


        // TODO: Add to model:
        // private int GetWeight() => _rand.Next(125, 350);

        public List<Patient> GetPatients(int qty)
        {
            return Enumerable.Range(1, qty)
            .Select(index => new Patient
            {
                Id = index,
                Name = GetFirst(),
                Type = GetAnimalType(),
                Sex = GetSex(),
                Altered = GetAltered(),
                MicrochipId = GetMicrochipId(),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            })
            .ToList();
        }

        private string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
};

