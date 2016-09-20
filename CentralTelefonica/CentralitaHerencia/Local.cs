using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local:Llamada
    {
        protected float _costo;
        public Local(Llamada UnaLlamada, float Costo):base(UnaLlamada.Nr0Origen,UnaLlamada.Nr0Destino,UnaLlamada.Duracion) 
        {
            this._costo = Costo;
        }
        public Local(string Origen, int Duracion, string Destino, float Costo) : base(Origen, Destino, Duracion) 
        {
            this._costo = Costo;
        }
        public float CostoLlamada 
        {
            get 
            {
                return CalcularCosto();
            }
        }
        private float CalcularCosto() 
        {
            return (this._costo * this.Duracion)/60;
        }
        public void Mostrar() 
        {
            StringBuilder sb = new StringBuilder();
            /*sb.AppendLine("Numero de Origen: " + this.Nr0Origen);
            sb.AppendLine("Numero del Destino: " + this.Nr0Destino);
            sb.AppendLine("Duracion de la llamada : " + this.Duracion);*/
            base.Mostrar();
            sb.AppendLine("El costo de la llamada es: " + this.CostoLlamada);
            Console.WriteLine(sb.ToString());
        }
    }
    
}
