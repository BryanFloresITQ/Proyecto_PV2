using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class Pagos : IDBEntity
    {
        public int PagosID { get; set; }
        public DateTime FechaPago { get; set; }
        public float ValorPago { get; set; }
        public Boolean Descuento { get; set; }
        public Boolean Mora { get; set; }
        public float TotalAPagar { get; set; }
        public string MetodoPago { get; set; }

        // Relaciones
        public Periodo Periodo { get; set; }
        public int PeriodoID { get; set; }
        public Estudiante Estudiante { get; set; }
        public int EstudianteID { get; set; }
        public TiposPago TiposPago { get; set; }
        public int TiposPagoID { get; set; }
        public Estados Estados { get; set; }
        public int EstadoID { get; set; }

    }
}
