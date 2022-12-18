using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Collections;

CultureInfo cultureinfo = new CultureInfo("tr-TR");
Tree tree = new Tree();
Hashtable parkTable = new Hashtable();

foreach (string line in File.ReadLines(@"parklar_test.csv").Skip(1))
{

    string[] bilgiler = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

    string milliParkAdi = bilgiler[1];
    string ilAdi = bilgiler[2];

    int yuzOlcumu;
    if(bilgiler[3][0] == '\"')
        yuzOlcumu = int.Parse(bilgiler[3].Replace("\"","").Replace(",",""));
    else 
        yuzOlcumu = int.Parse(bilgiler[3]);
    
    DateTime ilanTarihi = DateTime.Parse(bilgiler[4],cultureinfo);
    string bilgi = bilgiler[5].Replace("\"","");
    List<string> parkBilgileri = new List<string>();
    parkBilgileri.AddRange(bilgi.Split(".",StringSplitOptions.RemoveEmptyEntries));

    MilliPark park = new MilliPark(milliParkAdi, ilAdi, ilanTarihi, yuzOlcumu, parkBilgileri);
    tree.AddNode(park);
    parkTable.Add(park.MilliParkAdi, park);

    Console.WriteLine("ses");
}

tree.PrintPreorder();
Console.WriteLine(tree.NodeCount);
Console.WriteLine(tree.getTreeDepth());


bool updateDate(string milliParkAdi, string ilanTarihi) {
    if(!parkTable.ContainsKey(milliParkAdi))
        return false;

    MilliPark p = (MilliPark)parkTable[milliParkAdi];
    p.IlanTarihi = DateTime.Parse(ilanTarihi, cultureinfo);
    parkTable[milliParkAdi] = p;
    return true;
} 

void printMilliParkHashTable(Hashtable parkTable) {
    foreach(DictionaryEntry park in parkTable) {
        Console.WriteLine("Park Adi: {0} \n Park Nesnesi: {1} ",
                                park.Key, park.Value);
    }
}

Console.Write("HashTable'da ilan tarihini guncellemek istediginiz milli parkin adini giriniz: ");
string parkIsimInput = Console.ReadLine();
Console.Write("Yeni ilan tarihini giriniz (GG.AA.YYYY): ");
string parkTarihInput = Console.ReadLine();
updateDate(parkIsimInput,parkTarihInput);
printMilliParkHashTable(parkTable);

