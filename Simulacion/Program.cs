using Escenarios;
using Persistencia;
using Procesos;
using System;
using System.Linq;

namespace Simulacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var Escenario01 = new Escenario01();
            var Escenario02 = new Escenario02();
            var escenarioControl = new EscenarioControl();
            escenarioControl.Grabar01(Escenario01);
            escenarioControl.Grabar02(Escenario02);

            pagos pg = new pagos();

            //Ingreso de Pagos de estudiantes

            pg.registarPagos(new DateTime(2018, 9, 1), new DateTime(2018, 9, 1), "Bryan Flores", "Matricula", 80, "Transferencia");
            pg.registarPagos(new DateTime(2018, 9, 10), new DateTime(2018, 9, 1), "Andres Obando", "Matricula", 80, "Transferencia");
            pg.registarPagos(new DateTime(2018, 9, 5), new DateTime(2018, 9, 1), "Helen Martinez", "Matricula", 80, "Transferencia");


            //Actualizar los estados de pagos

            pg.ActualizarEstado("Pago Aceptado", "Bryan Flores", new DateTime(2018, 9, 1));
            pg.ActualizarEstado("Pago Aceptado", "Andres Obando", new DateTime(2018, 9, 10));
            pg.ActualizarEstado("Pago Rechazado", "Helen Martinez", new DateTime(2018, 9, 5));

            //Traer penalizaciones de Estudiantes

            pg.trearPenalizaciones("Bryan Flores", new DateTime(2018, 9, 1));
            pg.trearPenalizaciones("Andres Obando", new DateTime(2018, 9, 1));
            pg.trearPenalizaciones("Helen Martinez", new DateTime(2018, 9, 1));
        }
    }
}
