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
    private Tauro Tauro;
    private int CanviDireccioTauro;
    private int ContadorTortuges;
    private int ContadorPeixosNormals;
    private int ContadorTaurons;
    private int ContadorPops;
    private int DireccioNovaPelFill;
    
    public Partida()
    {
        Tauler = new Tauler();
        for (int i = 0; i < 100; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 50)
            {
                LlistaDeAnimals.Add(new PeixosNormals(false, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
            else
            {
                LlistaDeAnimals.Add(new PeixosNormals(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
        }

        for (int i = 0; i < 10; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 5)
            {
                LlistaDeAnimals.Add(new Tauro(false, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
            else
            {
                LlistaDeAnimals.Add(new Tauro(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
            }
        }

        for (int i = 0; i < 15; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            LlistaDeAnimals.Add(new Pops(true, new List<(int, int)> { (PrimerNumero, SegonNumero) }, true, PosicioOnEsMoure));
        }

        for (int i = 0; i < 6; i++)
        {
            PrimerNumero = Random.Next(0, 20);
            SegonNumero = Random.Next(0, 20);
            PosicioOnEsMoure = Random.Next(0, 4);
            if (i < 3)
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
        while (Ronda <= 100)
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
            
            foreach (var GrupAnimals in Colisions)
            {
                Tauro = null;

                foreach (var animal in GrupAnimals)
                {
                    if (animal is Tauro)
                    {
                        Tauro = (Tauro)animal;
                        Tauro.VidaRondes++;
                        if (Tauro.VidaRondes >= 75)
                        {
                            Tauro.ElAnimalHaMort();
                        }
                        break;
                    }
                }

                if (Tauro != null)
                {
                    foreach (var animal in GrupAnimals)
                    {
                        if (animal == Tauro) continue;

                        if (animal is Tortugues)
                        {
                            while (true)
                            {
                                int direccioantiga = Tauro.RetornaDireccio();
                                CanviDireccioTauro = Random.Next(0, 4);
                                if (direccioantiga != CanviDireccioTauro) break;
                            }
                            
                            Tauro.AssignarOnEsMoure(CanviDireccioTauro);
                        }
                        else
                        {
                            animal.ElAnimalHaMort();
                        }
                    }
                }

                for (int i = 0; i < GrupAnimals.Count; i++)
                {
                    for (int j = i + 1; j < GrupAnimals.Count; j++)
                    {
                        Animals Animal1 = GrupAnimals[i];
                        Animals Animal2 = GrupAnimals[j];
                        
                        if (!Animal1.ElAnimalEstaViu() || !Animal2.ElAnimalEstaViu())
                            continue;

                        if (Animal1 is not Pops && Animal2 is not Pops)
                        {
                            if (Animal1.GetType() == Animal2.GetType())
                            {
                                if (Animal1.EsMascle() != Animal2.EsMascle())
                                {
                                    if (Animal1 is IReproductor reproductor)
                                    {
                                        Animals fill = reproductor.Reproduir(Animal2);

                                        var PosicioHeredada = Animal1.RetornaPosicio();
                                        
                                        foreach (var posicionova in PosicioHeredada)
                                        {
                                            fill.AssignarPosicio(posicionova.Item1, posicionova.Item2);
                                        }

                                        while (true)
                                        {
                                            DireccioNovaPelFill = Random.Next(0,4);
                                            if (Animal1.RetornaDireccio() != DireccioNovaPelFill) break;
                                        }
                                        fill.AssignarOnEsMoure(DireccioNovaPelFill);

                                        LlistaDeAnimals.Add(fill);
                                    }
                                }
                                else
                                {
                                    Animal1.ElAnimalHaMort();
                                    Animal2.ElAnimalHaMort();
                                }
                            }
                        }
                    }
                }
            }

            Ronda++;
        }

        foreach (var animal in LlistaDeAnimals)
        {
            if (!animal.ElAnimalEstaViu()) continue;
            
            if (animal is Tauro)
            {
                ContadorTaurons++;
            }
            else if (animal is Pops)
            {
                ContadorPops++;
            }
            else if (animal is PeixosNormals)
            {
                ContadorPeixosNormals++;
            }
            else
            {
                ContadorTortuges++;
            }
        }
    }

    public string QuinsAnimalsHanQuedatVius()
    {
        return
            $"Han quedat: {ContadorTaurons} taurons.\nHan quedat: {ContadorPops} pops.\nHan quedat: {ContadorPeixosNormals} peixos normals.\nHan quedat: {ContadorTortuges} tortugues.";
    }
}