using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoctorPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            DoctorPatientContext db = new DoctorPatientContext();

            db.Doctor.Add(new Doctor()
            {
                DegreeEarned = DateTime.Now,
                FirstName = "Sam",
                LastName = "Smith",
                Url = "http://SamSmithMD.on.ca"
            });
            db.SaveChanges();

            db.Patient.Add(new Patient()
            {
                FirstName = "Chris",
                LastName = "Car",
                Doctor = db.Doctor.FirstOrDefault(doctor => doctor.LastName == "Smith"),
                Title = "Mr"
            });
            db.SaveChanges();


        }

        [Table("Person")]
        public class Person
        {
            [Key]
            [Required]
            //[Range(10000, int.MaxValue)]
            public int PersonID { get; set; }
            [MaxLength(30, ErrorMessage = "ErrorMessage", ErrorMessageResourceName = "ErrorMessageResourceName")]
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Table("Doctor")]
        public class Doctor : Person
        {
            public DateTime DegreeEarned { get; set; }
            public string Url { get; set; }
            public virtual List<Patient> Patients { get; set; }
        }

        [Table("Patient")]
        public class Patient : Person
        {
            public int PatientId { get; set; }
            public string Title { get; set; }
            public virtual Doctor Doctor { get; set; }
        }

        public class DoctorPatientContext : DbContext
        {
            public DoctorPatientContext() : base("Name=MyEntities")
            {
                // Not using (LocalDB)\MSSQLLocalDB
                // Delete this constructor to use the system default
            }
            public DbSet<Person> Person { get; set; }
            public DbSet<Doctor> Doctor { get; set; }
            public DbSet<Patient> Patient { get; set; }
        }
    }
}
