namespace Lekcja33.Klasy;

public class Gra
{
    private Siatka _siatka;

    public Gra(int liczbaRzedow, int liczbaKolumn)
    {
        _siatka = new Siatka(liczbaRzedow, liczbaKolumn);
    }

    public Gra(Siatka siatka)
    {
        _siatka = siatka;
    }

    public void Uruchom(int liczbaIteracji)
    {
        for (int i = 0; i < liczbaIteracji; i++)
        {
            Console.Clear();
            Console.WriteLine($"Iteracja {i}:");
            _siatka.ZrobKrok();

            _siatka.Wydrukuj();
            Thread.Sleep(100);
            Console.ReadKey();
        }
    }
}
