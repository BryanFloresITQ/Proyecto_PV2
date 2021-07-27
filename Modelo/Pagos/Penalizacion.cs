using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class Penalizacion : IDBEntity
    {

        public int PenalizacionID { get; set; }
        public string NombrePenalizacion { get; set; }
        public string Descripcion { get; set; }

        public Estados Estados { get; set; }
        public int EstadoID { get; set; }

    }
}
