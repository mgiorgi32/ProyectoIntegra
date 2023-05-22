using proyectointegra;
using System;

namespace BancoSA{
    class program
    {
       
        public static void Main()
        {
            Console.WriteLine("Bienvenido a la pagina de prestamos, vamos a precisar unos datos para avanzar: ");
            Console.ReadLine();
            persona persona = new persona(11111111, "lucas", "fernandez", 1111111111, 222222222);
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
            Console.WriteLine("Muchas gracias, sigamos con el proceso");
            Console.ReadLine();
            Console.Clear();
            prestamo prestamo = new prestamo();
            prestamo.NumeroPrestamo = 1;
            prestamo.ValorPrestamo = 15000;
            prestamo.FechaPagos = DateTime.AddMonths(1), DateTime.AddMonths(2), DateTime.AddMonths(3), DateTime.AddMonths(4), DateTime.AddMonths(5), DateTime.AddMonths(6);
            prestamo.FechaAutorizacion = DateTime.Now;
            prestamo.FechaTentativa = DateTime.AddDays(25);
            Console.WriteLine("¿De cuanto seria su prestamo?" );
            Console.ReadLine();
            Console.WriteLine(prestamo.ValorPrestamo + " ");
            Console.ReadLine();
            Console.WriteLine("Sus fechas de pago serian las siguientes: " + prestamo.FechaPagos + " ");
            Console.ReadLine();
            Console.WriteLine("La fecha de autorizacion de uso seria: " + prestamo.FechaAutorizacion + " ");
            Console.ReadLine();
            Console.WriteLine("La fecha tentativa de ingreso seria: " + prestamo.FechaTentativa + " ");
            Console.ReadLine();
            Console.WriteLine("La fecha maxima de autorización para este prestamo seria: " + prestamo.FechaMax + " ");
            prestamo.MontoMax(250000);
            Console.WriteLine("Lo maximo que puedes pedir es: " + prestamo.MontoMax + " ");
            Console.ReadLine();
            
            
        }
    }
}
