using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial:Llamada
    {
        protected Franja _franjaHoraria;

        public Provincial(Franja MiFranja, Llamada UnaLlamada): base(UnaLlamada.Nr0Origen, UnaLlamada.Nr0Destino, UnaLlamada.Duracion) 
        {
            this._franjaHoraria = MiFranja;
        }
        public Provincial(string Origen,Franja MiFranja, int Duracion, string Destino) : base(Origen, Destino, Duracion) 
        {
            this._franjaHoraria = MiFranja;
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
            float costo = 0;
            switch (this._franjaHoraria) 
            {
                case Franja.Franja_1:
                    costo = (this.Duracion * 0.99f)/60;
                    break;
                case Franja.Franja_2:
                    costo = (this.Duracion * 1.25f)/60;
                    break;
                case Franja.Franja_3:
                    costo = (this.Duracion * 0.66f)/60;
                    break;
            }
            return costo;
        }
        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            /*sb.AppendLine("Numero de Origen: " + this.Nr0Origen);
            sb.AppendLine("Numero del Destino: " + this.Nr0Destino);
            sb.AppendLine("Duracion de la llamada : " + this.Duracion);*/
            base.Mostrar();
            sb.AppendLine("Franja Horaria: " + this._franjaHoraria);
            sb.AppendLine("El costo de la llamada es: " + this.CostoLlamada);
            Console.WriteLine(sb.ToString());
        }
    }
}
