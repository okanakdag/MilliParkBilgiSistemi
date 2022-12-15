public class MilliPark 
{
    private string milliParkAdi;
    private List<string> ilAdlari;
    private DateTime ilanTarihi;
    private int yuzOlcumu;
    private List<string> parkBilgileri;

    public MilliPark(string milliParkAdi, List<string> ilAdlari,
     DateTime ilanTarihi, int yuzOlcumu, List<string> parkBilgileri)
    {
        this.milliParkAdi = milliParkAdi;
        this.ilAdlari = new List<string>(ilAdlari);
        this.ilanTarihi = ilanTarihi;
        this.yuzOlcumu = yuzOlcumu;
        this.parkBilgileri = new List<string>(parkBilgileri);
    }

    public MilliPark(MilliPark park)
    {
        milliParkAdi = park.MilliParkAdi;
        ilAdlari = park.IlAdlari;
        ilanTarihi = park.IlanTarihi;
        yuzOlcumu = park.YuzOlcumu;
        parkBilgileri = park.ParkBilgileri;
    }

    public string MilliParkAdi
    { get => milliParkAdi; set => milliParkAdi = value; }
    public List<string> IlAdlari
    { get => new List<string>(ilAdlari); set => ilAdlari = value; }
    public DateTime IlanTarihi
    { get => ilanTarihi; set => ilanTarihi = value; }
    public int YuzOlcumu
    { get => yuzOlcumu; set => yuzOlcumu = value; }
    public List<string> ParkBilgileri
    { get => new List<string>(parkBilgileri); set => parkBilgileri = value; }

    public override string ToString()
    {
        return (milliParkAdi + " " + string.Join(", ", ilAdlari) + " " +
        ilanTarihi.ToShortDateString() + " " + yuzOlcumu + "\n" +
        string.Join("\n", parkBilgileri));
    }
}