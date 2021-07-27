using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class Periodo : IDBEntity
    {

        public int PeriodoID { get; set; }
        public string PeriodoAcademico { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Pagos> Pagos { get; set; }
        public PagosPorPeriodo pagosPorPeriodo { get; set; }
    }
}
