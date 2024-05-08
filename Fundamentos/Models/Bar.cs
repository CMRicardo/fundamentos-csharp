namespace Fundamentos.Models
{
  public class Bar
  {
    public string Nombre { get; set; } = "";
    public List<Cerveza> Cervezas = [];

    public Bar(string nombre)
    {
      Nombre = nombre;
    }
  }

}

