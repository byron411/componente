using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace fabricaDAO
{
    public abstract class PostgreSQLDAO
    {
        //Conexión a la base de datos
        protected NpgsqlConnection _conexion;

        //Comando para realizar operaciones CRUD
        protected NpgsqlCommand _comando;

        //Adaptador para llenar registros
        protected NpgsqlDataAdapter _adaptador;

        //Constructor. Inicializa los objetos para manejo de datos en PostgreSQL
        public PostgreSQLDAO()
        {
            _conexion = PostgreSQLDAOFactory.crearConexion("localhost", 5432, "postgres", "123456", "onu");
            _comando = new NpgsqlCommand("", _conexion);
             _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _adaptador = new NpgsqlDataAdapter(_comando);

            /*
             * _comando = new MySqlCommand("", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            _adaptador = new MySqlDataAdapter(_comando);
             */



        }
    }
}
