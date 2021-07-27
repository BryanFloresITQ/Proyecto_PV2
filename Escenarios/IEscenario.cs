﻿using Modelo;
using System.Collections.Generic;
using static Escenarios.Escenario;

namespace Escenarios
{
    public interface IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga();
    }
}
