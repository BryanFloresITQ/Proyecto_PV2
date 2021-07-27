using Modelo;
using System.Collections.Generic;

namespace Escenarios
{
    public class Escenario
    {
        public enum ListaTipo
        {
            Configuracion, Estados, Estudiante, Pagos, PagosPorPeridoo, Penalizacion, Periodo, TiposPago
        };
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;

        public Escenario()
        {
            datos = new();
        }
    }
}
