using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientApp.Interface.Persistence;

namespace PatientApp.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public bool ValidateUser(string userName, string password)
        {
            return  (userName == "admin" && password == "admin");
           
        }
    }
}
