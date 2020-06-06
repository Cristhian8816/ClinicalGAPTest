using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ClinicalAPI.Models;
using System.Web.Http.Cors;

namespace ClinicalAPI.Controllers
{   
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        public IEnumerable<Patient> GetAllPatients()
        {
            UsersContext db = new UsersContext();
            var patients = db.Patients;
            return patients;
        }

        public IHttpActionResult Getpatient(int Id)
        {
            UsersContext db = new UsersContext();
            var patients = db.Patients;
            var patient = patients.FirstOrDefault((p) => p.PatientId == Id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        public IHttpActionResult PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UsersContext db = new UsersContext())
            {
                db.Patients.Add(new Patient()
                {
                    PatientId = patient.PatientId,
                    Name = patient.Name,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address                    
                });

                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UsersContext db = new UsersContext())
            {
                var existingPatient = db.Patients.Where(p => p.PatientId == id)
                                                       .FirstOrDefault<Patient>();

                if (existingPatient != null)
                {
                    existingPatient.PatientId = id;
                    existingPatient.Name = patient.Name;
                    existingPatient.PhoneNumber = patient.PhoneNumber;
                    existingPatient.Address = patient.Address;                  

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult DeletePatient(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Patient id");

            using (UsersContext db = new UsersContext())
            {
                var Patient = db.Patients
                    .Where(p => p.PatientId == id)
                    .FirstOrDefault();

                db.Patients.Remove(Patient);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
