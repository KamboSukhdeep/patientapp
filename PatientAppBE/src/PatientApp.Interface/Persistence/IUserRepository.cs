using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Interface.Persistence
{
    public interface IUserRepository
    {
        bool ValidateUser(string userName, string password);
    }
}
