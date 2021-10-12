using fabricaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace fabricaDAO
{
    public class PostgreSQLCiudadDAO : PostgreSQLDAO, CiudadDAO
    {
        public PostgreSQLCiudadDAO() : base() { }

        /// <summary>
        /// Inserta en la base de datos el DTO dado de ciudad
        /// </summary>
        /// <returns>true - operación exitosa
        /// <para>false - operacion fallida</para></returns>
        /// <param name="pCiudad">objeto DTO a eliminar</param>
        public bool insert(CiudadDTO pCiudad)
        {
            try
            {
               //TODO completar sentencia sql para agregar una ciudad
                string sql = "insert into ciudad (nombre, distrito, poblacion,codigo_pais) values('"+pCiudad.Nombre+"','"+pCiudad.Distrito+"',"+pCiudad.Poblacion+",'"+pCiudad.IdPais+"');";
                _conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand(sql, _conexion);
                comando.ExecuteNonQuery();
                _conexion.Close();

                return true;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        /// <summary>
        /// Modifica en la base de datos el DTO dado de ciudad
        /// </summary>
        /// <returns>true - operación exitosa
        /// <para>false - operacion fallida</para></returns>
        /// <param name="pCiudad">objeto DTO a eliminar</param>
        public bool update(CiudadDTO pCiudad)
        {
            try
            {
                
                string sql = "update ciudad set nombre='"+pCiudad.Nombre+"', distrito='"+pCiudad.Distrito+"', poblacion="+pCiudad.Poblacion+", codigo_pais='"+pCiudad.IdPais+"' where codigo_ciudad="+pCiudad.IdCiudad+";";
                _conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand(sql, _conexion);
;               comando.ExecuteNonQuery();
                _conexion.Close();

                return true;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        /// <summary>
        /// Elimina de la base de datos el DTO dado de ciudad
        /// </summary>
        /// <returns>true - operación exitosa
        /// <para>false - operacion fallida</para></returns>
        /// <param name="pCiudad">objeto DTO a eliminar</param>
        public bool delete(CiudadDTO pCiudad)
        {
            try
            {
                // ejecutar sql que elimina a una ciudad
                string sql = "delete from ciudad where codigo_ciudad="+pCiudad.IdCiudad+"";
                _conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand(sql, _conexion);
                comando.ExecuteNonQuery();
                _conexion.Close();

                return true;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla ciudad, los almacena en una lista de DTO y devuelve la lista
        /// </summary>
        /// <returns>lista de DTO de ciudad</returns>
        public List<CiudadDTO> selectAll()
        {
            try
            {
                List<CiudadDTO> lista = new List<CiudadDTO>();
                DataSet conjunto = new DataSet();

                // Llamar al procedimiento que devuelve todos las ciudades
                _comando.CommandText = "seleccionarCiudad";
                _comando.Parameters.Clear();
                _adaptador.Fill(conjunto);
                //
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    CiudadDTO ciudad = new CiudadDTO();

                    ciudad.IdCiudad = Convert.ToInt32(conjunto.Tables[0].Rows[i]["codigo_ciudad"]);
                    ciudad.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    ciudad.Distrito = conjunto.Tables[0].Rows[i]["distrito"] + "";
                    ciudad.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[i]["poblacion"]);
                    ciudad.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";

                    lista.Add(ciudad);
                }
                return lista;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        /// <summary>
        /// Selecciona un registro de ciudad dado su PK
        /// </summary>
        /// <returns>DTO de ciudad encontrado</returns>
        /// <param name="pCiudad">objeto DTO a eliminar</param>
        public CiudadDTO selectByPK(CiudadDTO pCiudad)
        {
            try
            {
                DataSet conjunto = new DataSet();
                CiudadDTO ciudad = new CiudadDTO();

                // Llamar al procedimiento que devuelve una ciudad de acuerdo con su ID
                _comando.CommandText = "seleccionarCiudadPorPK";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nIdCiudad", pCiudad.IdCiudad);

                _adaptador.Fill(conjunto);
                //

                if (conjunto.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                ciudad.IdCiudad = Convert.ToInt32(conjunto.Tables[0].Rows[0]["codigo_ciudad"]);
                ciudad.Nombre = conjunto.Tables[0].Rows[0]["nombre"] + "";
                ciudad.Distrito = conjunto.Tables[0].Rows[0]["distrito"] + "";
                ciudad.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[0]["poblacion"]);
                ciudad.IdPais = conjunto.Tables[0].Rows[0]["codigo_pais"] + "";

                return ciudad;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla ciudad que cumplen con los criterios de búsqueda, los almacena en una lista de DTO y devuelve la lista
        /// </summary>
        /// <returns>lista de DTO de ciudad</returns>
        /// <param name="pIdPais">id de país a buscar</param>
        /// <param name="pNombre">nombre de país a buscar</param>
        /// <param name="pDistrito">distrito de pais a buscar</param>
        public List<CiudadDTO> selectByCriteria(string pIdPais, string pNombre, string pDistrito)
        {
            try
            {
                List<CiudadDTO> lista = new List<CiudadDTO>();
                DataSet conjunto = new DataSet();

                // Llamar al procedimiento que devuelve las ciudades de acuerdo con los parámetros dados
                /*if (pIdPais == "" && pNombre == "" && pDistrito == "") { 
                string sql = "select * from ciudad;";
                _conexion.Open();
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                adaptador.Fill(conjunto);
                _conexion.Close();
            }
                else
                {*/
                    string sql = "select * from ciudad where codigo_pais='"+pIdPais+"' or nombre='"+pNombre+"' or distrito='"+pDistrito+"';";
                    _conexion.Open();
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                    adaptador.Fill(conjunto);
                    _conexion.Close();
                //}
                //
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    CiudadDTO ciudad = new CiudadDTO();

                    ciudad.IdCiudad = Convert.ToInt32(conjunto.Tables[0].Rows[i]["codigo_ciudad"]);
                    ciudad.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    ciudad.Distrito = conjunto.Tables[0].Rows[i]["distrito"] + "";
                    ciudad.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[i]["poblacion"]);
                    ciudad.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";

                    lista.Add(ciudad);
                }
                return lista;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
        }

    }
}