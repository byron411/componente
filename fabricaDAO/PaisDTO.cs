using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fabricaDatos
{
    /// <summary>
    /// Clase para los objetos de transferencia de datos para País
    /// </summary>
    public class PaisDTO
    {
        /// <summary>
        /// Identificador del país
        /// </summary>
        private string _idPais;

        /// <summary>
        /// Identificador del país
        /// </summary>
        public string IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        /// <summary>
        /// Nombre del país
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Nombre del país
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Continente del país
        /// </summary>
        private string _continente;

        /// <summary>
        /// Continente del país
        /// </summary>
        public string Continente
        {
            get { return _continente; }
            set { _continente = value; }
        }
        /// <summary>
        /// Region del continente donse se ubica el país
        /// </summary>
        private string _region;

        /// <summary>
        /// Region del continente donse se ubica el país
        /// </summary>
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        /// <summary>
        /// Kilómetros cuadrados de área del país
        /// </summary>
        private double _superficie;

        /// <summary>
        /// Kilómetros cuadrados de área del país
        /// </summary>
        public double Superficie
        {
            get { return _superficie; }
            set { _superficie = value; }
        }
        /// <summary>
        /// Año de independencia del país
        /// </summary>
        private int _anioIndependencia;

        /// <summary>
        /// Año de independencia del país
        /// </summary>
        public int AnioIndependencia
        {
            get { return _anioIndependencia; }
            set { _anioIndependencia = value; }
        }
        /// <summary>
        /// Cantidad de habitantes del país
        /// </summary>
        private int _poblacion;

        /// <summary>
        /// Cantidad de habitantes del país
        /// </summary>
        public int Poblacion
        {
            get { return _poblacion; }
            set { _poblacion = value; }
        }
        /// <summary>
        /// Máxima edad de los habitantes del país
        /// </summary>
        private double _esperanzaVida;

        /// <summary>
        /// Máxima edad de los habitantes del país
        /// </summary>
        public double EsperanzaVida
        {
            get { return _esperanzaVida; }
            set { _esperanzaVida = value; }
        }
        /// <summary>
        /// Valor del producto inerno bruto del país
        /// </summary>
        private double _pib;

        /// <summary>
        /// Valor del producto inerno bruto del país
        /// </summary>
        public double Pib
        {
            get { return _pib; }
            set { _pib = value; }
        }
        /// <summary>
        /// Clase de gobierno del país
        /// </summary>
        private string _formaGobierno;

        /// <summary>
        /// Clase de gobierno del país
        /// </summary>
        public string FormaGobierno
        {
            get { return _formaGobierno; }
            set { _formaGobierno = value; }
        }
        /// <summary>
        /// Nombre del presidente actual
        /// </summary>
        private string _presidente;

        /// <summary>
        /// Nombre del presidente actual
        /// </summary>
        public string Presidente
        {
            get { return _presidente; }
            set { _presidente = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public PaisDTO()
        {
            
        }
    }
}
