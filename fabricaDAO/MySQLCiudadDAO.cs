using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para las operaciones SQL de la tabla Ciudad
    /// </summary>
    public class MySQLCiudadDAO: MySQLDAO, CiudadDAO
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MySQLCiudadDAO(): base()
        { }

        #region Miembros de CiudadDAO

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
                CiudadDTO nuevo = selectByPK(pCiudad);

                if (nuevo != null)
                {
                    throw new Exception("la ciudad ya existe !..");
                }

                // Llamar al procedimiento que inserta una ciudad
                _comando.CommandText = "insertarCiudad";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nNombre", pCiudad.Nombre);
                _comando.Parameters.AddWithValue("nDistrito", pCiudad.Distrito);
                _comando.Parameters.AddWithValue("nPoblacion", pCiudad.Poblacion);
                _comando.Parameters.AddWithValue("nCodigo_pais", pCiudad.IdPais);
                
                _conexion.Open();
                _comando.ExecuteNonQuery();
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
                // lamar al procedimiento que actualiza una ciudad
                _comando.CommandText = "actualizarCiudad";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nCodigo_ciudad", pCiudad.IdCiudad);
                _comando.Parameters.AddWithValue("nNombre", pCiudad.Nombre);
                _comando.Parameters.AddWithValue("nDistrito", pCiudad.Distrito);
                _comando.Parameters.AddWithValue("nPoblacion", pCiudad.Poblacion);
                _comando.Parameters.AddWithValue("nCodigo_pais", pCiudad.IdPais);
                
                _conexion.Open();
                _comando.ExecuteNonQuery();
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
                // Llamar al procedimiento que elimina a una ciudad
                _comando.CommandText = "eliminarCiudad";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nCodigo_ciudad", pCiudad.IdCiudad);

                _conexion.Open();
                _comando.ExecuteNonQuery();
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
                    ciudad.Nombre= conjunto.Tables[0].Rows[i]["nombre"] + "";
                    ciudad.Distrito= conjunto.Tables[0].Rows[i]["distrito"]+"";
                    ciudad.Poblacion= Convert.ToInt32( conjunto.Tables[0].Rows[i]["poblacion"]);
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

                if (conjunto.Tables[0].Rows.Count==0)
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
                _comando.CommandText = "seleccionarCiudadPorCriterio";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pIdPais", pIdPais);
                _comando.Parameters.AddWithValue("pNombre", pNombre);
                _comando.Parameters.AddWithValue("pDistrito", pDistrito);
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

        #endregion
    }
}
