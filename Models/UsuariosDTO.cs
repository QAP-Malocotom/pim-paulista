using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim_paulista.Models
{
    public class UsuariosDTO
    {
        public int id_Usuarios { get; set; }
        public int id_Cargo { get; set; }
        public int id_Info { get; set; }
        public string? nm_Usuarios { get; set; }
        public string? ds_Senhas { get; set; }
        public DateTime dt_LastedOn { get; set; }
        public DateTime dt_UpdatedOn { get; set; }
        public DateTime dt_CreatedOn { get; set; }
    }
}
