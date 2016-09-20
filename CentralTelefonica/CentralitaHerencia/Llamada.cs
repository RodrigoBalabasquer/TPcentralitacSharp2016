﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Llamada
    {
        protected float _duracion;
        protected string _nr0Destino;
        protected string _nr0Origen;

        public Llamada(string Origen, string Destino, float Duracion) 
        {
            this._duracion = Duracion;
            this._nr0Origen = Origen;
            this._nr0Destino = Destino;
        }
        public float Duracion 
        {
            get 
            {
                return this._duracion;
            }
        }
        public string Nr0Destino
        {
            get
            {
                return this._nr0Destino;
            }
        }
        public string Nr0Origen
        {
            get
            {
                return this._nr0Origen;
            }
        }
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
        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Numero de Origen: " + this._nr0Origen);
            sb.AppendLine("Numero del Destino: " + this._nr0Destino);
            sb.AppendLine("Duracion de la llamada : " + this._duracion);
            Console.WriteLine(sb.ToString());
        }
    }
}