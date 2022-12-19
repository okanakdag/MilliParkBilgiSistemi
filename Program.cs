using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Collections;

CultureInfo cultureinfo = new CultureInfo("tr-TR");
Tree tree = new Tree();
Hashtable parkTable = new Hashtable();
PriorityQueue<MilliPark, int> pq = new(new IntMaxCompare());

foreach (string line in File.ReadLines(@"parklar.csv").Skip(1))
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
    parkBilgileri.AddRange(bilgi.Split(". ",StringSplitOptions.RemoveEmptyEntries));

    MilliPark park = new MilliPark(milliParkAdi, ilAdi, ilanTarihi, yuzOlcumu, parkBilgileri);
    tree.AddNode(park);
    parkTable.Add(park.MilliParkAdi, park);
    pq.Enqueue(park, park.YuzOlcumu);

}

tree.PrintPreorder();
Console.WriteLine("Ağaç derinliği: " + tree.GetTreeDepth());
Console.WriteLine("Dengeli ağaç olsaydı derinliği" + 
                    tree.GetBalancedTreeDepth());


bool updateDate(string milliParkAdi, string ilanTarihi) {
    if(!parkTable.ContainsKey(milliParkAdi))
        return false;

    MilliPark? p = (MilliPark?)parkTable[milliParkAdi];
    if(p != null)
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
string? parkIsimInput = Console.ReadLine();
Console.Write("Yeni ilan tarihini giriniz (GG.AA.YYYY): ");
string? parkTarihInput = Console.ReadLine();
if(parkIsimInput != null && parkTarihInput != null)
    updateDate(parkIsimInput,parkTarihInput);
printMilliParkHashTable(parkTable);


CustomMaxHeap maxHeap = new CustomMaxHeap(pq.Count);
while (pq.TryDequeue(out MilliPark? item, out int priority))
{
    maxHeap.insert(item);
}
maxHeap.printHeap();

Console.WriteLine("Yuzolcumune gore en buyuk olup MaxHeap'ten cikarilan parklarin bilgileri: ");
Console.WriteLine(maxHeap.pop());
Console.WriteLine(maxHeap.pop());
Console.WriteLine(maxHeap.pop());

Console.WriteLine(tree.SearchPark("far") + "\n");

WordTree wordTree = new WordTree();
tree.FillWordTree(wordTree);
// Kelime ağacını yazdırma metodu, çıktısı uzun diye yorumladık
// Console.WriteLine(wordTree);

int BubbleSort(int[] array)
{
    int stepCounter = 0;
    int arrayLength = array.Length;
    for (int i = 0; i < arrayLength - 1; i++)
    {
        bool ordered = true;
        for (int j = 0; j < arrayLength - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
                ordered = false;
            }
            stepCounter++;
        }

        if (ordered)
            break;
    }
    return stepCounter;
}

int[] orderedArray = {1,2,3,4,5,6,7,8};
int[] reversedArray = {8,7,6,5,4,3,2,1};
int[] randomArray = {1,2,3,6,5,4,7,8};

// Best case O(n)
Console.WriteLine(BubbleSort(orderedArray));
// Worst case O(n^2)
Console.WriteLine(BubbleSort(reversedArray));
// Average case O(n^2)
Console.WriteLine(BubbleSort(randomArray));

foreach (int n in orderedArray) Console.Write(n);
Console.WriteLine();
foreach (int n in reversedArray) Console.Write(n);
Console.WriteLine();
foreach (int n in randomArray) Console.Write(n);