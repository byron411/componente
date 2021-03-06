using fabricaDatos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace fabricaDAO
{
    /// <summary>
    /// clase para las opereacione sql de la tabla idioma
    /// </summary>
    public class PostgreSQLIdiomaDAO : PostgreSQLDAO, IdiomaDAO
    {

        public PostgreSQLIdiomaDAO():base() { }


        //Métodos de la interfaz
        public bool insert(IdiomaDTO pIdioma)
        {
            try
            {

                // TODO Completar para ejecutar sql que inserta un idioma
                string sql = "insert into idioma (nombre, oficial, porcentajeutilizacion, codigo_pais) values('"+pIdioma.Nombre+"',"+pIdioma.Oficial+","+pIdioma.PorcentajeUtilizacion+",'"+pIdioma.IdPais+"');";
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
        /// Actualiza un Idioma
        /// </summary>
        /// <param name="pIdioma">Idioma a actualizar</param>
        /// <returns>True -  si el idioma se modifica correctamente en la base de datos</returns>
        public bool update(IdiomaDTO pIdioma)
        {
            try
            {
                // TODO Completar para ejecutar sql que actualiza un idioma
                string sql = "update idioma set nombre='" + pIdioma.Nombre + "', oficial=" + pIdioma.Oficial + ",porcentajeutilizacion=" + pIdioma.PorcentajeUtilizacion + ",codigo_pais='" + pIdioma.IdPais + "' where id_idioma=" + pIdioma.IdIdioma + ";";
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
        /// Elimina un Idioma
        /// </summary>
        /// <param name="pIdioma">Idioma a eliminar</param>
        /// <returns>true - si se elimina el idioma de la base de datos</returns>
        public bool delete(IdiomaDTO pIdioma)
        {
            try
            {
                // TODO Completar para ejecutar sql que elimina a un idioma
                string sql = "delete from idioma where id_idioma=" + pIdioma.IdIdioma + ";";
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
        /// Devuelve una lista con todos los idiomas
        /// </summary>
        public List<IdiomaDTO> selectAll()
        {
            try
            {
                List<IdiomaDTO> lista = new List<IdiomaDTO>();
                DataSet conjunto = new DataSet();

                // TODO Completar método para llamar al procedimiento que devuelve todos los idiomas
                _comando.CommandText = "seleccionarIdioma";
                _comando.Parameters.Clear();
                _adaptador.Fill(conjunto);
                //
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    IdiomaDTO idioma = new IdiomaDTO();

                    idioma.IdIdioma = Convert.ToInt32(conjunto.Tables[0].Rows[i]["id_idioma"]);
                    idioma.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    idioma.Oficial = Convert.ToInt32(conjunto.Tables[0].Rows[i]["oficial"]);
                    idioma.PorcentajeUtilizacion = Convert.ToDouble(conjunto.Tables[0].Rows[i]["porcentajeUtilizacion"]);
                    idioma.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";

                    lista.Add(idioma);
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
        /// Devuelve un Idioma de acuerdo con su PK
        /// </summary>
        /// <param name="pIdioma">Idioma a buscar</param>
        public IdiomaDTO selectByPK(IdiomaDTO pIdioma)
        {
            try
            {
                DataSet conjunto = new DataSet();
                IdiomaDTO idioma = new IdiomaDTO();

                // TODO Completar para ejecutar sql que devuelve un país de acuerdo con su ID
           
                string sql = "select * from idioma where id_idioma=" + pIdioma.IdIdioma + ";";
                _conexion.Open();
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                adaptador.Fill(conjunto);
                _conexion.Close();
                if (conjunto.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                idioma.IdIdioma = Convert.ToInt32(conjunto.Tables[0].Rows[0]["id_idioma"]);
                idioma.Nombre = conjunto.Tables[0].Rows[0]["nombre"] + "";
                idioma.Oficial = Convert.ToInt32(conjunto.Tables[0].Rows[0]["oficial"]);
                idioma.PorcentajeUtilizacion = Convert.ToDouble(conjunto.Tables[0].Rows[0]["porcentajeUtilizacion"]);
                idioma.IdPais = conjunto.Tables[0].Rows[0]["codigo_pais"] + "";

                return idioma;
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
        /// Selecciona de acuerdo con criterios
        /// </summary>
        /// <param name="pIdPais">Id de país a buscar</param>
        /// <param name="pNombre">Nombre de idioma a buscar</param>
        /// <param name="pOficial">Oficial o no el idioma a buscar</param>
        public List<IdiomaDTO> selectByCriteria(string pIdPais, string pNombre, int pOficial)
        {
            try
            {
                List<IdiomaDTO> lista = new List<IdiomaDTO>();
                DataSet conjunto = new DataSet();

                // TODO Completar para ejecutar sql que devuelve los idiomas de acuerdo con los parámetros dados
                if (pOficial == 1) { 
                string sql = "select * from idioma where codigo_pais='"+pIdPais+"' and oficial=1;";
                _conexion.Open();
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                adaptador.Fill(conjunto);
                _conexion.Close();
                }
                else if (pOficial == 0)
                {
                    string sql = "select * from idioma where codigo_pais='" + pIdPais + "' and oficial=0;";
                    _conexion.Open();
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                    adaptador.Fill(conjunto);
                    _conexion.Close();
                }
                else if (pNombre != "")
                {
                    string sql = "select * from idioma where codigo_pais='" + pIdPais + "' and nombre='"+pNombre+"';";
                    _conexion.Open();
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                    adaptador.Fill(conjunto);
                    _conexion.Close();
                }
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    IdiomaDTO idioma = new IdiomaDTO();

                    idioma.IdIdioma = Convert.ToInt32(conjunto.Tables[0].Rows[i]["id_idioma"]);
                    idioma.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    idioma.Oficial = Convert.ToInt32(conjunto.Tables[0].Rows[i]["oficial"]);
                    idioma.PorcentajeUtilizacion = Convert.ToDouble(conjunto.Tables[0].Rows[i]["porcentajeutilizacion"]);
                    idioma.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";

                    lista.Add(idioma);
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