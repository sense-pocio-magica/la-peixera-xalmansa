namespace Tasca;

public class Tortugues : Animals, IReproductor
{
    private int EscollirSexe = 0;
    public Tortugues(bool esunhome, List<(int, int)> posicio, bool viu, int direccio)
        : base (esunhome, posicio, viu, direccio)
    {
        
    }

    public Animals Reproduir(Animals altre)
    {
        if (EscollirSexe == 0)
        {
            EscollirSexe = 1;
            return new Tortugues(true, new List<(int, int)>(), true, 0);
        }
        else
        {
            EscollirSexe = 0;
            return new Tortugues(false, new List<(int, int)>(), true, 0);
        }
    }
}