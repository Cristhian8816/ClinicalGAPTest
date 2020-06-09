using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicalAPI.Models
{
    public class MigrationHistory
    {
        public string MigrationId { get; set; }
        public string Description { get; set; }
        public string ProductVersion { get; set; }      
    }
}