using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para las operaciones SQL de la tabla Idioma
    /// </summary>
    public class MySQLIdiomaDAO : MySQLDAO, IdiomaDAO
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MySQLIdiomaDAO(): base()
        { }

        #region Miembros de IdiomaDAO

        public bool insert(IdiomaDTO pIdioma)
        {
            try
            {
                
                // TODO Completar para llamar al procedimiento que inserta un idioma
                _comando.CommandText = "insertarIdioma";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nNombre", pIdioma.Nombre);
                _comando.Parameters.AddWithValue("nOficial", pIdioma.Oficial);
                _comando.Parameters.AddWithValue("nPorcentajeUtilizacion", pIdioma.PorcentajeUtilizacion);
                _comando.Parameters.AddWithValue("nCodigo_pais", pIdioma.IdPais);
                
                _conexion.Open();
                _comando.ExecuteNonQuery();
                _conexion.Close();
                //
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

        public bool update(IdiomaDTO pIdioma)
        {
            try
            {
                // TODO Completar para llamar al procedimiento que actualiza un idioma
                _comando.CommandText = "actualizarIdioma";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nId_idioma", pIdioma.IdIdioma);
                _comando.Parameters.AddWithValue("nNombre", pIdioma.Nombre);
                _comando.Parameters.AddWithValue("nOficial", pIdioma.Oficial);
                _comando.Parameters.AddWithValue("nPorcentajeUtilizacion", pIdioma.PorcentajeUtilizacion);
                _comando.Parameters.AddWithValue("nCodigo_pais", pIdioma.IdPais);
                
                _conexion.Open();
                _comando.ExecuteNonQuery();
                _conexion.Close();
                //
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

        public bool delete(IdiomaDTO pIdioma)
        {
            try
            {
                // TODO Completar para llamar al procedimiento que elimina a un idioma
                _comando.CommandText = "eliminarIdioma";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nId_idioma", pIdioma.IdIdioma);

                _conexion.Open();
                _comando.ExecuteNonQuery();
                _conexion.Close();
                //
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
                    idioma.Nombre= conjunto.Tables[0].Rows[i]["nombre"] + "";
                    idioma.Oficial= Convert.ToInt32( conjunto.Tables[0].Rows[i]["oficial"]);
                    idioma.PorcentajeUtilizacion= Convert.ToDouble( conjunto.Tables[0].Rows[i]["porcentajeUtilizacion"]);
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

        public IdiomaDTO selectByPK(IdiomaDTO pIdioma)
        {
            try
            {
                DataSet conjunto = new DataSet();
                IdiomaDTO idioma = new IdiomaDTO();

                // TODO Completar para llamar al procedimiento que devuelve un país de acuerdo con su ID
                _comando.CommandText = "seleccionarIdiomaPorPK";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nIdCiudad", pIdioma.IdIdioma);

                _adaptador.Fill(conjunto);
                //

                if (conjunto.Tables[0].Rows.Count==0)
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

        public List<IdiomaDTO> selectByCriteria(string pIdPais, string pNombre, int pOficial)
        {
            try
            {
                List<IdiomaDTO> lista = new List<IdiomaDTO>();
                DataSet conjunto = new DataSet();

                // TODO Completar para llamar al procedimiento que devuelve los idiomas de acuerdo con los parámetros dados
                _comando.CommandText = "seleccionarIdiomaPorCriterio";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pIdPais", pIdPais);
                _comando.Parameters.AddWithValue("pNombre", pNombre);
                _comando.Parameters.AddWithValue("pOficial", pOficial);
                _adaptador.Fill(conjunto);
                //
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    IdiomaDTO idioma = new IdiomaDTO();

                    idioma.IdIdioma = Convert.ToInt32(conjunto.Tables[0].Rows[i]["id_idioma"]);
                    idioma.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    idioma.Oficial = Convert.ToInt32( conjunto.Tables[0].Rows[i]["oficial"]);
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
        #endregion
    }
}
