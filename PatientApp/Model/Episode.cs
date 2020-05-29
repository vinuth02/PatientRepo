using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp.Model
{
    public class Episode
    {
        public DateTime AdmissionDate { get; set; }
        public string Diagnosis { get; set; }
        public DateTime DischargeDate { get; set; }
        public int EpisodeId { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
