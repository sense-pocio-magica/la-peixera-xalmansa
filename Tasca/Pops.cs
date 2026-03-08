namespace Tasca;

public class Pops : Animals
{
    public Pops(bool esunhome, List<(int, int)> posicio, bool viu, int direccio)
        : base (esunhome, posicio, viu, direccio)
    {
    }

    protected override List<(int, int)> CanviPosicio(List<(int, int)> PosicioAnimal)
    {
        int x = PosicioAnimal[0].Item1;
        int y = PosicioAnimal[0].Item2;

        if (Direccio == 0) y--;
        else if (Direccio == 1) x--;
        else if (Direccio == 2) y++;
        else x++;

        if (x < 0) x = 19;
        if (x > 19) x = 0;
        if (y < 0) y = 19;
        if (y > 19) y = 0;
        
        if (x != 0 && x != 19 && y != 0 && y != 19)
        {
            if (x < 10) x = 0;
            else x = 19;
        }
        
        PosicioAnimal.Clear();
        PosicioAnimal.Add((x,y));
        
        return PosicioAnimal;
    }
}