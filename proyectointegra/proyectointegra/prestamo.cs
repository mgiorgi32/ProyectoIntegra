using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectointegra
{
    internal class prestamo
    {
        public int NumeroPrestamo { get; set; }
        public decimal ValorPrestamo { get; set; }
        public List<DateTime> FechaPagos { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public DateTime FechaTentativa { get; set; }

        public int numeroPrestamo
        {
            set { NumeroPrestamo = value; }
            get { return NumeroPrestamo; }
        }

        public decimal valorPrestamo
        {
            set
            {
                if (value <= 0)
                {
                    valorPrestamo = 0;
                }
                else
                {
                    valorPrestamo = value;
                }
            }
            get { return ValorPrestamo; }
        }
        public DateTime fechaPagos
        {
            set { fechaPagos = value; }
            get { return fechaPagos; }
        }
        public DateTime fechaAutorizacion
        {
            set { FechaAutorizacion = value; }
            get { return fechaAutorizacion; }
        }
        public DateTime fechaTentativa
        {
            set { FechaTentativa = value; }
            get { return FechaTentativa;}
        }

        //public DateTime FechaMax(DateTime date)
        //{
            //return FechaAutorizacion.Add(date.Now); preguntar
        //}

        public decimal MontoMax(int ValorMaximo)
        {
            valorPrestamo += ValorMaximo;
            return valorPrestamo;
        }
    }
}
