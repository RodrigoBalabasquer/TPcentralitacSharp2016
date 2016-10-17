using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Local:Llamada
    {
        protected float _costo;
        public Local(Llamada UnaLlamada, float Costo)
            : base(UnaLlamada.Nr0Origen, UnaLlamada.Nr0Destino, UnaLlamada.Duracion)
        {
            this._costo = Costo;
        }
        public Local(string Origen, int Duracion, string Destino, float Costo)
            : base(Origen, Destino, Duracion)
        {
            this._costo = Costo;
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
            return (this._costo * this.Duracion) / 60;
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
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
