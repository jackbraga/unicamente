using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetByName(string texto);
        T GetById(int? id);
        int Add(T objeto);
        void Update(T objeto);
        void Remove(int id);
    }
}
