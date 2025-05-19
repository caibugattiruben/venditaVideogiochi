string maggiore(List<string> vendite)
{
    float max = float.Parse(vendite[0].Split('|')[4].Replace('.', ','));
    string nomeMax= vendite[0].Split(',')[0];
    foreach (string v in vendite)
    {
        string[] array = v.Split('|');
        if (float.Parse(array[4].Replace('.', ',')) > max)
        {
            max = float.Parse(array[4].Replace('.', ','));
            nomeMax = array[0];
        }
    }
    return nomeMax;
}
float incasso(List<string> vendite)
{
    float incassi = 0;
    foreach (string v in vendite)
    {
        incassi+= float.Parse(v.Split('|')[4].Replace('.', ','));   
    }
    return incassi;
}
void giochi(List<string> vendite)
{
    string path = "giochi_anni_2000.txt";
    StreamWriter w = new StreamWriter(path, true);
    foreach (string v in vendite)
    {
        int anno = int.Parse(v.Split('|')[3]);
        if (anno >= 2000)
        {
            w.WriteLine(v.Split('|')[0]);
        }
    }
    w.Close();
}
void generi(List<string> vendite)
{
    string path = "generi.txt";
    StreamWriter w = new StreamWriter(path);
    List<string> generi = new List<string>();
    foreach (string v in vendite)
    {
        string genere = v.Split('|')[2];
        if (!generi.Contains(genere))
        {
            w.WriteLine(genere);
            generi.Add(genere);
        }
    }
    w.Close();
}
void genere(List<string> vendite)
{
    string path = "giochi_genere.txt";
    StreamWriter w = new StreamWriter(path);
    Console.WriteLine("Dimmi il genere");
    string genereU = Console.ReadLine();
    foreach (string v in vendite)
    {
        string genere = v.Split('|')[2];
        if (genere == genereU)
        {
            w.WriteLine(v.Split('|')[0]);
        }
    }
    w.Close();
}
void conteggio(List<string> vendite)
{
    List <string> piattaforme=new List<string>();
    foreach (string v in vendite)
    {
        if (!piattaforme.Contains(v.Split('|')[1]))
        {
            piattaforme.Add(v.Split('|')[1]);
        }
    }
    int[] quantità=new int[piattaforme.Count];
    foreach (string v in vendite)
    {
        quantità[piattaforme.IndexOf(v.Split('|')[1])]++;
    }
    string path = "conteggio_piattaforme.txt";
    StreamWriter w = new StreamWriter(path);
    foreach(string v in piattaforme)
    {
        w.WriteLine(v + " = " + quantità[piattaforme.IndexOf(v)]);
    }
    w.Close();
}
List <string> vendite=new List<string>();
string path = "videogiochi.txt";
StreamReader r = new StreamReader(path);
string riga=r.ReadLine();
riga = r.ReadLine();
while (riga != null)
{
    vendite.Add(riga);
    riga = r.ReadLine();
}
string max = maggiore(vendite);
Console.WriteLine(max);
float incassi=incasso(vendite);
Console.WriteLine(incassi);
giochi(vendite);
generi(vendite);
genere(vendite);
conteggio(vendite);