namespace Tasca;

public class Tauler
{
    private List<Animals>[,] TaulerDuesDimensions = new List<Animals>[20,20];
    private List<(int, int)> Posicio = new List<(int, int)>();
    private int X;
    private int Y;

    public void ActualitzarTauler(List<Animals> LlistaAnimals)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                TaulerDuesDimensions[i, j] = new List<Animals>();
            }
        }
        foreach (var animal in LlistaAnimals)
        {
            if (animal.ElAnimalEstaViu())
            {
                Posicio = animal.RetornaPosicio();
                X = Posicio[0].Item1;
                Y = Posicio[0].Item2;
                TaulerDuesDimensions[X, Y].Add(animal);
            }
        }
    }

    public List<List<Animals>> ComprovarColisions()
    {
        List<List<Animals>> colisions = new List<List<Animals>>();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (TaulerDuesDimensions[i, j].Count > 1)
                {
                    colisions.Add(TaulerDuesDimensions[i, j]);
                }
            }
        }

        return colisions;
    }
}