using System.Collections.Generic;
using fabricaDatos;
using Npgsql;
using System;
using System.Data;

namespace fabricaDAO
{
    //Clase para las operaciones SQL de la tabla pais
    public class PostgreSQLPaisDAO : PostgreSQLDAO, PaisDAO
    {
        public PostgreSQLPaisDAO() : base() { }
       
        //Métodos que implementa de la interfaz
        /*
         * Ingresa un nuevo país en caso de no haberse incluido
         * @param pPais objeto país a ingresar a la base de datos
         * @exception lanza una excepción si no logra ingresar el nuevo pais
         * @return devuelve verdadero en caso de no haber error
         */
        public bool insert(PaisDTO pPais)
        {
            try
            {
               //TODO consulta sql para insertar un pais                                 
                _conexion.Open();
                string sentencia= "insert into pais(codigo_pais,continente, nombre, region, anio, poblacion, esperanza, pib, gobierno, presidente, superficie) values('" + pPais.IdPais+"','"+pPais.Continente+"','"+pPais.Nombre+"','"+pPais.Region+"',"+pPais.AnioIndependencia+","+pPais.Poblacion+","+pPais.EsperanzaVida+","+pPais.Pib+",'"+pPais.FormaGobierno+"','"+pPais.Presidente+"',"+pPais.Superficie+");";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, _conexion);
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

        /*
         * Actualiza un determinado país
         * @param pPais nuevos datos
         * @exception lanza una excepción en caso de haber algún inconveniente con la base de datos
         * @return devueve verdadero en caso de acturalizar y no haber error
         */
        public bool update(PaisDTO pPais)
        {
            try
            {
               //TODO sql para moficicar un pais
                string sentencia = "update pais set nombre='Modificado' " +
                    "where codigo_pais='wxy';";
                _conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, _conexion);
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

        /*
         * Elimina un pais por su id
         * @param pPais para buscar el pais a eliminar a través de su id
         * @excep lanza un error si no se conecta a la base de datos
         * @return devulve verdadero en caso de eliminar un país
         */
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
                if (numCiudades > 0)
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

        /*
         * Devuelve una lista de todos los países en la base de datos
         * @return lista de objetos de tipo PaisDTO, lista vacia si no hay paises
         */
        public List<PaisDTO> selectAll()
        {
            Console.WriteLine("hola mundo");
            try
            {
                List<PaisDTO> lista = new List<PaisDTO>();
                DataSet conjunto = new DataSet();

                // TODO Completar método para llamar al procedimiento que devuelve todos los países
                //_comando.CommandText = "darpaises";
                //_comando.Parameters.Clear();
                string sql = "select codigo_pais from onu.pais;";
                _conexion.Open();
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                adaptador.Fill(conjunto);
                _conexion.Close();
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

        /*
         * Busca un país por llave primaria
         * @pPais objeto PaisDTO para acceder a la id y buscarlo 
         * @except lanza una excepción si no se logra conectar
         * @return objeto de tipo PasiDTO null si no lo encuentra
         */
        public PaisDTO selectByPK(PaisDTO pPais)
        {
            try
            {
                DataSet conjunto = new DataSet();
                PaisDTO pais = new PaisDTO();

                // TODO Completar para llamar al procedimiento que devuelve un país de acuerdo con su ID
                
                _comando.CommandText = "seleccionar_pais_pk";
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("nIdpais", pPais.IdPais);

                _adaptador.Fill(conjunto);
                //

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

        /*
         * Devuelve un país buscando por id, nombre y presidente
         * @param pIdPais identificación del país a buscar
         * @param pNombre nombre del país a buscar
         * @param pPresidente presidente del pais a buscar
         * @except lanza un error si hay un error conectandose
         * @return objeto de tipo PaisDTO, null si no lo encuentra
         */
        public List<PaisDTO> selectByCriteria(string pIdPais, string pNombre, string pPresidente)
        {
            
                try
                {
                    List<PaisDTO> lista = new List<PaisDTO>();
                    DataSet conjunto = new DataSet();

                // TODO Completar para ejecutar sql que devuelve los países de acuerdo con los parámetros dados
               
                //
                if (pIdPais == "" && pNombre == "" && pPresidente == "")
                {
                    string sql = "select * from pais;"; // where codigo_pais = 'ecu' and nombre = 'Ecuador' and presidente = 'lenin'; ";
                    _conexion.Open();
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                    adaptador.Fill(conjunto);
                    _conexion.Close();
                }
                else
                {
                    string sql = "select * from pais where codigo_pais ='"+pIdPais+"' or nombre='"+pNombre+"' or presidente='"+pPresidente+"' "; 
                        
                    _conexion.Open();
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, _conexion);
                    adaptador.Fill(conjunto);
                    _conexion.Close();
                }

                    for (int i = 0; i < conjunto.Tables[0].Rows.Count; i++)
                    {
                        PaisDTO pais = new PaisDTO();

                        pais.AnioIndependencia = Convert.ToInt32(conjunto.Tables[0].Rows[i]["anio"]);
                        pais.Continente = conjunto.Tables[0].Rows[i]["continente"] + "";
                        pais.EsperanzaVida = Convert.ToInt32(conjunto.Tables[0].Rows[i]["esperanza"]);
                        pais.FormaGobierno = conjunto.Tables[0].Rows[i]["gobierno"] + "";
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
            
        

        /*
         * Devuelve un país dado su nombre
         * @return el pais con el nombre dado null en caso contrario
         */
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


        //Métodos propios

        /*
         *Devuelve la cantidad de ciudades registradas por país
         * @param pIdPais elemento string que se recibe y se desea buscar
         * @exception lanza una excepción si ha ocurrido algún error en la base de datos
         * @return duvuelve 0 si no encuentra una ciudad correspondiente a ese pais
         */
        public int selectCiudadesByPais(String pIdPais)
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

        /*
         * Devuelve la cantidad de idiomas que tiene registrado un país
         * @param pIdPaís id del pais a buscar sus idiomas registrados
         * @exception lanza una excepción si ocurre un problema al conectarse a la base de datos
         * @return devuelve la cantidad de idiomas registrados a un país
         */
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