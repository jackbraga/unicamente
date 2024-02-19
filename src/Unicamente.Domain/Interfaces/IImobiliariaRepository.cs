using Unicamente.Domain.Entities;

namespace Unicamente.Domain.Interfaces
{
    public interface IImobiliariaRepository: IBaseRepository<Imobiliaria>
    {
         Imobiliaria GetByEmail(string email);
     
    }
}
