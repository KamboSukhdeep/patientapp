using PatientApp.Interface.Persistence;

namespace PatientApp.Persistence.Repositories
{
    internal class UnitOfWork(IPatientRepository patients, IUserRepository users) : IUnitOfWork
    {
        public IPatientRepository Patients { get; } = patients ?? throw new ArgumentNullException(nameof(patients));

        public IUserRepository Users { get; } = users ?? throw new ArgumentNullException(nameof(users));

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
