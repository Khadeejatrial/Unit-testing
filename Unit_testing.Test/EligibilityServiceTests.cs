using Unit_testing.trial.Application;

namespace Unit_testing.Tests.ServiceTests
{
    [TestClass]
    public class EligibilityServiceTests
    {
        private Eligibility _eligibility = null!;

        [TestInitialize]
        public void Setup()
        {
            _eligibility = new Eligibility();
        }

        [TestMethod]
        public void CheckEligibility_ValidAge_ReturnsTrue()
        {
            Assert.IsTrue(_eligibility.CheckEligibility(25));
        }

        [TestMethod]
        [DataRow(18)]
        [DataRow(10)]
        [ExpectedException(typeof(Exception))]
        public void CheckEligibility_InvalidAge_ThrowsException(int age)
        {
            _eligibility.CheckEligibility(age);
        }
    }
}
