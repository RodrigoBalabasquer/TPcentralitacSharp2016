using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main()
        {
            Centralita MiCentral = new Centralita("Telefonica");
            Local Llamada1 = new Local("42409124", 30, "20705020", 2.65f);
            Provincial Llamada2 = new Provincial("42407151", Franja.Franja_1, 21, "42471562");
            Local Llamada3 = new Local("41354235", 45, "87625412", 1.99f);
            Provincial Llamada4 = new Provincial(Franja.Franja_3, Llamada2);
            //MiCentral = MiCentral + Llamada1;
            MiCentral = MiCentral + Llamada1;
            MiCentral = MiCentral + Llamada2;
            MiCentral = MiCentral + Llamada3;
            MiCentral = MiCentral + Llamada4;
            Console.WriteLine(MiCentral.ToString());
            Console.ReadKey();
        }
    }
}
