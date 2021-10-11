using fabricaDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Fábrica de objetos DAO
    /// </summary>
    public abstract class DAOFactory 
    {
        /// <summary>
        /// Devuelve un objeto PaisDAO
        /// </summary>
        public abstract PaisDAO darPaisDAO();

        /// <summary>
        /// Devuelve un objeto CiudadDAO
        /// </summary>
        public abstract CiudadDAO darCiudadDAO();

        /// <summary>
        /// Devuelve un objeto IdiomaDAO
        /// </summary>
        public abstract IdiomaDAO darIdiomaDAO();

        /// <summary>
        /// Devuelve un objeto ExtensionDAO
        /// </summary>
        public abstract ExtensionDAO darExtensionDAO();

        /// <summary>
        /// Devuelve la fábrica de acuerdo con el tipo dado
        /// </summary>
        /// <param name="tipo">Tipo de fábrica a devolver</param>
        public static DAOFactory darFactory(TipoDAO tipo)
        {
            DAOFactory fabrica = null;
            switch (tipo)
            {
                case TipoDAO.ORACLE:
                    break;
                case TipoDAO.MYSQL:
                    fabrica = new MysqlDAOFactory();
                    break;
                case TipoDAO.SQLSERVER:
                    break;
                case TipoDAO.POSTGRESQL:
                    fabrica = new PostgreSQLDAOFactory();
                    break;
                default:
                    break;
            }

            return fabrica;
        }

    }
}
