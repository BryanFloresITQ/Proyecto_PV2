using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class Estados : IDBEntity
    {

        public int EstadosID { get; set; }
        public string NombreEstado { get; set; }
        public string Descripcion { get; set; }

        public List<Configuracion> configuraciones { get; set; }
        public List<Pagos> pagos { get; set; }
        public Penalizacion penalizacion { get; set; }
    }
}
