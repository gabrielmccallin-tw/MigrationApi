namespace PdsLookup
{
    public interface IPdsRetreiver
    {
        PatientDetail Retrieve(int nhsNumber);
    }
}