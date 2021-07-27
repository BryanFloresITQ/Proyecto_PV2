using Modelo;
using Procesos;
using Modelo.Pagos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escenarios
{
    public class Escenario02 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {

            using (var db = new SchoolContext())
            {
                var periodos = db.periodo
                    .ToList();

                List<PagosPorPeriodo> lstPPPeriodo = new();

                foreach(var periodo in periodos)
                {

                    Fechas fechas = new Fechas();

                    List<DateTime> calculofechas = fechas.Calcular_Fechas(periodo);

                    PagosPorPeriodo periodoActual = new()
                    {
                        Periodo = periodo,
                        Matricula = calculofechas[0],
                        MatriculaMora = calculofechas[1],
                        Pension1 = calculofechas[1],
                        PensionMora1 = calculofechas[2],
                        Pension2 = calculofechas[2],
                        PensionMora2 = calculofechas[3],
                        Pension3 = calculofechas[3],
                        PensionMora3 = calculofechas[4],
                        Pension4 = calculofechas[4],
                        PensionMora4 = calculofechas[5],
                        Pension5 = calculofechas[5],
                        PensionMora5 = calculofechas[6],
                        Pension6 = calculofechas[6],
                        PensionMora6 = calculofechas[7],
                        Pension7 = calculofechas[7],
                        PensionMora7 = calculofechas[8],
                        Pension8 = calculofechas[8],
                        PensionMora8 = calculofechas[9],
                        Pension9 = calculofechas[9],
                        PensionMora9 = calculofechas[10],

                    };

                    db.Add(periodoActual);
                    db.SaveChanges();
                }

                var tipoMatricula = db.tiposPago
                    .Single(tip => tip.NombreTipo == "Matricula");

                var tipoPension = db.tiposPago
                    .Single(tip => tip.NombreTipo == "Pension");

                var estadoAceptado = db.estados
                    .Single(est => est.NombreEstado == "Pago aceptado");

                Configuracion config1 = new()
                        {
                            TipoID = tipoMatricula.TiposPagoID,
                            EstadoID = estadoAceptado.EstadosID
                        };

                Configuracion config2 = new()
                        {
                            TipoID = tipoPension.TiposPagoID,
                            EstadoID = estadoAceptado.EstadosID
                        };

                List<Configuracion> lstConfiguraciones = new()
                {
                    config1, config2
                };

                datos.Add(ListaTipo.Configuracion, lstConfiguraciones);

                var estPendiente = db.estados
                    .Single(est => est.NombreEstado == "Pendiente de pago");

                var estRechazado = db.estados
                    .Single(est => est.NombreEstado == "Pago rechazado");

                Penalizacion penMora = new()
                {
                    NombrePenalizacion = "Mora",
                    EstadoID = estRechazado.EstadosID,
                    Descripcion = "Exámenes finales, pruebas parciales",
                };

                Penalizacion penPendiente = new()
                {
                    NombrePenalizacion = "Pendiente de Pago",
                    EstadoID = estPendiente.EstadosID,
                    Descripcion = "Piscina, Cafetería, Laboratorios",
                };

                List<Penalizacion> lstPenalizaciones = new()
                {
                    penMora, penPendiente
                };

                datos.Add(ListaTipo.Penalizacion, lstPenalizaciones);


                return datos;
            }

        }
    }
}
