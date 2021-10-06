using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Servicios SQL de la tabla Idioma
    /// </summary>
    public interface IdiomaDAO
    {
        /// <summary>
        /// Inserta un nuevo idioma
        /// </summary>
        /// <param name="pIdioma">Idioma a insertar</param>
        /// <returns>True - si correctamente se inserta el registro</returns>
        bool insert(IdiomaDTO pIdioma);

        /// <summary>
        /// Actualiza un Idioma
        /// </summary>
        /// <param name="pIdioma">Idioma a actualizar</param>
        /// <returns>True -  si el idioma se modifica correctamente en la base de datos</returns>
        bool update(IdiomaDTO pIdioma);

        /// <summary>
        /// Elimina un Idioma
        /// </summary>
        /// <param name="pIdioma">Idioma a eliminar</param>
        /// <returns>true - si se elimina el idioma de la base de datos</returns>
        bool delete(IdiomaDTO pIdioma);

        /// <summary>
        /// Devuelve una lista con todos los idiomas
        /// </summary>
        List<IdiomaDTO> selectAll();

        /// <summary>
        /// Devuelve un Idioma de acuerdo con su PK
        /// </summary>
        /// <param name="pIdioma">Idioma a buscar</param>
        IdiomaDTO selectByPK(IdiomaDTO pIdioma);

        /// <summary>
        /// Selecciona de acuerdo con criterios
        /// </summary>
        /// <param name="pIdPais">Id de país a buscar</param>
        /// <param name="pNombre">Nombre de idioma a buscar</param>
        /// <param name="pOficial">Oficial o no el idioma a buscar</param>
        List<IdiomaDTO> selectByCriteria(string pIdPais, string pNombre, int pOficial);
    }
}
