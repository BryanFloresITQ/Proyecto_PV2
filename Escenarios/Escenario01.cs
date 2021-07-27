using Modelo;
using Modelo.Pagos;
using System;
using System.Collections.Generic;

namespace Escenarios
{
    public class Escenario01 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {
            Estudiante Bryan = new() { Nombre = "Bryan Flores", Cedula = "1724440092" };
            Estudiante Andres = new() { Nombre = "Andres Obando", Cedula = "1713801932" };
            Estudiante Helen = new() { Nombre = "Helen Martinez", Cedula = "1715615355" };
            List<Estudiante> lstEstudiante = new()
            { Bryan, Andres, Helen };

            datos.Add(ListaTipo.Estudiante, lstEstudiante);

            Periodo PAO_2018 = new() { PeriodoAcademico = "2018 - 2019", FechaInicio = new DateTime(2018, 9, 1), FechaFin = new DateTime(2019, 6, 1) };
            Periodo PAO_2019 = new() { PeriodoAcademico = "2019 - 2020", FechaInicio = new DateTime(2019, 9, 1), FechaFin = new DateTime(2020, 6, 1) };
            Periodo PAO_2020 = new() { PeriodoAcademico = "2020 - 2021", FechaInicio = new DateTime(2020, 9, 1), FechaFin = new DateTime(2021, 6, 1) };

            List<Periodo> lstPeriodo = new()
            { PAO_2018, PAO_2019, PAO_2020 };

            datos.Add(ListaTipo.Periodo, lstPeriodo);

            Estados Aceptado = new() { NombreEstado = "Pago Aceptado", Descripcion = "Pago completado satisfactoriamente" };
            Estados Proceso = new() { NombreEstado = "En Proceso", Descripcion = "Pago aun no verificado" };
            Estados Pendiente = new() { NombreEstado = "Pendiente de pago", Descripcion = "Sin comprobante de pago" };
            Estados Rechazado = new() { NombreEstado = "Pago rechazado", Descripcion = "Pago realizado no encontrado en la cuenta" };

            List<Estados> lstEstados = new()
            { Aceptado, Proceso, Pendiente, Rechazado };

            datos.Add(ListaTipo.Estados, lstEstados);

            TiposPago Matricula = new() { NombreTipo = "Matricula", Valor = 100f, Descuento = 20f };
            TiposPago Pension = new() { NombreTipo = "Pension", Valor = 50f, Descuento = 10f };

            List<TiposPago> lstTipoPago = new()
            { Matricula, Pension };

            datos.Add(ListaTipo.TiposPago, lstTipoPago);

            Penalizacion Mora = new() { NombrePenalizacion = "Mora", Descripcion = "Exámenes finales, pruebas parciales" , EstadoID = Rechazado.EstadosID };
            Penalizacion P_Pendiente = new() { NombrePenalizacion = "Pendiente de Pago", Descripcion = "Piscina, Cafetería, Laboratorios", EstadoID = Pendiente.EstadosID };
            Penalizacion Ninguna = new() { NombrePenalizacion = "Ninguna", Descripcion = "Ninguna", EstadoID = Aceptado.EstadosID };

            List<Penalizacion> lstPenalizacion = new()
            { Mora, P_Pendiente, Ninguna };

            datos.Add(ListaTipo.Penalizacion, lstPenalizacion);

            return datos;
        }
    }
}
