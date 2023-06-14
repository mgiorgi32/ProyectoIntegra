using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectointegra
{
    internal class Persona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TelefonoMovil { get; set; }
        public int TelefonoCasa { get; set; }
        public int MontoMaximo { get; set; }

        public  Persona(int dni, string nombre, string apellido, int telefonoMovil, int telefonoCasa)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            TelefonoMovil = telefonoMovil;
            TelefonoCasa = telefonoCasa;
            MontoMaximo = montoMaximo;
        }

    }
}
