using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para los objetos de transferencia de objetos de la tabla ciudad
    /// </summary>
    public class IdiomaDTO
    {
        /// <summary>
        /// Identificador de idioma
        /// </summary>
        private int _idIdioma;

        /// <summary>
        /// Identificador de idioma
        /// </summary>
        public int IdIdioma
        {
            get { return _idIdioma; }
            set { _idIdioma = value; }
        }
        /// <summary>
        /// Nombre del idioma
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Nombre del idioma
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Oficial o no el idioma en el país
        /// </summary>
        private int _oficial;

        /// <summary>
        /// Oficial o no el idioma en el país
        /// </summary>
        public int Oficial
        {
            get { return _oficial; }
            set { _oficial = value; }
        }
        /// <summary>
        /// Porcentaje de utilización del idioma en el país
        /// </summary>
        private double _porcentajeUtilizacion;

        /// <summary>
        /// Porcentaje de utilización del idioma en el país
        /// </summary>
        public double PorcentajeUtilizacion
        {
            get { return _porcentajeUtilizacion; }
            set { _porcentajeUtilizacion = value; }
        }
        /// <summary>
        /// Id de país donde se habla el idioma
        /// </summary>
        private string _idPais;

        /// <summary>
        /// Id de país donde se habla el idioma
        /// </summary>
        public string IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public IdiomaDTO()
        {
            
        }
    }
}
