using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_testing.trial.Application;

namespace Unit_testing.Tests.ServiceTests
{
    [TestClass]
    public class QualificationServiceTests
    {
        private Qualification _qualification = null!;

        [TestInitialize]
        public void Setup()
        {
            _qualification = new Qualification();
        }

        [TestMethod]
        [DataRow("IT")]
        [DataRow("CS")]
        public void CheckQualification_Valid_ReturnsTrue(string qual)
        {
            Assert.IsTrue(_qualification.CheckQualification(qual));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void CheckQualification_NullOrEmpty_ThrowsArgumentNullException(string qual)
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => _qualification.CheckQualification(qual));
        }

        [TestMethod]
        [DataRow("Math")]
        [DataRow("Physics")]
        public void CheckQualification_Invalid_ThrowsException(string qual)
        {
            Assert.ThrowsExactly<Exception>(() => _qualification.CheckQualification(qual));
        }
    }
}
