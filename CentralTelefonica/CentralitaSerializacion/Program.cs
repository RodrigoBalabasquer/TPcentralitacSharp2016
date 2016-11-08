using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita MiCentral = new Centralita("Telefonica");
            MiCentral.RutaDeArchivo = "Centralita.txt";
            Local Llamada1 = new Local("42409124", 30, "20705020", 2.65f);
            Provincial Llamada2 = new Provincial("42407151", Franja.Franja_1, 21, "42471562");
            Local Llamada3 = new Local("41354235", 45, "87625412", 1.99f);
            Provincial Llamada4 = new Provincial(Franja.Franja_3, Llamada2);
            //MiCentral = MiCentral + Llamada1;
            try
            {
                MiCentral = MiCentral + Llamada1;
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            try
            {
                MiCentral = MiCentral + Llamada2;
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            try
            {
                MiCentral = MiCentral + Llamada3;
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            try
            {
                MiCentral = MiCentral + Llamada4;
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            //Console.WriteLine(MiCentral.ToString());
            Console.ReadKey();

            MiCentral.RutaDeArchivo = "Centralita.XML";
            try
            {
                MiCentral.Serializarse();
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            Centralita OtraCentral = new Centralita();
            OtraCentral.RutaDeArchivo = "Centralita.XML";
            try
            {
                OtraCentral.Deserializarse();
            }
            catch (CentralitaException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.NombreClase);
                Console.WriteLine(e.NombreMetodo);
            }
            Console.WriteLine(OtraCentral.ToString());
            Console.ReadKey();
        }
    }
}
