using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Representa los tipos de bases de datos que maneja la fábrica DAO
    /// </summary>
    public enum TipoDAO
    {

        /// <summary>
        /// Base de datos ORACLE
        /// </summary>
        ORACLE = 1,
        /// <summary>
        /// Base de datos MySQL
        /// </summary>
        MYSQL = 2,
        /// <summary>
        /// Base de datos SQL Server
        /// </summary>
        SQLSERVER = 3,
        /// <summary>
        /// Base de datos PostgreSQL
        /// </summary>
        POSTGRESQL = 4,
    }
}
