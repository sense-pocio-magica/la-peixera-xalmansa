namespace Tasca;

public class PeixosNormals : Animals, IReproductor
{
    private int EscollirSexe = 0;
    public PeixosNormals(bool esunhome, List<(int, int)> posicio, bool estaviu, int direccio)
        : base (esunhome, posicio, estaviu, direccio)
    {
        
    }
    
    public Animals Reproduir(Animals altre)
    {
        if (EscollirSexe == 0)
        {
            EscollirSexe = 1;
            return new PeixosNormals(true, new List<(int, int)>(), true, 0);
        }
        else
        {
            EscollirSexe = 0;
            return new PeixosNormals(false, new List<(int, int)>(), true, 0);
        }
    }
}