using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Servicios SQL de la tabla Ciudad
    /// </summary>
    public interface CiudadDAO
    {
        /// <summary>
        /// Inserta una nueva Ciudad
        /// </summary>
        /// <param name="pCiudad">Ciudad a insertar</param>
        /// <returns>True - si correctamente se inserta el registro</returns>
        bool insert(CiudadDTO pCiudad);

        /// <summary>
        /// Actualiza una Ciudad
        /// </summary>
        /// <param name="pCiudad">Ciudad a actualizar</param>
        /// <returns>True -  si la ciudad se modifica correctamente en la base de datos</returns>
        bool update(CiudadDTO pCiudad);

        /// <summary>
        /// Elimina una Ciudad
        /// </summary>
        /// <param name="pCiudad">Ciudad a eliminar</param>
        /// <returns>true - si se elimina la ciudad de la base de datos</returns>
        bool delete(CiudadDTO pCiudad);

        /// <summary>
        /// Devuelve una lista con todos las Ciudades
        /// </summary>
        List<CiudadDTO> selectAll();

        /// <summary>
        /// Devuelve una Ciudad de acuerdo con su PK
        /// </summary>
        /// <param name="pCiudad">Ciudad a buscar</param>
        CiudadDTO selectByPK(CiudadDTO pCiudad);

        /// <summary>
        /// Selecciona de acuerdo con criterios
        /// </summary>
        /// <param name="pIdPais">Id de país a buscar</param>
        /// <param name="pNombre">Nombre de ciudad a buscar</param>
        /// <param name="pDistrito">Distrito a buscar</param>
        List<CiudadDTO> selectByCriteria(string pIdPais, string pNombre, string pDistrito);
    }
}
