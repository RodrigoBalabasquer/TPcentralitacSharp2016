using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        public Centralita() 
        {
            this._listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string NombreDeEmpresa) : this() 
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
            Local aux1 = new Local("0",0," ",0);
            Provincial aux2 = new Provincial("", Franja.Franja_1, 0, " ");
            switch (tipo) 
            {
                case TipoLlamada.Local:
                    /*foreach (Local item in Llamadas)
                    {   
                       recaudacion =  recaudacion + item.CostoLlamada;
                    }*/
                    for ( i = 0; i < Llamadas.Count; i++)
                    {
                        if (aux1.GetType() == Llamadas[i].GetType()) 
                        {
                            aux1 = (Local)Llamadas[i];
                            recaudacion = recaudacion + aux1.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Provincial:
                    /*foreach (Provincial item in Llamadas)
                    {
                        recaudacion =  recaudacion + item.CostoLlamada;
                    }*/
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
                    /*foreach (Local item in Llamadas)
                    {
                        recaudacion =  recaudacion + item.CostoLlamada;
                    }
                    foreach (Provincial item in Llamadas)
                    {
                        recaudacion =  recaudacion + item.CostoLlamada;
                    }*/
                    for ( i = 0; i < Llamadas.Count; i++)
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
        public void Mostrar() 
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Razon Social: " + this._razonSocial);
            sb.AppendLine("Ganancia por Llamadas Locales: " + this.GananciaPorLocal);
            sb.AppendLine("Ganancia por Llamadas Provinciales: " + this.GananciaPorProvincial);
            sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
            Console.WriteLine(sb.ToString());
            this.OrdenarLlamadas();
            Console.WriteLine("Detalles de las llamadas: ");
            foreach (Llamada item in Llamadas)
            {
                if(item is Local)
                {
                    Console.WriteLine("Llamada local: ");
                    ((Local)item).Mostrar();
                }
                if(item is Provincial)
                {
                    Console.WriteLine("Llamada Provincial: ");
                    ((Provincial)item).Mostrar();
                }
            }
         }
    }
}
