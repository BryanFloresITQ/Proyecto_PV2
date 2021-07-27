using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Pagos
{
    public class Configuracion : IDBEntity
    {

        public int ConfiguracionID { get; set; }
        public TiposPago TiposPago { get; set; }
        public int TipoID { get; set; }
        public Estados Estados { get; set; }
        public int EstadoID { get; set; }

    }
}
