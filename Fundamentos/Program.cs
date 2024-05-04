using Fundamentos.Models;

List<Bar> bares = [
  new Bar("El Bar") { Cervezas = [
      new() {Alcohol= 7, Nombre="Pale Ale", Cantidad= 10, Marca="Minerva"},
      new() {Alcohol= 8, Nombre="Ticús", Cantidad= 5, Marca="Colima"},
      new() {Alcohol= 7, Nombre="Stout", Cantidad= 8, Marca="Minerva"},
    ]
  },
  new Bar("El Bar 2") { Cervezas = [
    new() {Alcohol= 7, Nombre="Stout", Cantidad= 8, Marca="Minerva"},
    new() {Alcohol= 6, Nombre="Piedra Lisa", Cantidad= 100, Marca="Colima"},
  ]},
  new Bar("Bar nuevo")
];

var conStout = (
  from bar in bares
  where bar.Cervezas.Where(cerveza => cerveza.Nombre == "Stout").Any()
  select new BarData()
  {
    Nombre = bar.Nombre,
    Bebidas = (
      from cerveza in bar.Cervezas
      select new Bebida(cerveza.Nombre, cerveza.Cantidad)
    ).ToList()
  }
).ToList();

List<Cerveza> cervezas = [
  new Cerveza(1) {Alcohol= 7, Nombre="Pale Ale", Cantidad= 10, Marca="Minerva"},
  new Cerveza(1) {Alcohol= 8, Nombre="Ticús", Cantidad= 5, Marca="Colima"},
  new Cerveza(1) {Alcohol= 7, Nombre="Stout", Cantidad= 8, Marca="Minerva"},
  new Cerveza(1) {Alcohol= 6, Nombre="Piedra Lisa", Cantidad= 100, Marca="Colima"},
];

