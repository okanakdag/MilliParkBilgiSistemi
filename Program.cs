using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

foreach (string line in File.ReadLines(@"parklar.csv").Skip(1))
{

    CultureInfo cultureinfo = new CultureInfo("tr-TR");
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
    parkBilgileri.AddRange(bilgi.Split("."));

    MilliPark park = new MilliPark(milliParkAdi, ilAdi, ilanTarihi, yuzOlcumu, parkBilgileri);
    Console.WriteLine(park + "\n");
}
