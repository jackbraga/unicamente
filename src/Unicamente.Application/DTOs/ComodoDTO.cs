using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Application.DTOs
{
    public class ComodoDTO 
    {
        public int ID { get; set; }

        [DisplayName("Comodo")]
        public string Descricao { get; set; }
    }
}
