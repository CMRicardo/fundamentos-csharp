namespace Fundamentos.Models
{
    public class Cerveza(int Cantidad = 10, string Nombre = "Cerveza") : Bebida(Nombre, Cantidad), IBebidaAlcoholica
    {
        public int Id { get; set; }
        public int Alcohol { get; set; }
        public string Marca { get; set; } = "";
        public void MaxRecomendado()
        {
            Console.WriteLine("El máximo permitido son 10 botellas");
        }
    }
}
