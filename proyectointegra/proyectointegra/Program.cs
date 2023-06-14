using proyectointegra;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSA{
    class program
    {
        

        public static void Main()
        {
            bool otro = true;
            while (otro)
            {
                Console.WriteLine("Bienvenido a la pagina de prestamos, vamos a precisar unos datos para avanzar: ");
            Console.ReadLine();
                var personas = new List<Persona>()
                {
                     new Persona(12345678, "Fernando", "Alonso", 1122222222, 023766666, 100000),
                    new Persona(87654321, "Lance", "Stroll", 1111111111, 0237111111, 45000),
                    new Persona(21436587, "Clint", "Barton", 1133333333, 0237222222, 100000),
                    new Persona(13245768, "Tony", "Stark", 1144444444, 0237333333,10000),
                    new Persona(86754231, "Luke", "Skywalker", 1155555555, 0237444444, 200000),
                    new Persona(18273645, "El pollo", "Vignolo", 1166666666, 0237555555, 500000),
                    new Persona(54637281, "Lionel", "Messi", 1177777777, 0237777777, 1000000),
                    new Persona(45362718, "Seth", "Rollins", 1188888888, 0237888888, 15000),
                    new Persona(76543210,"Taylor", "Swift", 1199999999,0237999999, 1000000),
                    new Persona(65432198, "Kick", "Butowski", 1100000000, 0237000000, 5000),
                };
           Console.WriteLine("Ingrese su DNI:");
                int dni = int.Parse(Console.ReadLine());
                Persona persona = personas.Where(x => x.Dni == dni).First();
                if (persona != null)
                {
                    Console.WriteLine(persona.Dni);
                    Console.WriteLine(persona.Nombre);
                    Console.WriteLine(persona.Apellido);
                    Console.WriteLine(persona.TelefonoMovil);
                    Console.WriteLine(persona.TelefonoCasa);
                    Console.WriteLine("Bienvenido denuevo {0}.", persona.Nombre);
                    Console.WriteLine("Muchas gracias, sigamos con el proceso");
                }
                else
                {
                    Console.WriteLine("Este usuario no esta registrado en el sistema, intentelo mas tarde");
                    otro = false;
                }
                Console.ReadLine();
                Console.Clear();

            Prestamo prestamo = new Prestamo { numeroPrestamo = 1, FechaAutorizacion = DateTime.Now };
                Console.WriteLine("Lo maximo que puedes pedir es: " + persona.MontoMaximo + " ");
            Console.WriteLine("¿De cuanto seria su prestamo?" );
            Console.ReadLine();
                prestamo.ValorPrestamo = decimal.Parse(Console.ReadLine());
            Console.WriteLine(prestamo.ValorPrestamo);
            Console.WriteLine("Este prestamo puede ser pagado en 3, 6, 12 0 18 cuotas, el plan de 12 y 18 cuotas tiene un interes y tambien puede ser pagado en un pago aunque no es recomendable,  en cuantas cuotas quiere sacar este prestamo: " );
            int cuota = Convert.ToInt32(Console.ReadLine());
                var cuotaMaxima = 18;

                if (cuota % 3 != 0 || cuota > cuotaMaxima || cuota < 3)
                {
                Console.WriteLine("Estas cuotas no estan disponibles intentelo denuevo mas tarde.");
                }
                else
                {
                    int valor = (int)(prestamo.ValorPrestamo /= cuota);
                    Console.WriteLine($"las cuotas serian {cuota} con un valor cada una de {valor}");
                    prestamo.FechaPagos = new List<DateTime>();
                    for( var i = 1; i<= cuota; i++ )
                    {
                        prestamo.FechaPagos.Add( prestamo.FechaTentativa.AddMonths(i) );
                    }
                    var mensajeFechas = "sus fechas de pago son: ";
                    var separador = " ";
                    for(var i=0; i<=prestamo.FechaPagos.Count; i++ )
                    {
                        mensajeFechas += $"{separador} {prestamo.FechaPagos[i]}";
                        separador = ",";
                    }
                    Console.WriteLine(mensajeFechas );
                    Console.WriteLine("La fecha de autorizacion de uso seria: " + prestamo.FechaAutorizacion.ToString("dd/MM/yyyy") + " ");
                    Console.WriteLine("La fecha tentativa de ingreso seria: " + prestamo.FechaTentativa.ToString("dd/MM/yyyy") + " ");
                    Console.WriteLine("La fecha maxima de autorización para este prestamo seria: " + prestamo.FechaMax().ToString("dd/MM/yyyy") + " ");
                    Console.ReadLine();
                }
                Console.WriteLine("¿Desea pedir otro prestamo?");
                string RTA = Console.ReadLine();
                if( RTA == "si")
                {
                    continue;
                }else if ( RTA == "no")
                {
                    otro = false;
                }
            }
            
            
        }
    }
}
