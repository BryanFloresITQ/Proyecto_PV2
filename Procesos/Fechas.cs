using Modelo.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class Fechas
    {
        public List<DateTime> Calcular_Fechas(Periodo periodo)
        {

            List<DateTime> fechas = new();

            fechas.Add(periodo.FechaInicio);
            fechas.Add(new DateTime(periodo.FechaInicio.Year, periodo.FechaInicio.Month + 1, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year, periodo.FechaInicio.Month + 2, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year, periodo.FechaInicio.Month + 3, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 8, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 7, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 6, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 5, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 4, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 3, periodo.FechaInicio.Day));
            fechas.Add(new DateTime(periodo.FechaInicio.Year + 1, periodo.FechaInicio.Month - 2, periodo.FechaInicio.Day));

            return fechas;
        }
    }
}
