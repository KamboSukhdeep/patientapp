using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Interface.Common
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userName);
    }
}
