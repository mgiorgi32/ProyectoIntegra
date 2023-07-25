using proyectointegra;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace BancoSA
{
    class Program
    {

        private const string Format = "dd/MM/yyyy";
        public static void Main()
        {
            bool otro = true;
            var cantidadPrestamos = 0; 
            while (otro)
            {
                cantidadPrestamos++;
                Console.WriteLine("Bienvenido a la pagina de prestamos, vamos a precisar unos datos para avanzar: ");
                var personas = new List<Persona>()
                {
                    new Persona(12345678, "Fernando", "Alonso", 1122222222, 023766666, 100000, 545000),
                    new Persona(87654321, "Lance", "Stroll", 1111111111, 0237111111, 45000, 350000),
                    new Persona(21436587, "Clint", "Barton", 1133333333, 0237222222, 100000, 34500),
                    new Persona(13245768, "Tony", "Stark", 1144444444, 0237333333,10000, 1000000),
                    new Persona(86754231, "Luke", "Skywalker", 1155555555, 0237444444, 200000, 150000),
                    new Persona(18273645, "El pollo", "Vignolo", 1166666666, 0237555555, 500000, 120000),
                    new Persona(54637281, "Lionel", "Messi", 1177777777, 0237777777, 1000000, 2000000),
                    new Persona(45362718, "Seth", "Rollins", 1188888888, 0237888888, 15000, 75000),
                    new Persona(76543210,"Taylor", "Swift", 1199999999,0237999999, 1000000, 3500000),
                    new Persona(65432198, "Kick", "Butowski", 1100000000, 0237000000, 50000, 15000),
                };
                Console.WriteLine("Ingrese su DNI:");
                int dni = int.Parse(Console.ReadLine());
                Persona persona = personas.FirstOrDefault(x => x.Dni == dni);
                if (persona != null)
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido a Banco S.A., sus datos son:");
                    Console.WriteLine("Dni: " + persona.Dni);
                    Console.WriteLine("Nombre: " + persona.Nombre);
                    Console.WriteLine("Apellido: " + persona.Apellido);
                    Console.WriteLine("Telefono movil: " + persona.TelefonoMovil);
                    Console.WriteLine("Telefono fijo: " + persona.TelefonoCasa);
                    Console.WriteLine("Usted pidio una cantidad de " + cantidadPrestamos + " prestamos");
                    Console.WriteLine("Muchas gracias, sigamos con el proceso");

                }
                else
                {
                    Console.WriteLine("Este usuario no esta registrado en el sistema, intentelo mas tarde");
                    cantidadPrestamos = 0;
                    break;
                }
                Console.ReadLine();
                Console.Clear();

                Prestamo prestamo = new Prestamo { numeroPrestamo = cantidadPrestamos, FechaAutorizacion = DateTime.Now };
                Console.WriteLine("Tu patrimonio actual es de: " + persona.PatrimonioActual + " ");
                Console.WriteLine("Tu limite de prestamo es de: " + persona.MontoMaximo + " ");
                Console.WriteLine("¿De cuanto seria su prestamo?");
                decimal v = decimal.Parse(Console.ReadLine());
                Console.Clear() ;
                if (v > 0)
                {
                    prestamo.ValorPrestamo = v;
                    Console.WriteLine("Tu prestamo seria de: " + prestamo.ValorPrestamo + " ");
                    Console.WriteLine("Ahora gracias al prestamo tu patrimonio seria de: " + (persona.PatrimonioActual + prestamo.ValorPrestamo) + " ");
                    Console.WriteLine("Este prestamo puede ser pagado en 3, 6, 12 0 18 cuotas, en cuantas cuotas quiere sacar este prestamo: ");
                    int cuota = Convert.ToInt32(Console.ReadLine());
                    var cuotaMaxima = 18;

                    if (cuota % 3 != 0 || cuota > cuotaMaxima || cuota < 3)
                    {
                        Console.WriteLine("Estas cuotas no estan disponibles intentelo denuevo mas tarde.");
                        Console.ReadLine();
                    }
                    else
                    {
                        
                        Console.WriteLine($"las cuotas serian {cuota}");
                        if(cuota == 12 || cuota == 18)
                        {
                            decimal valorConInteres = intereses(prestamo.ValorPrestamo);
                            int valor = (int)(valorConInteres);
                            decimal interes = (valorConInteres - prestamo.ValorPrestamo)/cuota;
                            Console.WriteLine($"Sus cuotas tendrán un interés del 5%.");
                            Console.WriteLine($"El interés en cada cuota será de: {interes}");
                            Console.WriteLine($"El precio final seria de: {valor}");
                            Console.ReadLine();
                        }
                        else if (cuota == 3 || cuota == 6)
                        {
                            int valor = (int)(prestamo.ValorPrestamo /= cuota);
                            Console.WriteLine($"Cada cuota tendra un valor de: {valor}");
                            Console.WriteLine("estas cuotas no tienen interes");
                            Console.ReadLine();
                        }
                        prestamo.FechaPagos = new List<DateTime>();
                        DateTime fechaHoy = DateTime.Now;
                        for (var i = 1; i <= cuota; i++)
                        {
                            prestamo.FechaPagos.Add(fechaHoy.AddMonths(i));
                        }
                        var mensajeFechas = "sus fechas de pago son: \n";
                        //var separador = " ";
                        for (var i = 0; i < prestamo.FechaPagos.Count; i++)
                        {
                            mensajeFechas += $"{prestamo.FechaPagos[i].ToString(Format)}\n";
                            //separador = ",";
                        }

                        Console.WriteLine(mensajeFechas);
                        Console.WriteLine("La fecha de autorizacion de uso seria: " + prestamo.FechaAutorizacion.ToString(Format) + " ");
                        Console.WriteLine("La fecha tentativa de ingreso seria: " + fechaHoy.AddDays(4).ToString(Format) + " ");
                        Console.WriteLine("La fecha maxima de autorización para este prestamo seria: " + prestamo.FechaMax().ToString(Format) + " ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("La cifra del prestamo debe ser un numero mayor a 0, vuelva a intentarlo mas tarde");
                    Console.ReadLine();
                }                
                    Console.WriteLine("¿Desea pedir otro prestamo?");
                    string RTA = Console.ReadLine();
                    if (RTA == "si")
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (RTA == "no")
                    {
                    Console.WriteLine("Muchisimas gracias por confiar en nosotros, hasta luego");
                    Console.ReadLine();
                        otro = false;
                    }
                    else
                    {
                        Console.WriteLine("Como no te entendimos tomaremos tu respuesta como negativa");
                        Console.ReadLine();
                        otro = false;
                    }
            }
        }
        public static decimal intereses(decimal precioN)
        {
            decimal interes = precioN * 0.05m;
            decimal precioFinal = precioN + interes;
            return precioFinal;
        }
    }
}

