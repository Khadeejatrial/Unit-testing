using Microsoft.AspNetCore.Mvc;
using Moq;
using Unit_testing.trial.Controllers;
using Unit_testing.trial.Contracts;
using Unit_testing.trial.Models;

namespace Unit_testing.Tests.APIControllerTests
{
    [TestClass]
    public class EligibilityControllerTests
    {
        private Mock<IEligibilityServices> _mockEligibilityService = null!;
        private Mock<IQualification> _mockQualificationService = null!;
        private EligibilityController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockEligibilityService = new Mock<IEligibilityServices>();
            _mockQualificationService = new Mock<IQualification>();

            _controller = new EligibilityController(_mockEligibilityService.Object, _mockQualificationService.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockEligibilityService.VerifyAll();
            _mockQualificationService.VerifyAll();
        }

        [TestMethod]
        public void CheckApplicant_ValidData_ReturnsOk()
        {
            // Arrange
            var applicant = new Applicant
            {
                Name = "John Doe",
                Age = 25,
                Qualification = "IT",
                DateOfJoining = DateTime.Now
            };

            _mockEligibilityService.Setup(s => s.CheckEligibility(applicant.Age)).Returns(true);
            _mockQualificationService.Setup(s => s.CheckQualification(applicant.Qualification)).Returns(true);

            // Act
            var result = _controller.CheckApplicant(applicant) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value!.ToString()!.Contains("eligible"));

            // Verify
            _mockEligibilityService.Verify(s => s.CheckEligibility(applicant.Age), Times.Once);
            _mockQualificationService.Verify(s => s.CheckQualification(applicant.Qualification), Times.Once);
        }

        [TestMethod]
        [DataRow(15)]
        [DataRow(0)]
        public void CheckApplicant_InvalidAge_ReturnsBadRequest(int age)
        {
            // Arrange
            var applicant = new Applicant
            {
                Name = "John Doe",
                Age = age,
                Qualification = "IT",
                DateOfJoining = DateTime.Now
            };

            _mockEligibilityService.Setup(s => s.CheckEligibility(applicant.Age)).Throws(new Exception("Age must be greater than 18"));

            // Act
            var result = _controller.CheckApplicant(applicant) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow("Math")]
        [DataRow("Physics")]
        public void CheckApplicant_InvalidQualification_ReturnsBadRequest(string qualification)
        {
            // Arrange
            var applicant = new Applicant
            {
                Name = "Jane Doe",
                Age = 25,
                Qualification = qualification,
                DateOfJoining = DateTime.Now
            };

            _mockEligibilityService.Setup(s => s.CheckEligibility(applicant.Age)).Returns(true);
            _mockQualificationService.Setup(s => s.CheckQualification(applicant.Qualification)).Throws(new Exception("Qualification must be either CS or IT"));

            // Act
            var result = _controller.CheckApplicant(applicant) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
