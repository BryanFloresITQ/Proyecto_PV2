using Procesos;
using System;
using Xunit;
using Escenarios;
using Simulacion;
using Modelo.Pagos;

namespace PruebasUnitarias
{

    public class UnitTest1
    {
        
        [Theory]
        //Matriculas Periodo 1
        [InlineData(2018, 9, 1, "Matricula", 2018, 9, 1, true)]
        [InlineData(2018, 9, 10, "Matricula", 2018, 9, 1, false)]
        [InlineData(2018, 9, 5, "Matricula", 2018, 9, 1, false)]
        //Pensiones Periodo 1
        [InlineData(2018, 10, 1, "Pension", 2018, 9, 1, true)]
        [InlineData(2018, 11, 1, "Pension", 2018, 9, 1, true)]
        [InlineData(2018, 12, 1, "Pension", 2018, 9, 1, true)]
        [InlineData(2019, 1, 2, "Pension", 2018, 9, 1, false)]
        [InlineData(2019, 2, 10, "Pension", 2018, 9, 1, false)]
        [InlineData(2019, 3, 5, "Pension", 2018, 9, 1, false)]

        //Matriculas Periodo 2
        [InlineData(2019, 9, 1, "Matricula", 2019, 9, 1, true)]
        [InlineData(2019, 9, 10, "Matricula", 2019, 9, 1, false)]
        [InlineData(2019, 9, 5, "Matricula", 2019, 9, 1, false)]
        //Pensiones Periodo 2
        [InlineData(2019, 10, 1, "Pension", 2019, 9, 1, true)]
        [InlineData(2019, 11, 1, "Pension", 2019, 9, 1, true)]
        [InlineData(2019, 12, 1, "Pension", 2019, 9, 1, true)]
        [InlineData(2020, 1, 2, "Pension", 2019, 9, 1, false)]
        [InlineData(2020, 2, 10, "Pension", 2019, 9, 1, false)]
        [InlineData(2020, 3, 5, "Pension", 2019, 9, 1, false)]

        //Matriculas Periodo 3
        [InlineData(2020, 9, 1, "Matricula", 2020, 9, 1, true)]
        [InlineData(2020, 9, 10, "Matricula", 2020, 9, 1, false)]
        [InlineData(2020, 9, 5, "Matricula", 2020, 9, 1, false)]
        //Pensiones Periodo 3
        [InlineData(2020, 10, 1, "Pension", 2020, 9, 1, true)]
        [InlineData(2020, 11, 1, "Pension", 2020, 9, 1, true)]
        [InlineData(2020, 12, 1, "Pension", 2020, 9, 1, true)]
        [InlineData(2021, 1, 2, "Pension", 2020, 9, 1, false)]
        [InlineData(2021, 2, 10, "Pension", 2020, 9, 1, false)]
        [InlineData(2021, 3, 5, "Pension", 2020, 9, 1, false)]
        public void Test1(int anioPago, int mesPago, int diaPago, string tipoPago, int anioPeriodo, int mesPeriodo, int diaPeriodo, bool valorEsperado)
        {

            pagos pg = new pagos();

            var resultado = pg.Descuento(new DateTime(anioPago, mesPago, diaPago), tipoPago, new DateTime(anioPeriodo, mesPeriodo, diaPeriodo));

            if (valorEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);

        }


        [Theory]
        [InlineData(true, "Matricula", 80)]
        [InlineData(false, "Matricula", 100)]
        [InlineData(true, "Pension", 40)]
        [InlineData(false, "Pension", 50)]

        public void Test2(bool descuento, string tipoPago, float valorEsperado)
        {

            pagos pg = new pagos();

            var resultado = pg.calcularPagoTotal(descuento, tipoPago);

            Assert.True(valorEsperado == resultado, " Esperado: " + valorEsperado + " Obtenido: "+resultado);
            Assert.False(valorEsperado != resultado, " Esperado: " + valorEsperado + " Obtenido: " + resultado);

        }
    }
}
