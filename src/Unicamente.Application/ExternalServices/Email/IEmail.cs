using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.ExternalServices.Email
{
    public interface IEmail
    {
        void EnviarEmail(string email, string texto);
    }
}
