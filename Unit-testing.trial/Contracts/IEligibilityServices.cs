namespace Unit_testing.trial.Contracts
{
    public interface IEligibilityServices
    {
        bool CheckEligibility(int age);

        bool NameException(string name);
    }
}
