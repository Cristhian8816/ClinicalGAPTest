using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicalAPI.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Date { get; set; }       
    }
}