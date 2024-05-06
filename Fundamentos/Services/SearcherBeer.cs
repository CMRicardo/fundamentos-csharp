using Fundamentos.Exceptions;
using Fundamentos.Models;

namespace Fundamentos.Services
{
  public class SearcherBeer
  {
    List<Cerveza> cervezas = [
      new() {Alcohol = 7, Cantidad=10, Nombre="Pale Ale", Marca="Minerva"},
      new() {Alcohol = 8, Cantidad=5, Nombre="Ticús", Marca="Colima"},
      new() {Alcohol = 7, Cantidad=8, Nombre="Stout", Marca="Minerva"}
    ];

    public int GetCantidad(string Nombre)
    {
      var cerveza = (
        from cer in cervezas
        where cer.Nombre == Nombre
        select cer
      ).FirstOrDefault();
      if (cerveza == null)
        throw new BeerNotFoundException("La cerveza se ha terminado");
      return cerveza.Cantidad;
    }
  }
}
