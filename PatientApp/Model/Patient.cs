using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Model
{
    public class Patient
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public int PatientId { get; set; }
        public string LastName { get; set; }
        public string NhsNumber { get; set; }
        public virtual List<Episode> Episodes { get; set; }
    }
}
