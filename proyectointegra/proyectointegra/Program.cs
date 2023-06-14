using proyectointegra;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSA{
    class program
    {
        

        public static void Main()
        {
            Console.WriteLine("Bienvenido a la pagina de prestamos, vamos a precisar unos datos para avanzar: ");
            Console.ReadLine();
            persona persona = new persona(11111111, lucas, hernandez, 222222222, 232343);
            Console.WriteLine (persona.Dni);
            Console.ReadLine();
            Console.WriteLine(persona.Nombre);
            Console.ReadLine();
            Console.WriteLine(persona.Apellido);
            Console.ReadLine();
            Console.WriteLine(persona.TelefonoMovil);
            Console.ReadLine();
            Console.WriteLine(persona.TelefonoCasa);
            Console.ReadLine();
            Console.WriteLine("Bienvenido denuevo {0}.", persona.Nombre);
            Console.ReadLine();
            Console.WriteLine("Muchas gracias, sigamos con el proceso");
            Console.ReadLine();
            Console.Clear();

            prestamo prestamo = new prestamo { numeroPrestamo = 1, FechaAutorizacion = DateTime.Now };
            Console.WriteLine("¿De cuanto seria su prestamo?" );
            Console.ReadLine();
            prestamo.ValorPrestamo.ToString(Console.ReadLine()); //preguntar 
            Console.WriteLine(prestamo.ValorPrestamo);
            Console.WriteLine("Este prestamo puede ser pagado en 3, 6, 12 0 18 cuotas, el plan de 12 y 18 cuotas tiene un interes y tambien puede ser pagado en un pago aunque no es recomendable, en cuantas cuotas quiere sacar este prestamo: " );
            int cuota = Convert.ToInt32(Console.ReadLine());
            if(cuota==3)
            {
               int valor = (int)(prestamo.ValorPrestamo /= 3);
                Console.WriteLine($"Las cuotas serian 3 de: {valor}");
                prestamo.FechaPagos = new List<DateTime> { prestamo.FechaTentativa.AddMonths(1), prestamo.FechaTentativa.AddMonths(2), prestamo.FechaTentativa.AddMonths(3) };
                Console.WriteLine("Sus fechas de pago serian: " + prestamo.FechaPagos.Count);
            }else if (cuota == 6)
            {
                int valor = (int)(prestamo.ValorPrestamo /= 6);
                Console.WriteLine($"Las cuotas serian 6 de: {valor}");
                prestamo.FechaPagos = new List<DateTime> { prestamo.FechaTentativa.AddMonths(1), prestamo.FechaTentativa.AddMonths(2), prestamo.FechaTentativa.AddMonths(3), prestamo.FechaTentativa.AddMonths(4), prestamo.FechaTentativa.AddMonths(5), prestamo.FechaTentativa.AddMonths(6) };
                Console.WriteLine("Sus fechas de pago serian: " + prestamo.FechaPagos.Count);
            }else if (cuota == 12)
            {
                int valor = (int)((prestamo.ValorPrestamo*2)/12);
                Console.WriteLine($"Las cuotas serian 12 de: {valor}");
                prestamo.FechaPagos = new List<DateTime> { prestamo.FechaTentativa.AddMonths(1), prestamo.FechaTentativa.AddMonths(2), prestamo.FechaTentativa.AddMonths(3), prestamo.FechaTentativa.AddMonths(4), prestamo.FechaTentativa.AddMonths(5), prestamo.FechaTentativa.AddMonths(6), prestamo.FechaTentativa.AddMonths(7), prestamo.FechaTentativa.AddMonths(8), prestamo.FechaTentativa.AddMonths(9), prestamo.FechaTentativa.AddMonths(10), prestamo.FechaTentativa.AddMonths(11), prestamo.FechaTentativa.AddMonths(12) };
                Console.WriteLine("Sus fechas de pago serian: " + prestamo.FechaPagos.Count);
            }else if (cuota == 18)
            {
                int valor = (int)((prestamo.ValorPrestamo * 3) / 18);
                Console.WriteLine($"Las cuotas serian 18 de: {valor}");
                prestamo.FechaPagos = new List<DateTime> { prestamo.FechaTentativa.AddMonths(1), prestamo.FechaTentativa.AddMonths(2), prestamo.FechaTentativa.AddMonths(3), prestamo.FechaTentativa.AddMonths(4), prestamo.FechaTentativa.AddMonths(5), prestamo.FechaTentativa.AddMonths(6), prestamo.FechaTentativa.AddMonths(7), prestamo.FechaTentativa.AddMonths(8), prestamo.FechaTentativa.AddMonths(9), prestamo.FechaTentativa.AddMonths(10), prestamo.FechaTentativa.AddMonths(11), prestamo.FechaTentativa.AddMonths(12), prestamo.FechaTentativa.AddMonths(13), prestamo.FechaTentativa.AddMonths(14), prestamo.FechaTentativa.AddMonths(15), prestamo.FechaTentativa.AddMonths(16), prestamo.FechaTentativa.AddMonths(17), prestamo.FechaTentativa.AddMonths(18) };
                Console.WriteLine("Sus fechas de pago serian: " + prestamo.FechaPagos.Count);
            }else if(cuota == 1)
            {
                int valor = (int)(prestamo.ValorPrestamo);
                Console.WriteLine($"El pago se haria en 1 pago de: {valor}");
                Console.WriteLine("La fecha de pago seria el dia: {0}", prestamo.FechaTentativa.AddMonths(1));
            }
            else
            {
                Console.WriteLine("Estas cuotas no estan disponibles intentelo denuevo mas tarde.");
            }
            Console.ReadLine();
            Console.WriteLine("La fecha de autorizacion de uso seria: " + prestamo.FechaAutorizacion.ToString("dd/MM/yyyy") + " ");
            Console.ReadLine();
            Console.WriteLine("La fecha tentativa de ingreso seria: " + prestamo.FechaTentativa.ToString("dd/MM/yyyy") + " ");
            Console.ReadLine();
            Console.WriteLine("La fecha maxima de autorización para este prestamo seria: " + prestamo.FechaMax().ToString("dd/MM/yyyy") + " ");
            prestamo.MontoMax(250000);
            Console.WriteLine("Lo maximo que puedes pedir es: " + prestamo.MontoMax(3000 - (int)prestamo.ValorPrestamo) + " ");
            Console.ReadLine();
            bool otro = true;
            while (true)
            {
                Console.WriteLine("¿Desea pedir otro prestamo?");
                string RTA = Console.ReadLine();
                if( RTA == "si")
                {
                    otro = true;
                }else if ( RTA == "no")
                {
                    otro = false;
                }
            }
            
            
        }
    }
}
