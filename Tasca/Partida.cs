namespace Tasca;

public class Partida
{
    private Tauler Tauler;
    private List<Animals> LlistaDeAnimals = new List<Animals>();
    private static Random Random = new Random();
    private int PrimerNumero;
    private int SegonNumero;
    private int PosicioOnEsMoure;
    private int Ronda;
    
    public Partida()
    {
        Tauler = new Tauler();
        for (int i = 0; i < 20; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 10)
            {
                LlistaDeAnimals.Add(new PeixosNormals(false, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
            else
            {
                LlistaDeAnimals.Add(new PeixosNormals(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
        }

        for (int i = 0; i < 2; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 1)
            {
                LlistaDeAnimals.Add(new Tauro(false, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
            else
            {
                LlistaDeAnimals.Add(new Tauro(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
        }

        for (int i = 0; i < 2; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            LlistaDeAnimals.Add(new Pops(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
        }

        for (int i = 0; i < 3; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 1)
            {
                LlistaDeAnimals.Add(new Tortugues(false, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
            else
            {
                LlistaDeAnimals.Add(new Tortugues(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
        }
    }

    public void Inicialitza()
    {
        while (true)
        {
            if (Ronda == 100)
            {
                break;
            }
            else
            {
                foreach (var animals in LlistaDeAnimals)
                {
                    if (animals.ElAnimalEstaViu())
                    {
                        animals.Mou();
                    }
                }
                Tauler.ActualitzarTauler(LlistaDeAnimals);
                var Colisions = Tauler.ComprovarColisions();

                foreach (var Colisio in Colisions)
                {
                    for (int i = Colisio.Count - 1; i > 0; i--)
                    {
                        
                    }
                }

                Ronda++;
            }
        }
    }
}