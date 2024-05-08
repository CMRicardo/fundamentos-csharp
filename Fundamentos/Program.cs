namespace Fundamentos
{
  public class Beer
  {
    public string Name { get; set; } = "";
    public int Alcohol { get; set; }
  }
  static class Program
  {
    static void Main(string[] args)
    {
      List<Beer> beers = [
        new Beer { Name = "Ipa", Alcohol = 7},
        new Beer { Name = "Pale Ale", Alcohol = 8 },
        new Beer { Name = "Stout", Alcohol = 9 },
        new Beer { Name = "Tripel", Alcohol = 15 }
      ];
      beers.ShowBeerThatIGetDrunk(beer => beer.Alcohol >= 8 && beer.Alcohol < 15);
    }
    static void ShowBeerThatIGetDrunk(this List<Beer> beers, Predicate<Beer> condition)
    {
      var evilBeers = beers.FindAll(condition);
      evilBeers.ForEach(beer => Console.WriteLine($"{beer.Name} - {beer.Alcohol}"));
    }
  }
}