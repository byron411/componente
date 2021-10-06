using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para los objetos de transferencia de objetos de la tabla ciudad
    /// </summary>
    public class CiudadDTO
    {
        /// <summary>
        /// Identificador de ciudad
        /// </summary>
        private int _idCiudad;

        /// <summary>
        /// Identificador de ciudad
        /// </summary>
        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Distrito donde se encuentra la ciudad
        /// </summary>
        private string _distrito;

        /// <summary>
        /// Distrito donde se encuentra la ciudad
        /// </summary>
        public string Distrito
        {
            get { return _distrito; }
            set { _distrito = value; }
        }
        /// <summary>
        /// Cantidad de habitantes
        /// </summary>
        private int _poblacion;

        /// <summary>
        /// Cantidad de habitantes
        /// </summary>
        public int Poblacion
        {
            get { return _poblacion; }
            set { _poblacion = value; }
        }
        /// <summary>
        /// Id de país donde se ubica la ciudad
        /// </summary>
        private string _idPais;

        /// <summary>
        /// Id de país donde se ubica la ciudad
        /// </summary>
        public string IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public CiudadDTO()
        {
            
        }
    }
}
