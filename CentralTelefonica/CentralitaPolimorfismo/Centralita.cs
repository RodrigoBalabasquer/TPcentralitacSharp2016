using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string NombreDeEmpresa)
            : this()
        {
            this._razonSocial = NombreDeEmpresa;
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }
        public float GananciaPorLocal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            }
        }
        public float GananciaPorProvincial
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GananciaTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }
        private float CalcularGanancia(TipoLlamada tipo)
        {
            int i;
            float recaudacion = 0;
            Local aux1 = new Local("0", 0, " ", 0);
            Provincial aux2 = new Provincial("", Franja.Franja_1, 0, " ");
            switch (tipo)
            {
                case TipoLlamada.Local:
                    for (i = 0; i < Llamadas.Count; i++)
                    {
                        if (aux1.GetType() == Llamadas[i].GetType())
                        {
                            aux1 = (Local)Llamadas[i];
                            recaudacion = recaudacion + aux1.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Provincial:
                    for (i = 0; i < Llamadas.Count; i++)
                    {
                        if (aux2.GetType() == Llamadas[i].GetType())
                        {
                            aux2 = (Provincial)Llamadas[i];
                            recaudacion = recaudacion + aux2.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Todas:
                    for (i = 0; i < Llamadas.Count; i++)
                    {
                        if (aux1.GetType() == Llamadas[i].GetType())
                        {
                            aux1 = (Local)Llamadas[i];
                            recaudacion = recaudacion + aux1.CostoLlamada;
                        }
                    }
                    for (i = 0; i < Llamadas.Count; i++)
                    {
                        if (aux2.GetType() == Llamadas[i].GetType())
                        {
                            aux2 = (Provincial)Llamadas[i];
                            recaudacion = recaudacion + aux2.CostoLlamada;
                        }
                    }
                    break;
            }
            return recaudacion;
        }
        public void OrdenarLlamadas()
        {
            Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Razon Social: " + this._razonSocial);
            sb.AppendLine("Ganancia por Llamadas Locales: " + this.GananciaPorLocal);
            sb.AppendLine("Ganancia por Llamadas Provinciales: " + this.GananciaPorProvincial);
            sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
            sb.AppendLine("");
            this.OrdenarLlamadas();
            sb.AppendLine("Detalles de las llamadas: ");
            foreach (Llamada item in Llamadas)
            {
                if (item is Local)
                {
                    sb.AppendLine("Llamada local: ");
                    sb.AppendLine(((Local)item).ToString());
                }
                if (item is Provincial)
                {
                    sb.AppendLine("Llamada Provincial: ");
                    sb.AppendLine(((Provincial)item).ToString());
                }
            }
            return sb.ToString();
        }
        private void AgregarLlamada(Llamada UnaLlamada) 
        {
            this._listaDeLlamadas.Add(UnaLlamada);
        }
        public static bool operator ==(Centralita Central, Llamada nuevaLlamada)
        {
            bool estado = false;
            foreach (Llamada item in Central._listaDeLlamadas)
            {
                if (item == nuevaLlamada) 
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
        public static bool operator !=(Centralita Central, Llamada nuevaLlamada) 
        {
            if (Central == nuevaLlamada)
                return false;
                return true;
        }
        public static Centralita operator +(Centralita Central, Llamada nuevaLlamada)
        {
            if (Central == nuevaLlamada) 
            {
                Console.WriteLine("Ya se encuentra en la lista");
            }
            else
            {
                Central.AgregarLlamada(nuevaLlamada);
            }
            return Central;
        }
    }
}
