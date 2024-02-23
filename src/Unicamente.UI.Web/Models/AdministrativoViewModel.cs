using Unicamente.Application.Services;
using Unicamente.Domain.Entities;

namespace Unicamente.UI.Web.Models
{
    public class AdministrativoViewModel
    {
        public AdministrativoViewModel()
        {
            this.Imobiliarias = new List<ImobiliariaViewModel>();
            this.Recipientes = new List<RecipienteViewModel>();
            this.Mariris = new List<MaririViewModel>();
            this.Chacronas = new List<ChacronaViewModel>();
            this.Vegetals = new List<VegetalViewModel>();
        }
        public IEnumerable<ImobiliariaViewModel> Imobiliarias { get; set; }

        public ImobiliariaViewModel Imobiliaria { get; set; }

        //public RecipienteViewModel Recipiente  { get; set; }

        public IEnumerable<RecipienteViewModel> Recipientes  { get; set; }
        public RecipienteViewModel Recipiente  { get; set; }

        public IEnumerable<MaririViewModel> Mariris { get; set; }
        public MaririViewModel Mariri { get; set; }


        public IEnumerable<ChacronaViewModel> Chacronas { get; set; }
        public ChacronaViewModel Chacrona { get; set; }


        public IEnumerable<VegetalViewModel> Vegetals { get; set; }
        public VegetalViewModel Vegetal { get; set; }


    }
}
