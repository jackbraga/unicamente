using Unicamente.Domain.Entities;

namespace Unicamente.UI.Web.Models
{
    public class AdministrativoViewModel
    {
        public IEnumerable<ImobiliariaViewModel> Imobiliarias { get; set;}

        public ImobiliariaViewModel Imobiliaria { get; set; }
    }
}
