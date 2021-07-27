using Microsoft.EntityFrameworkCore;
using Modelo.Pagos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class pagos
    {
        public bool Descuento(DateTime fecPago, string tipoPago, DateTime Periodo)
        {

            using (var db = new SchoolContext())
            {
                var tipo = db.tiposPago
                    .Single(tip => tip.NombreTipo == tipoPago);

                var periodo = db.periodo
                    .Single(per => per.FechaInicio == Periodo);

                var fechasPago = db.pagosPorPeriodo
                    .Single(ppp => ppp.PeriodoID == periodo.PeriodoID);

                if(tipoPago == "Matricula")
                {
                    if(fecPago <= fechasPago.Matricula)
                    {
                        return true;
                    }
                }
                else
                {

                    if (fecPago == fechasPago.Pension9) return true;
                    if (fecPago == fechasPago.Pension8) return true;
                    if (fecPago == fechasPago.Pension7) return true;
                    if (fecPago == fechasPago.Pension6) return true;
                    if (fecPago == fechasPago.Pension5) return true;
                    if (fecPago == fechasPago.Pension4) return true;
                    if (fecPago == fechasPago.Pension3) return true;
                    if (fecPago == fechasPago.Pension2) return true;
                    if (fecPago == fechasPago.Pension1) return true;

                }

            }

                return false;
        }

        public float calcularPagoTotal(bool descuento, string tipoPago)
        {
            using (var db = new SchoolContext())
            {
                var tipo = db.tiposPago
                .Single(tip => tip.NombreTipo == tipoPago);

                    return descuento ? tipo.Valor - tipo.Descuento : tipo.Valor;

            };

        }

        public void registarPagos(DateTime fecPago, DateTime inicioPeriodo, string nombreEstudiante, string tipoPago, float valorPago, string metodoPago)
        {
            using (var db = new SchoolContext())
            {

                var periodo = db.periodo
                    .Single(per => per.FechaInicio == inicioPeriodo);

                var estudiante = db.estudiante
                    .Single(est => est.Nombre == nombreEstudiante);

                var tipo = db.tiposPago
                    .Single(tip => tip.NombreTipo == tipoPago);

                var estado = db.estados
                    .Single(est => est.NombreEstado == "En proceso");

                var desc = Descuento(fecPago, tipoPago, inicioPeriodo);

                Pagos registrarPago = new()
                {
                    FechaPago = fecPago,
                    PeriodoID = periodo.PeriodoID,
                    EstudianteID = estudiante.EstudianteID,
                    TiposPagoID = tipo.TiposPagoID,
                    ValorPago = valorPago,
                    Descuento = desc,
                    Mora = !desc,
                    TotalAPagar = calcularPagoTotal(desc, tipoPago),
                    MetodoPago = metodoPago,
                    EstadoID = estado.EstadosID

                };


                try
                {
                    db.Add(registrarPago);
                    db.SaveChanges();

                    Console.WriteLine("**********************************************");
                    Console.WriteLine("\n\tRegistro Creado");
                    Console.WriteLine("Fecha de Pago:\t " + fecPago);
                    Console.WriteLine("Periodo ID:\t " + periodo.PeriodoID);
                    Console.WriteLine("Nombre del Estudiante:\t " + nombreEstudiante);
                    Console.WriteLine("Tipo de Pago:\t " + tipoPago);
                    Console.WriteLine("Valor de Pago:\t " + valorPago);
                    Console.WriteLine("Descuento:\t " + desc);
                    Console.WriteLine("Mora:\t " + !desc);
                    Console.WriteLine("Metodo de Pago:\t " + metodoPago);
                    Console.WriteLine("Estado:\t " + estado.NombreEstado);
                    Console.WriteLine("**********************************************\n");


                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }


            }
        }

        public void ActualizarEstado(string nuevoEstado, string Estudiante, DateTime fecPago)
        {

            using (var db = new SchoolContext())
            {
                

                try
                {
                    var pagoActualizar = db.pagos
                    .Include(pag => pag.Estudiante)
                    .Include(pag => pag.Periodo)
                    .Single(pag => pag.Estudiante.Nombre == Estudiante && pag.FechaPago == fecPago);

                    var estadoID = db.estados
                        .Single(est => est.NombreEstado == nuevoEstado);

                    pagoActualizar.EstadoID = estadoID.EstadosID;

                    db.SaveChanges();

                    Console.WriteLine("\n********************************************************************************************");
                    Console.WriteLine("\n\tEl Estado del Pago del Estudiante: "+Estudiante+" en el Periodo: "+pagoActualizar.PeriodoID+" cambio a: "+nuevoEstado);
                    Console.WriteLine("********************************************************************************************\n");

                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
            }
        }

        public void trearPenalizaciones(string nombreEstudiante, DateTime fechaPeriodo)
        {
            using (var db = new SchoolContext())
            {
                var pago = db.pagos
                    .Include(pag => pag.Estudiante)
                    .Include(pag => pag.Periodo)
                    .Single(pag => pag.Estudiante.Nombre == nombreEstudiante && pag.Periodo.FechaInicio == fechaPeriodo);

                var penMora = db.penalizacion
                    .Single(pen => pen.NombrePenalizacion == "Mora");
                var penPendiente = db.penalizacion
                    .Single(pen => pen.NombrePenalizacion == "Pendiente de Pago");

                if (pago.EstadoID == penMora.EstadoID)
                {
                    Console.WriteLine("\n-------Penalizacion------");
                    Console.WriteLine("Restriccion a: ");
                    Console.WriteLine(penMora.Descripcion);
                }
                else if (pago.EstadoID == penPendiente.EstadoID)
                {

                    Console.WriteLine("\n-------Penalizacion------");
                    Console.WriteLine("Restriccion a: ");
                    Console.WriteLine(penPendiente.Descripcion);
                }
                else
                {

                    Console.WriteLine("\n-------Penalizacion------");
                    Console.WriteLine("No tiene ninguna penalizacion ");
                }
            }
        }
    }
}
