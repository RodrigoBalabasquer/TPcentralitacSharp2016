﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CentralitaSerializacion
{   
    [XmlInclude(typeof(Provincial))]
    [XmlInclude(typeof(Local))]
    public abstract class Llamada
    {
        protected float _duracion;
        protected string _nr0Destino;
        protected string _nr0Origen;
        #region Constructores
        public Llamada() { }
        public Llamada(string Origen, string Destino, float Duracion)
        {
            this._duracion = Duracion;
            this._nr0Origen = Origen;
            this._nr0Destino = Destino;
        }
        #endregion
        #region Propiedades
        public abstract float CostoLlamada
        {
            get;
        }
        public float Duracion
        {
            get
            {
                return this._duracion;
            }
            set 
            {
                this._duracion = value;
            }
        }
        public string Nr0Destino
        {
            get
            {
                return this._nr0Destino;
            }
            set
            {
                this._nr0Destino = value;
            }
        }
        public string Nr0Origen
        {
            get
            {
                return this._nr0Origen;
            }
            set
            {
                this._nr0Origen = value;
            }
        }
        #endregion
        #region Metodos
        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if (llamada1._duracion > llamada2._duracion)
            {
                return 1;
            }
            if (llamada2._duracion > llamada1._duracion)
            {
                return -1;
            }
            return 0;
        }
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Numero de Origen: " + this._nr0Origen);
            sb.AppendLine("Numero del Destino: " + this._nr0Destino);
            sb.AppendLine("Duracion de la llamada : " + this._duracion);
            return sb.ToString();
        }
        #endregion
        #region Operadores
        public static bool operator ==(Llamada llamadaUno, Llamada llamadaDos)
        {
            if (llamadaUno.Equals(llamadaDos) && llamadaUno._nr0Destino == llamadaDos._nr0Destino && llamadaUno._nr0Origen == llamadaDos._nr0Origen)
                return true;
            return false;
        }
        public static bool operator !=(Llamada llamadaUno, Llamada llamadaDos)
        {
            if (llamadaUno == llamadaDos)
                return false;
            return true;
        }
        #endregion
    }
}
