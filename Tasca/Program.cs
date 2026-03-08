namespace Tasca;

internal class Program
{
    private static Partida Partida = new Partida();
    public static void Main()
    {
        Partida.Inicialitza();
        Console.WriteLine(Partida.QuinsAnimalsHanQuedatVius());
    }
}