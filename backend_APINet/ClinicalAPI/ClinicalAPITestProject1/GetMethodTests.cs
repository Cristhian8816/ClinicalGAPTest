using System;
using ClinicalAPI.Controllers;
using ClinicalAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;

namespace ClinicalAPITestProject1
{
    [TestClass]
    public class GetMethodTests
    {
        [TestMethod]
        public void TestGetpatient()
        {
            //Arrange
            var patientID = 1;
            PatientsController patientsController = new PatientsController();

            //Act 
            IHttpActionResult actionResult = patientsController.Getpatient(patientID);            

            //Assert
            Assert.IsNotNull(actionResult);                 
        }

        public void TestGetappointment()
        {
            //Arrange
            var appintmentID = 1;
            AppointmentsController appointmentController = new AppointmentsController();

            //Act 
            IHttpActionResult actionResult = appointmentController.Getappointmentt(appintmentID);

            //Assert
            Assert.IsNotNull(actionResult);
        }
    }
}
