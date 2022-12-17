public class MilliPark 
{
    private string milliParkAdi;
    private string ilAdi;
    private DateTime ilanTarihi;
    private int yuzOlcumu;
    private List<string> parkBilgileri;

    public MilliPark(string milliParkAdi, string ilAdi,
     DateTime ilanTarihi, int yuzOlcumu, List<string> parkBilgileri)
    {
        this.milliParkAdi = milliParkAdi;
        this.ilAdi = ilAdi;
        this.ilanTarihi = ilanTarihi;
        this.yuzOlcumu = yuzOlcumu;
        this.parkBilgileri = new List<string>(parkBilgileri);
    }

    public MilliPark(MilliPark park)
    {
        milliParkAdi = park.MilliParkAdi;
        ilAdi = park.ilAdi;
        ilanTarihi = park.IlanTarihi;
        yuzOlcumu = park.YuzOlcumu;
        parkBilgileri = park.ParkBilgileri;
    }

    public string MilliParkAdi
    { get => milliParkAdi; set => milliParkAdi = value; }
    public string IlAdi
    { get => ilAdi; set => ilAdi = value; }
    public DateTime IlanTarihi
    { get => ilanTarihi; set => ilanTarihi = value; }
    public int YuzOlcumu
    { get => yuzOlcumu; set => yuzOlcumu = value; }
    public List<string> ParkBilgileri
    { get => new List<string>(parkBilgileri); set => parkBilgileri = value; }

    public override string ToString()
    {
        return (milliParkAdi + " " + ilAdi + " " +
        ilanTarihi.ToShortDateString() + " " + yuzOlcumu + "\n" +
        string.Join("\n", parkBilgileri) + "\n");
    }
}