using System;

namespace Lekcja33.Klasy;

public class Siatka
{
    private int[,] _tablicaKomorek;

    private const int ZYWA = 1;
    private const int MARTWA = 0;

    public Siatka(int liczbaRzedow, int liczbaKolumn)
    {
        _tablicaKomorek = new int[liczbaRzedow, liczbaKolumn];

        Random random = new Random();

        for (int i = 0; i < liczbaRzedow; i++)
        {
            for (int j = 0; j < liczbaKolumn; j++)
            {
                //int wylosowanaLiczba = random.Next(2); // 0 lub 1

                //_tablicaKomorek[i, j] = wylosowanaLiczba == 1 ? ZYWA : MARTWA;

                if (i == liczbaRzedow / 2 && j == liczbaKolumn / 2)
                {
                    _tablicaKomorek[i, j] = ZYWA;
                    _tablicaKomorek[i - 1, j] = ZYWA;
                    _tablicaKomorek[i + 1, j] = ZYWA;
                }
            }
        }
    }

    public Siatka(int liczbaRzedow, int liczbaKolumn, int ziarno)
    {
        _tablicaKomorek = new int[liczbaRzedow, liczbaKolumn];

        Random random = new Random(ziarno);

        for (int i = 0; i < liczbaRzedow; i++)
        {
            for (int j = 0; j < liczbaKolumn; j++)
            {
                int wylosowanaLiczba = random.Next(2); // 0 lub 1

                _tablicaKomorek[i, j] = wylosowanaLiczba == 1 ? ZYWA : MARTWA;
            }
        }
    }

    public Siatka(int[,] tablicaPoczatkowa, int liczbaRzedow, int liczbaKolumn)
    {
        _tablicaKomorek = new int[liczbaRzedow, liczbaKolumn];

        for (int i = 0; i < tablicaPoczatkowa.GetLength(0); i++)
        {
            for (int j = 0; j < tablicaPoczatkowa.GetLength(1); j++)
            {
                _tablicaKomorek[i, j] = tablicaPoczatkowa[i, j];
            }
        }
    }

    public void ZrobKrok()
    {
        int[,] noweKomorki = new int[_tablicaKomorek.GetLength(0), _tablicaKomorek.GetLength(1)];

        for (int i = 0; i < _tablicaKomorek.GetLength(0); i++)
        {
            for (int j = 0; j < _tablicaKomorek.GetLength(1); j++)
            {
                noweKomorki[i, j] = ZastosujZasady(i, j);
            }
        }

        _tablicaKomorek = noweKomorki;
    }

    private int PoliczZywychSasiadow(int nrRzedu, int nrKolumny)
    {
        int licznik = 0;

        for (int i = nrRzedu - 1; i <= nrRzedu + 1; i++)
        {
            for (int j = nrKolumny - 1; j <= nrKolumny + 1; j++)
            {
                if (i >= 0 && i < _tablicaKomorek.GetLength(0)
                   && j >= 0 && j < _tablicaKomorek.GetLength(1)
                   && !(i == nrRzedu && j == nrKolumny))
                {
                    if (_tablicaKomorek[i, j] == ZYWA)
                    {
                        licznik++;
                    }
                }
            }
        }

        return licznik;
    }

    private int ZastosujZasady(int nrRzedu, int nrKolumny)
    {
        int liczbaSasiadow = PoliczZywychSasiadow(nrRzedu, nrKolumny);

        if (_tablicaKomorek[nrRzedu, nrKolumny] == ZYWA)
        {
            if (liczbaSasiadow == 2 || liczbaSasiadow == 3)
                return ZYWA;
        }
        else // Martwa
        {
            if (liczbaSasiadow == 3)
                return ZYWA;
        }

        return MARTWA;
    }

    public void Wydrukuj()
    {
        Console.Write(" ╔");
        for (int i = 0; i < _tablicaKomorek.GetLength(0); i++)
        {
            Console.Write("══");
        }
        Console.Write("═╗");
        Console.WriteLine();
        for (int i = 0; i < _tablicaKomorek.GetLength(0); i++)
        {
            Console.Write(" ║");
            for (int j = 0; j < _tablicaKomorek.GetLength(1); j++)
            {
                //Console.Write("―");
                if (_tablicaKomorek[i, j] == ZYWA)
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write(" ");
            }
            Console.Write(" ║");
            Console.WriteLine();
        }
        Console.Write(" ╚");
        for (int i = 0; i < _tablicaKomorek.GetLength(0); i++)
        {
            Console.Write("══");
        }
        Console.Write("═╝");
        Console.WriteLine();
    }
}

