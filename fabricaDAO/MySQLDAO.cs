using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para manejo de DAO en MYSQL
    /// </summary>
    public abstract class MySQLDAO
    {
        /// <summary>
        /// Conexión a la base de datos
        /// </summary>
        protected MySqlConnection _conexion;
        /// <summary>
        /// Comando para realizar operaciones CRUD
        /// </summary>
        protected MySqlCommand _comando;
        /// <summary>
        /// Adaptador para llenar registros
        /// </summary>
        protected MySqlDataAdapter _adaptador;

        /// <summary>
        /// Constructor. Inicializa los objetos para manejo de datos en MySQL
        /// </summary>
        public MySQLDAO()
        {
            _conexion = MysqlDAOFactory.crearConexion("localhost", // servidor
                                                        "root", // usuario
                                                        "123456", // contraseña
                                                        "onu"); // base de datos
            _comando = new MySqlCommand("", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            _adaptador = new MySqlDataAdapter(_comando);
        }
    }
}
