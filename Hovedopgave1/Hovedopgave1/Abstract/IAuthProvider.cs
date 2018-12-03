using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hovedopgave1.Abstract
{
    interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
