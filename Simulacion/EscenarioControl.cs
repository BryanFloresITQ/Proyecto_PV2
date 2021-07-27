using Escenarios;
using Modelo.Pagos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Escenarios.Escenario;

namespace Simulacion
{
    public class EscenarioControl
    {
        public void Grabar01(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new SchoolContext())
            {

                //Reiniciamos la Base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //Insertamos los datos
                db.estudiante.AddRange((List<Estudiante>)datos[ListaTipo.Estudiante]);
                db.periodo.AddRange((List<Periodo>)datos[ListaTipo.Periodo]);
                db.estados.AddRange((List<Estados>)datos[ListaTipo.Estados]);
                db.tiposPago.AddRange((List<TiposPago>)datos[ListaTipo.TiposPago]);
                //db.penalizacion.AddRange((List<Penalizacion>)datos[ListaTipo.Penalizacion]);

                //Genera la persistencia
                db.SaveChanges();

            }
        }
        public void Grabar02(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new SchoolContext())
            {

                //Insertamos los datos
                db.configuracion.AddRange((List<Configuracion>)datos[ListaTipo.Configuracion]);
                db.penalizacion.AddRange((List<Penalizacion>)datos[ListaTipo.Penalizacion]);

                //Genera la persistencia
                db.SaveChanges();

            }
        }

    }
}
