using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_paulista.Models
{
    public class InfosDTO
    {
        public int id_Info { get; set; }
        public string? nm_Completo { get; set; }
        public string? ds_Endereco { get; set; }
        public string? nm_Numero { get; set; }
        public string? ds_Cpf { get; set; }
        public string? ds_Cep { get; set; }
        public string? ds_Formacao { get; set; }
        public string? ds_Tel { get; set; }
        public string? ds_Cel { get; set; }
        public DateTime dt_Aniv { get; set; }
        public DateTime? dt_UpdateOn { get; set; }

    }
}
