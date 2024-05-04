namespace Fundamentos.Models
{
    class Vino(int Cantidad, string Nombre = "Vino") : Bebida(Nombre, Cantidad), IBebidaAlcoholica
    {
        public int Alcohol { get; set; }

        public void MaxRecomendado()
        {
            Console.WriteLine("El máximo permitido son 3 copas");
        }
    }
}
