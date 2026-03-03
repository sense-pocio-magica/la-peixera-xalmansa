namespace Tasca;

public class Tauro : Animals, IReproductor
{
    private int EscollirSexe = 0;
    private int VidaRondes;
    public Tauro(bool esunhome, List<(int, int)> posicio, bool viu, int direccio)
        : base (esunhome, posicio, viu, direccio)
    {
        VidaRondes = 0;
    }

    public Animals Reproduir(Animals altre)
    {
        if (EscollirSexe == 0)
        {
            EscollirSexe = 1;
            return new Tauro(true, new List<(int, int)>(), true, 0);
        }
        else
        {
            EscollirSexe = 0;
            return new Tauro(false, new List<(int, int)>(), true, 0);
        }
    }

    public void ComprovarSiHanPassat50Rondes()
    {
        
    }
}