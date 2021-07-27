using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class TiposPago : IDBEntity
    {

        public int TiposPagoID { get; set; }
        public string NombreTipo { get; set; }
        public float Valor { get; set; }
        public float Descuento { get; set; }

        public Configuracion Configuracion { get; set; }
        public List<Pagos> Pagos { get; set; }
    }
}
