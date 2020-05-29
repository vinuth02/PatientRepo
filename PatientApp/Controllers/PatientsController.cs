using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientApp.Model;
using PatientApp.ViewModel;


namespace PatientApp.Controllers
{
    [Route("patients/{id?}/episodes")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApiContext _context;
        public PatientsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get(int Id)
        {
            //var patientsInMemory = new List<Patient>
            //    {
            //        new Patient
            //            {
            //                DateOfBirth = new DateTime(1972, 10, 27),
            //                FirstName = "Millicent",
            //                PatientId = 1,
            //                LastName = "Hammond",
            //                NhsNumber = "1111111111"
            //            }
            //    };

            //var episodesInMemory = new List<Episode>
            //    {
            //        new Episode
            //            {
            //                AdmissionDate = new DateTime(2014, 11, 12),
            //                Diagnosis = "Irritation of inner ear",
            //                DischargeDate = new DateTime(2014, 11, 27),
            //                EpisodeId = 1,
            //                PatientId = 1
            //            }
            //    };


            var patientsAndEpisodes =
                from p in _context.Patients
                join e in _context.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == Id
                select new Result{ Patient = p, Episode = e };

            if (patientsAndEpisodes == null)
            {
                return NotFound("Patient not found");
            }
            return Ok(patientsAndEpisodes);

        }
        
    }
}