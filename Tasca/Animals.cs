namespace Tasca;

public abstract class Animals
{
    protected bool EsUnHome;
    protected List<(int, int)> Posicio = new List<(int, int)>();
    private int X;
    private int Y;
    protected bool EstaViu;
    protected int Direccio;

    protected Animals(bool esunhome, List<(int, int)> posicio, bool estaviu, int direccio)
    {
        EsUnHome = esunhome;
        Posicio = posicio;
        EstaViu = estaviu;
        Direccio = direccio;
    }

    public virtual void Mou()
    {
        // Avall
        if (Direccio == 0)
        {
            CanviPosicio(Posicio);
        }
        // Esquerra
        else if (Direccio == 1)
        {
            CanviPosicio(Posicio);
        }
        // Adalt
        else if (Direccio == 2)
        {
            CanviPosicio(Posicio);
        }
        // Dreta
        else
        {
            CanviPosicio(Posicio);
        }
    }

    private List<(int, int)> CanviPosicio(List<(int, int)> PosicioAnimal)
    {
        foreach (var duplasint in PosicioAnimal)
        {
            X = duplasint.Item1;
            Y = duplasint.Item2;
        }
        PosicioAnimal.Clear();
        // Avall
        if (Direccio == 0)
        {
            if (Y == 0)
            {
                PosicioAnimal.Add((X, 19));
            }
            else
            {
                PosicioAnimal.Add((X, Y - 1));
            }
        }
        // Esquerra
        else if (Direccio == 1)
        {
            if (X == 0)
            {
                PosicioAnimal.Add((19, Y));
            }
            else
            {
                PosicioAnimal.Add((X - 1, Y));
            }
        }
        // Adalt
        else if (Direccio == 2)
        {
            if (Y == 19)
            {
                PosicioAnimal.Add((X, 0));
            }
            else
            {
                PosicioAnimal.Add((X, Y + 1));
            }
        }
        // Dreta
        else
        {
            if (X == 19)
            {
                PosicioAnimal.Add((0, Y));
            }
            else
            {
                PosicioAnimal.Add((X + 1, Y));
            }
        }
        return PosicioAnimal;
    }

    public void AssignarPosicio(int x, int y)
    {
        Posicio.Clear();
        Posicio.Add((x, y));
    }

    public void AssignarOnEsMoure(int onesmoure)
    {
        Direccio = onesmoure;
    }

    public bool ElAnimalEstaViu()
    {
        return EstaViu;
    }

    public List<(int, int)> RetornaPosicio()
    {
        return Posicio;
    }
}