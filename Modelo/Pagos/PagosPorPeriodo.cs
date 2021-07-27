using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class PagosPorPeriodo :IDBEntity
    {

        public int PagosPorPeriodoID { get; set; }
        //Valores Normales de Pago
        public DateTime Matricula { get; set; }
        public DateTime Pension1 { get; set; }
        public DateTime Pension2 { get; set; }
        public DateTime Pension3 { get; set; }
        public DateTime Pension4 { get; set; }
        public DateTime Pension5 { get; set; }
        public DateTime Pension6 { get; set; }
        public DateTime Pension7 { get; set; }
        public DateTime Pension8 { get; set; }
        public DateTime Pension9 { get; set; }
        //Valores Mora de Pago
        public DateTime MatriculaMora { get; set; }
        public DateTime PensionMora1 { get; set; }
        public DateTime PensionMora2 { get; set; }
        public DateTime PensionMora3 { get; set; }
        public DateTime PensionMora4 { get; set; }
        public DateTime PensionMora5 { get; set; }
        public DateTime PensionMora6 { get; set; }
        public DateTime PensionMora7 { get; set; }
        public DateTime PensionMora8 { get; set; }
        public DateTime PensionMora9 { get; set; }

        //Relacion de Tablas
        public Periodo Periodo { get; set; }
        public int PeriodoID { get; set; }
    }
}
