using Lekcja33.Klasy;

public class Program
{
    public static void Main(string[] args)
    {
        int[,] szybowiec = new int[3, 3]
        {
            { 0, 1, 0},
            { 0, 0, 1},
            { 1, 1, 1}
        };

        int[,] kaczka = new int[5, 5]
        {
            { 0,0,0,0,0 },
            { 0,0,1,1,0 },
            { 1,1,0,1,1 },
            { 1,1,1,1,0 },
            { 0,1,1,0,0 }
        };

        //Gra gra = new Gra(20, 20);
        //gra.Uruchom(100);

        //Siatka siatkaSzybowiec = new Siatka(kaczka, 20, 20);

        //Gra gra = new Gra(siatkaSzybowiec);

        Gra gra = new Gra(new Siatka(20, 20, 10));

        gra.Uruchom(100);
    }
}