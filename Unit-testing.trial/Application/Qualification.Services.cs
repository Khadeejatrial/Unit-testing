using Unit_testing.trial.Contracts;

namespace Unit_testing.trial.Application
{
    public class Qualification : IQualification
    {
        public bool CheckQualification(string qual)
        {
            if (string.IsNullOrWhiteSpace(qual))
                throw new ArgumentNullException(nameof(qual));

            if (qual != "IT" && qual != "CS")
            {
                throw new Exception("Qualification must be either CS or IT");
            }

            return true;
        }
    }
}
