using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace fabricaDatos
{
    /// <summary>
    /// Fábrica de objetos DAO tipo MYSQL
    /// </summary>
    public class MysqlDAOFactory : DAOFactory
    {
        /// <summary>
        /// Nombre o IP del servidor de BAse de datos
        /// </summary>
        private static string _server;

        /// <summary>
        /// Nombre o IP del servidor de BAse de datos
        /// </summary>
        public static string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        /// <summary>
        /// Nombre del usuario de base de datos
        /// </summary>
        private static string _user;

        /// <summary>
        /// Nombre del usuario de base de datos
        /// </summary>
        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }
        /// <summary>
        /// Contraseña del usuario de la base de datos
        /// </summary>
        private static string _password;

        /// <summary>
        /// Contraseña del usuario de la base de datos
        /// </summary>
        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        private static string _database;

        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public static string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        /// <summary>
        /// Cadena de conexion a la base de datos
        /// </summary>
        private static string _connectionString;

        /// <summary>
        /// Cadena de conexion a la base de datos
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// Devuelve la conexión a MySQL
        /// </summary>
        /// <param name="server">Nombre del servidor de base de datos</param>
        /// <param name="user">Nombre de usuario de base de datos</param>
        /// <param name="password">Contraseña de usuario de base de datos</param>
        /// <param name="database">Nombre de la base de datos de trabajo</param>
        public static MySqlConnection crearConexion(string server, string user, string password, string database)
        {
            _server = server;
            _user = user;
            _password = password;
            _database = database;
            _connectionString = "server=" + _server +
                                "; user id=" + _user +
                                "; password=" + _password +
                                "; database=" + _database;

            return new MySqlConnection(_connectionString);
        }

       
        /// <summary>
        /// Devuelve un objeto de PaisDAO
        /// </summary>
        public override PaisDAO darPaisDAO()
        {
            return new MySQLPaisDAO();
        }

        /// <summary>
        /// Devuelve un objeto de CiudadDAO
        /// </summary>
        public override CiudadDAO darCiudadDAO()
        {
            return new MySQLCiudadDAO();
        }

        /// <summary>
        /// Devuelve un objeto de IdiomaDAO
        /// </summary>
        public override IdiomaDAO darIdiomaDAO()
        {
            return new MySQLIdiomaDAO();
        }

        /// <summary>
        /// Devuelve un objeto de ExtensionDAO
        /// </summary>
        public override ExtensionDAO darExtensionDAO()
        {
            return new MySQLExtensionDAO();
        }
    }
}
