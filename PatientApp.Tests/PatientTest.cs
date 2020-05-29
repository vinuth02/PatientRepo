using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PatientApp;
using PatientApp.Controllers;
using PatientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class PatientTests
    {
        Mock<ApiContext> mockDBContext = new Mock<ApiContext>();
        PatientsController controller = null;
        [SetUp]
        public void Setup()
        {
            var patientData = new List<Patient>
            {
                new Patient { DateOfBirth = new DateTime(1972, 10, 27),
                              FirstName = "Millicent",
                              PatientId = 1,
                              LastName = "Hammond",
                              NhsNumber = "1111111111" },
            }.AsQueryable();

            var episodeData = new List<Episode>
            {
                new Episode {   AdmissionDate = new DateTime(2014, 11, 12),
                                Diagnosis = "Irritation of inner ear",
                                DischargeDate = new DateTime(2014, 11, 27),
                                EpisodeId = 1,
                                PatientId = 1}
            }.AsQueryable();

            var mockSetPatient = new Mock<DbSet<Patient>>();
            mockSetPatient.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(patientData.Provider);
            mockSetPatient.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(patientData.Expression);
            mockSetPatient.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(patientData.ElementType);
            mockSetPatient.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(patientData.GetEnumerator());

            var mockSetEpisode = new Mock<DbSet<Episode>>();
            mockSetEpisode.As<IQueryable<Episode>>().Setup(m => m.Provider).Returns(episodeData.Provider);
            mockSetEpisode.As<IQueryable<Episode>>().Setup(m => m.Expression).Returns(episodeData.Expression);
            mockSetEpisode.As<IQueryable<Episode>>().Setup(m => m.ElementType).Returns(episodeData.ElementType);
            mockSetEpisode.As<IQueryable<Episode>>().Setup(m => m.GetEnumerator()).Returns(episodeData.GetEnumerator());
           
            mockDBContext.Setup(c => c.Patients).Returns(mockSetPatient.Object);
            mockDBContext.Setup(c => c.Episodes).Returns(mockSetEpisode.Object);

            controller = new PatientsController(mockDBContext.Object);
        }

        [Test]
        public void PatientValidResult()
        {
            IActionResult result = controller.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(ActionResult));
            Assert.Pass();
        }
        [Test]
        public void PatientInValidResult()
        {
            IActionResult result = controller.Get(20);
            //Assert
            var actual = result as BadRequestResult;
            Assert.NotNull(actual);
        }

    }
}