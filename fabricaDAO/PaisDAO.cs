using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Servicios SQL de la tabla Pais
    /// </summary>
    public interface PaisDAO
    {
        /// <summary>
        /// Inserta un nuevo País
        /// </summary>
        /// <param name="pPais">País a insertar</param>
        /// <returns>True - si correctamente se inserta el registro</returns>
        bool insert(PaisDTO pPais);

        /// <summary>
        /// Actualiza un País
        /// </summary>
        /// <param name="pIdPais">País a modificarse</param>
        /// <param name="pPais">País a actualizar</param>
        /// <returns>True -  si el País se modifica correctamente en la base de datos</returns>
        bool update(PaisDTO pPais);

        /// <summary>
        /// Elimina un País
        /// </summary>
        /// <param name="pIdPais">País a eliminar</param>
        /// <param name="pPais">País a eliminar</param>
        /// <returns>true - si se elimina el país de la base de datos</returns>
        bool delete(PaisDTO pPais);

        /// <summary>
        /// Devuelve una lista con todos los Países
        /// </summary>
        List<PaisDTO> selectAll();

        /// <summary>
        /// Devuelve un País de acuerdo con su PK
        /// </summary>
        /// <param name="pIdPais">País a buscar</param>
        /// <param name="pPais">País a buscar</param>
        PaisDTO selectByPK(PaisDTO pPais);

         /// <summary>
        /// Selecciona de acuerdo con criterios
        /// </summary>
        /// <param name="pIdPais">Id de país a buscar</param>
        /// <param name="pNombre">Nombre de país a buscar</param>
        /// <param name="pPresidente">Presidente a buscar</param>
        List<PaisDTO> selectByCriteria(string pIdPais, string pNombre, string pPresidente);
    }
}
