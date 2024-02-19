using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Domain.Interfaces
{
    public interface ILoginRepository
    {
        void ConfirmarEmailInvestidor(string hash);
    }
}
