using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para las operaciones SQL de la tabla Pais
    /// </summary>
    public class MySQLPaisDAO : MySQLDAO, PaisDAO
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MySQLPaisDAO(): base()
        {}

        #region Miembros de PaisDAO

        /// <summary>
        /// Inserta un país a la base de datos
        /// </summary>
        /// <param name="pPais">País a insertar</param>
        public bool insert(PaisDTO pPais)
        {
            try
            {
                PaisDTO nuevo = selectByPK(pPais);

                if (nuevo != null)
                {
                    throw new Exception("El país ya existe !..");
                }

                nuevo = selectByNombre(pPais);

                if (nuevo != null)
                {
                    throw new Exception("El país ya existe !..");
                }

                // TODO Completar para llamar al procedimiento que inserta un país
                _comando.CommandText = "insertarPais";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nCodigo_Pais", pPais.IdPais);
                _comando.Parameters.AddWithValue("nNombre", pPais.Nombre);
                _comando.Parameters.AddWithValue("nContinente", pPais.Continente);
                _comando.Parameters.AddWithValue("nRegion", pPais.Region);
                _comando.Parameters.AddWithValue("nSuperficie", pPais.Superficie);
                _comando.Parameters.AddWithValue("nAnioIndependencia", pPais.AnioIndependencia);
                _comando.Parameters.AddWithValue("nPoblacion", pPais.Poblacion);
                _comando.Parameters.AddWithValue("nEsperanzaVida", pPais.EsperanzaVida);
                _comando.Parameters.AddWithValue("nPib", pPais.Pib);
                _comando.Parameters.AddWithValue("nFormaGobierno", pPais.FormaGobierno);
                _comando.Parameters.AddWithValue("nPresidente", pPais.Presidente);

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

        /// <summary>
        /// Actualiza en la base de datos un país dado
        /// </summary>
        /// <param name="pPais">País a actualizar</param>
        public bool update(PaisDTO pPais)
        {
            try
            {
                PaisDTO nuevo;

                nuevo = selectByNombre(pPais);

                if (nuevo != null)
                {
                    throw new Exception("El país ya existe !..");
                }
                // TODO Completar para llamar al procedimiento que actualiza un país
                _comando.CommandText = "actualizarPais";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nCodigo_Pais", pPais.IdPais);
                _comando.Parameters.AddWithValue("nNombre", pPais.Nombre);
                _comando.Parameters.AddWithValue("nContinente", pPais.Continente);
                _comando.Parameters.AddWithValue("nRegion", pPais.Region);
                _comando.Parameters.AddWithValue("nSuperficie", pPais.Superficie);
                _comando.Parameters.AddWithValue("nAnioIndependencia", pPais.AnioIndependencia);
                _comando.Parameters.AddWithValue("nPoblacion", pPais.Poblacion);
                _comando.Parameters.AddWithValue("nEsperanzaVida", pPais.EsperanzaVida);
                _comando.Parameters.AddWithValue("nPib", pPais.Pib);
                _comando.Parameters.AddWithValue("nFormaGobierno", pPais.FormaGobierno);
                _comando.Parameters.AddWithValue("nPresidente", pPais.Presidente);

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

        /// <summary>
        /// Elimina el país de la base de datos
        /// </summary>
        /// <param name="pPais">País a eliminar</param>
        public bool delete(PaisDTO pPais)
        {
            try
            {
                PaisDTO nuevo;

                nuevo = selectByPK(pPais);

                if (nuevo == null)
                {
                    throw new Exception("El país NO existe !..");
                }

                int numCiudades = selectCiudadesByPais(pPais.IdPais);
                if (numCiudades>0)
                {
                    throw new Exception("El país tiene ciudades registradas, NO se puede eliminar !..");
                }

                int numIdiomas = selectIdiomasByPais(pPais.IdPais);
                if (numIdiomas > 0)
                {
                    throw new Exception("El país tiene idiomas registrados, NO se puede eliminar !..");
                }
                 // TODO Completar para llamar al procedimiento que elimina a un país
                _comando.CommandText = "eliminarPais";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nCodigo_Pais", pPais.IdPais);

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

        /// <summary>
        /// Devuelve una lista con todos los países registrados en l base de datos
        /// </summary>
        public List<PaisDTO> selectAll()
        {
            try
            {
                List<PaisDTO> lista = new List<PaisDTO>();
                DataSet conjunto = new DataSet();

               // TODO Completar método para llamar al procedimiento que devuelve todos los países
                _comando.CommandText = "seleccionarPais";
                _comando.Parameters.Clear();
                _adaptador.Fill(conjunto);
                //
                for (int i=0; i< conjunto.Tables[0].Rows.Count; i++)
                {
                    PaisDTO pais = new PaisDTO();

                    pais.AnioIndependencia = Convert.ToInt32(conjunto.Tables[0].Rows[i]["anioIndependencia"]);
                    pais.Continente = conjunto.Tables[0].Rows[i]["continente"] + "";
                    pais.EsperanzaVida = Convert.ToInt32(conjunto.Tables[0].Rows[i]["esperanzaVida"]);
                    pais.FormaGobierno = conjunto.Tables[0].Rows[i]["formaGobierno"] + "";
                    pais.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";
                    pais.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    pais.Pib = Convert.ToDouble(conjunto.Tables[0].Rows[i]["pib"]);
                    pais.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[i]["poblacion"]);
                    pais.Presidente = conjunto.Tables[0].Rows[i]["presidente"] + "";
                    pais.Region = conjunto.Tables[0].Rows[i]["region"] + "";
                    pais.Superficie = Convert.ToDouble(conjunto.Tables[0].Rows[i]["superficie"]);

                    lista.Add(pais);
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
        /// Devuelve un pais dado su valor PK
        /// </summary>
        /// <param name="pPais">País a buscar</param>
        public PaisDTO selectByPK(PaisDTO pPais)
        {
            try
            {
                DataSet conjunto = new DataSet();
                PaisDTO pais = new PaisDTO();

                // TODO Completar para llamar al procedimiento que devuelve un país de acuerdo con su ID
                _comando.CommandText = "seleccionarPaisPorPK";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nIdpais", pPais.IdPais);

                _adaptador.Fill(conjunto);
                //

                if (conjunto.Tables[0].Rows.Count==0)
                {
                    return null;
                }

                pais.AnioIndependencia = Convert.ToInt32( conjunto.Tables[0].Rows[0]["anioIndependencia"]);
                pais.Continente = conjunto.Tables[0].Rows[0]["continente"]+"";
                pais.EsperanzaVida = Convert.ToInt32( conjunto.Tables[0].Rows[0]["esperanzaVida"]);
                pais.FormaGobierno = conjunto.Tables[0].Rows[0]["formaGobierno"]+"";
                pais.IdPais = conjunto.Tables[0].Rows[0]["codigo_pais"]+"";
                pais.Nombre = conjunto.Tables[0].Rows[0]["nombre"]+"";
                pais.Pib = Convert.ToDouble( conjunto.Tables[0].Rows[0]["pib"]);
                pais.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[0]["poblacion"]);
                pais.Presidente = conjunto.Tables[0].Rows[0]["presidente"]+"";
                pais.Region = conjunto.Tables[0].Rows[0]["region"]+"";
                pais.Superficie = Convert.ToDouble( conjunto.Tables[0].Rows[0]["superficie"]);

                return pais;
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

        /// <summary>
        /// Devuelve un país dado su nombre
        /// </summary>
        /// <param name="pPais">País s buscar</param>
        public PaisDTO selectByNombre(PaisDTO pPais)
        {
            DataSet conjunto = new DataSet();
            PaisDTO pais = new PaisDTO();

            _comando.CommandText = "seleccionarPaisPorNombre";
            _comando.Parameters.Clear();
            _comando.Parameters.AddWithValue("nNombre", pPais.Nombre);
            _comando.Parameters.AddWithValue("nIdPais", pPais.IdPais);

            _adaptador.Fill(conjunto);

            if (conjunto.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            pais.AnioIndependencia = Convert.ToInt32(conjunto.Tables[0].Rows[0]["anioIndependencia"]);
            pais.Continente = conjunto.Tables[0].Rows[0]["continente"] + "";
            pais.EsperanzaVida = Convert.ToInt32(conjunto.Tables[0].Rows[0]["esperanzaVida"]);
            pais.FormaGobierno = conjunto.Tables[0].Rows[0]["formaGobierno"] + "";
            pais.IdPais = conjunto.Tables[0].Rows[0]["codigo_pais"] + "";
            pais.Nombre = conjunto.Tables[0].Rows[0]["nombre"] + "";
            pais.Pib = Convert.ToDouble(conjunto.Tables[0].Rows[0]["pib"]);
            pais.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[0]["poblacion"]);
            pais.Presidente = conjunto.Tables[0].Rows[0]["presidente"] + "";
            pais.Region = conjunto.Tables[0].Rows[0]["region"] + "";
            pais.Superficie = Convert.ToDouble(conjunto.Tables[0].Rows[0]["superficie"]);

            return pais;
        }

        /// <summary>
        /// Devuelve una lista de países de acuerdo con id, nombre y presidente
        /// </summary>
        /// <param name="pIdPais">Id de país a buscar</param>
        /// <param name="pNombre">Nombre de país a buscar</param>
        /// <param name="pPresidente">Presidente a buscar</param>
        public List<PaisDTO> selectByCriteria(string pIdPais, string pNombre, string pPresidente)
        {
            try
            {
                List<PaisDTO> lista = new List<PaisDTO>();
                DataSet conjunto = new DataSet();

                // TODO Completar para llamar al procedimiento que devuelve los países de acuerdo con los parámetros dados
                _comando.CommandText = "seleccionarPaisPorCriterio";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pIdPais", pIdPais);
                _comando.Parameters.AddWithValue("pNombre", pNombre);
                _comando.Parameters.AddWithValue("pPresidente", pPresidente);
                _adaptador.Fill(conjunto);
                //
                for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                {
                    PaisDTO pais = new PaisDTO();

                    pais.AnioIndependencia = Convert.ToInt32(conjunto.Tables[0].Rows[i]["anioIndependencia"]);
                    pais.Continente = conjunto.Tables[0].Rows[i]["continente"] + "";
                    pais.EsperanzaVida = Convert.ToInt32(conjunto.Tables[0].Rows[i]["esperanzaVida"]);
                    pais.FormaGobierno = conjunto.Tables[0].Rows[i]["formaGobierno"] + "";
                    pais.IdPais = conjunto.Tables[0].Rows[i]["codigo_pais"] + "";
                    pais.Nombre = conjunto.Tables[0].Rows[i]["nombre"] + "";
                    pais.Pib = Convert.ToDouble(conjunto.Tables[0].Rows[i]["pib"]);
                    pais.Poblacion = Convert.ToInt32(conjunto.Tables[0].Rows[i]["poblacion"]);
                    pais.Presidente = conjunto.Tables[0].Rows[i]["presidente"] + "";
                    pais.Region = conjunto.Tables[0].Rows[i]["region"] + "";
                    pais.Superficie = Convert.ToDouble(conjunto.Tables[0].Rows[i]["superficie"]);

                    lista.Add(pais);
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
        /// Devuelve la cantidad de ciudades registradas a un país dado
        /// </summary>
        /// <param name="pIdPais">País a buscarle la cantidad de ciudades</param>
        public int selectCiudadesByPais(string pIdPais)
        {
            try
            {
                int numregistros = 0;
                DataSet conjunto = new DataSet();

               // TODO Completar para llamar al procedimiento que devuelve las ciudades del id de país dado
                _comando.CommandText = "seleccionarCiudadesPorPais";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pIdPais", pIdPais);
                _adaptador.Fill(conjunto);
                //
                numregistros = conjunto.Tables[0].Rows.Count;
                return numregistros;
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
        /// Devuelve la cantidad de idiomas registrados a un país dado
        /// </summary>
        /// <param name="pIdPais">País a buscarle la cantidad de idiomas</param>
        public int selectIdiomasByPais(string pIdPais)
        {
            try
            {
                int numregistros = 0;
                DataSet conjunto = new DataSet();

                _comando.CommandText = "seleccionarIdiomasPorPais";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pIdPais", pIdPais);
                _adaptador.Fill(conjunto);

                numregistros = conjunto.Tables[0].Rows.Count;
                return numregistros;
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
