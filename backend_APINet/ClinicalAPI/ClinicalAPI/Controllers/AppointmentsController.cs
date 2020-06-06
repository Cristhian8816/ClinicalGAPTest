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
    public class AppointmentsController : ApiController
    {
        public IEnumerable<Appointment> GetAllAppointments()
        {
            UsersContext db = new UsersContext();
            var appointments = db.Appointments;
            return appointments;
        }

        public IHttpActionResult Getappointmentt(int Id)
        {
            UsersContext db = new UsersContext();
            var appointments = db.Appointments;
            var appointment = appointments.FirstOrDefault(a => a.AppointmentId == Id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UsersContext db = new UsersContext())
            {
                db.Appointments.Add(new Appointment()
                {
                    AppointmentId = appointment.AppointmentId,
                    PatientId = appointment.PatientId,
                    AppointmentType = appointment.AppointmentType,
                    Date = appointment.Date,                                  
                });

                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UsersContext db = new UsersContext())
            {
                var existingAppointment = db.Appointments.Where(a => a.AppointmentId == id)
                                                       .FirstOrDefault<Appointment>();

                if (existingAppointment != null)
                {
                    existingAppointment.AppointmentId = appointment.AppointmentId;
                    existingAppointment.PatientId = appointment.PatientId;
                    existingAppointment.AppointmentType = appointment.AppointmentType;
                    existingAppointment.Date = appointment.Date;                   

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult DeleteAppointment(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Patient id");

            using (UsersContext db = new UsersContext())
            {
                var appointment = db.Appointments
                    .Where(a => a.AppointmentId == id)
                    .FirstOrDefault();

                db.Appointments.Remove(appointment);
                db.SaveChanges();

            }
            return Ok();
        }
    }
}
