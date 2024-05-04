using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentos.Models
{
    public class Bebida(string Nombre, int Cantidad)
    {
        public string Nombre { get; set; } = Nombre;
        public int Cantidad { get; set; } = Cantidad;

        public void Beberse(int CuantoBebio)
        {
            this.Cantidad -= CuantoBebio;
        }
    }
}
