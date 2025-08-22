using Unit_testing.trial.Contracts;

namespace Unit_testing.trial.Application
{
    public class Eligibility : IEligibilityServices
    {
        public bool CheckEligibility(int age)
        {
            if (age <= 18)
            {
                throw new Exception("Age must be greater than 18");
            }
            return true;
        }

        public bool NameException(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }
            return true;
        }
    }
}
