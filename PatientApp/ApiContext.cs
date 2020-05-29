using Microsoft.EntityFrameworkCore;
using PatientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApp
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        public  DbSet<Patient> Patients { get; set; }

        public  DbSet<Episode> Episodes { get; set; }
    }
}
