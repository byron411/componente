using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para las operaciones de extensión
    /// </summary>
    public class MySQLExtensionDAO: MySQLDAO, ExtensionDAO
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MySQLExtensionDAO():base()
        {}

        #region Miembros de ExtensionDAO

        public DataSet selectSinParametros()
        {
            try
            {
                DataSet conjunto = new DataSet();
                // Completar código según las necesidades
                
                return conjunto;
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

        public DataSet select1Parametro(string pParametro)
        {
            try
            {
                DataSet conjunto = new DataSet();
                // Completar código según las necesidades
                return conjunto;
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

        public DataSet select2Parametros(string pParametro1, string pParametro2)
        {
            try
            {
                DataSet conjunto = new DataSet();
                // Completar código según las necesidades
                
                _comando.CommandText = "lab7-requerimiento1";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pRegion", pParametro1);
                _comando.Parameters.AddWithValue("pPoblacion", pParametro2);

                _adaptador.Fill(conjunto);
                
                
                return conjunto;
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

        public DataSet select3Parametros(string pParametro1, string pParametro2, string pParametro3)
        {
            try
            {
                DataSet conjunto = new DataSet();
                // Completar código según las necesidades

                _comando.CommandText = "requerimiento2";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("pContinente", pParametro1); 
                _comando.Parameters.AddWithValue("pEsperanzaVida", pParametro2);
                _comando.Parameters.AddWithValue("pPorcentaje", pParametro3);

                _adaptador.Fill(conjunto);
                return conjunto;
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

        public int modifySinParametros()
        {
            try
            {
                // Completar código según las necesidades
                int resultado;
                _comando.CommandText = "generarPlano";
                _conexion.Open();
                resultado = _comando.ExecuteNonQuery();
                _conexion.Close();
                return resultado;
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

        public int modify1Parametro(string pParametro)
        {
            try
            {
                // Completar código según las necesidades
                return -1;
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

        public int modify2Parametros(string pParametro1, string pParametro2)
        {
            try
            {
                // Completar código según las necesidades
                return -1;
            }
            catch (Exception error)
            {
                // Completar código según las necesidades
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

        public int modify3Parametros(string pParametro1, string pParametro2, string pParametro3)
        {
            try
            {
                // Completar código según las necesidades
                return -1;
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
