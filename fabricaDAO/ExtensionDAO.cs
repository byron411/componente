using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace fabricaDatos
{
    /// <summary>
    /// Servicios SQL de extensión
    /// </summary>
    public interface ExtensionDAO
    {
        /// <summary>
        /// Devuelve un conjunto de datos sin aplicar filtro
        /// </summary>
        DataSet selectSinParametros();

        /// <summary>
        /// Devuelve un conjunto de registros dado un parámetro
        /// </summary>
        /// <param name="pParametro">Parámetro de búsqueda</param>
        DataSet select1Parametro(string pParametro);

        /// <summary>
        /// Devuelve un conjunto de registros dados dos parámetros
        /// </summary>
        /// <param name="pParametro1">Primer parámetro de búsqueda</param>
        /// <param name="pParametro2">Segundo parámetro de búsqueda</param>
        DataSet select2Parametros(string pParametro1, string pParametro2);

        /// <summary>
        /// Devuelve un conjunto de registros dados tres parámetros
        /// </summary>
        /// <param name="pParametro1">Primer parámetro de búsqueda</param>
        /// <param name="pParametro2">Segundo parámetro de búsqueda</param>
        /// <param name="pParametro3">Tercer parámetro de búsqueda</param>
        DataSet select3Parametros(string pParametro1, string pParametro2, string pParametro3);

        /// <summary>
        /// Modifica (insert, update, delete) sin parámetros
        /// </summary>
        int modifySinParametros();

        /// <summary>
        /// Modifica datos dado un parámetro
        /// </summary>
        /// <param name="pParametro">Parámetro para utilizar en la modificación</param>
        int modify1Parametro(string pParametro);

        /// <summary>
        /// Modifica datos dados dos parámetros
        /// </summary>
        /// <param name="pParametro1">Primer parámetro para utilizar en la modificación</param>
        /// <param name="pParametro2">Segundo parámetro para utilizar en la modificación</param>
        int modify2Parametros(string pParametro1, string pParametro2);

        /// <summary>
        /// Modifica datos dados tres parámetros
        /// </summary>
        /// <param name="pParametro1">Primer parámetro para utilizar en la modificación</param>
        /// <param name="pParametro2">Segundo parámetro para utilizar en la modificación</param>
        /// <param name="pParametro3">Tercerparámetro para utilizar en la modificación</param>
        int modify3Parametros(string pParametro1, string pParametro2, string pParametro3);
    }
}
