namespace PatientApp.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IUserRepository Users { get; }
    }
}
