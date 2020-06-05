using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAngularAPI.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }       
    }
}