using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Provincial:Llamada
    {
        protected Franja _franjaHoraria;
        public Provincial(Franja MiFranja, Llamada UnaLlamada)
            : base(UnaLlamada.Nr0Origen, UnaLlamada.Nr0Destino, UnaLlamada.Duracion)
        {
            this._franjaHoraria = MiFranja;
        }
        public Provincial(string Origen, Franja MiFranja, int Duracion, string Destino)
            : base(Origen, Destino, Duracion)
        {
            this._franjaHoraria = MiFranja;
        }
        public override float CostoLlamada
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
                    costo = (this.Duracion * 0.99f) / 60;
                    break;
                case Franja.Franja_2:
                    costo = (this.Duracion * 1.25f) / 60;
                    break;
                case Franja.Franja_3:
                    costo = (this.Duracion * 0.66f) / 60;
                    break;
            }
            return costo;
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Franja Horaria: " + this._franjaHoraria);
            sb.AppendLine("El costo de la llamada es: " + this.CostoLlamada);
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
                return true;
                return false;
        }
    }
}
