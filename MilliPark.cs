public class MilliPark 
{
    private string milliParkAdi;
    private List<string> ilAdlari;
    private string ilanTarihi;
    private int yuzOlcumu;

    public MilliPark(string milliParkAdi, List<string> ilAdlari,
     string ilanTarihi, int yuzOlcumu)
    {
        this.milliParkAdi = milliParkAdi;
        this.ilAdlari = new List<string>(ilAdlari);
        this.ilanTarihi = ilanTarihi;
        this.yuzOlcumu = yuzOlcumu;
    }

    public MilliPark(MilliPark park)
    {
        milliParkAdi = park.milliParkAdi;
        ilAdlari = new List<string>(park.IlAdlari);
        ilanTarihi = park.ilanTarihi;
        yuzOlcumu = park.yuzOlcumu;
    }

    public string MilliParkAdi
    { get => milliParkAdi; set => milliParkAdi = value; }
    public List<string> IlAdlari
    { get => new List<string>(ilAdlari); set => ilAdlari = value; }
    public string IlanTarihi
    { get => ilanTarihi; set => ilanTarihi = value; }
    public int YuzOlcumu
    { get => yuzOlcumu; set => yuzOlcumu = value; }

    public override string ToString()
    {
        return (milliParkAdi + string.Join(", ", ilAdlari) + ilanTarihi + yuzOlcumu);
    }
}