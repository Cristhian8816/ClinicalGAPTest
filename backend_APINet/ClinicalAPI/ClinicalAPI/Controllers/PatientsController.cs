using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebAngularAPI.Models;
using System.Web.Http.Cors;

namespace WebAngularAPI.Controllers
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
    }
}
