using fabricaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace fabricaDAO
{
    public class PostgreSQLDAOFactory : DAOFactory
    {
        //Nombre o Ip del servidor de Base de datos
        private static string _server;
        //Puerto de la Base de datos
        private static int _port;
        //Nombre de usuario de la Base de datos
        private static string _user;
        //Contraseña de usuario de la base de datos
        private static string _pass;
        //Nombre de la base de datos
        private static string _database;
        //Cadena de conexión a la base de datos
        private static string _connectionString;

        //getters and setters
        public static string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        public static int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public static string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public static string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        /*
         * Método que crea la conexión con la Base de datos 
         * @param server Nombre del servidor donde está la Base de datos
         * @param port Puerto de la Base de datos
         * @param user Nombre de usuario de la Base de datos
         * @param pass Contraseña del usuario de la Base de datos
         * @param database Nombre de la base de datos
         * @return devuelve la cadena de conexión
         */
         public static NpgsqlConnection crearConexion(string server, int port, string user, string pass, string database)
        {
            _server = server;
            _port = port;
            _user = user;
            _pass = pass;
            _database = database;
            _connectionString = "server=" + _server +
                                ";port=" + _port +    
                                "; user id=" + _user +
                                "; password=" + _pass +
                                "; database=" + _database;
            //return new postgreSQLConnection(_connectionString);
            return new NpgsqlConnection(_connectionString);
        }

        //Métodos override de la clase que hereda
        public override CiudadDAO darCiudadDAO()
        {
            throw new NotImplementedException();
        }

        public override ExtensionDAO darExtensionDAO()
        {
            throw new NotImplementedException();
        }

        public override IdiomaDAO darIdiomaDAO()
        {
            return new PostgreSQLIdiomaDAO();
        }

        /*
         *@returns devuelve un objeto de PasisDo 
         */
        public override PaisDAO darPaisDAO()
        {
            
            return new PostgreSQLPaisDAO();
        }
    }
}