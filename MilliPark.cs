public class MilliPark 
{
    private string milliParkAdi;
    private List<string> ilAdlari;
    private DateTime ilanTarihi;
    private int yuzOlcumu;

    public MilliPark(string milliParkAdi, List<string> ilAdlari,
     DateTime ilanTarihi, int yuzOlcumu)
    {
        this.milliParkAdi = milliParkAdi;
        this.ilAdlari = new List<string>(ilAdlari);
        this.ilanTarihi = ilanTarihi;
        this.yuzOlcumu = yuzOlcumu;
    }

    public MilliPark(MilliPark park)
    {
        milliParkAdi = park.MilliParkAdi;
        ilAdlari = new List<string>(park.IlAdlari);
        ilanTarihi = park.IlanTarihi;
        yuzOlcumu = park.YuzOlcumu;
    }

    public string MilliParkAdi
    { get => milliParkAdi; set => milliParkAdi = value; }
    public List<string> IlAdlari
    { get => new List<string>(ilAdlari); set => ilAdlari = value; }
    public DateTime IlanTarihi
    { get => ilanTarihi; set => ilanTarihi = value; }
    public int YuzOlcumu
    { get => yuzOlcumu; set => yuzOlcumu = value; }

    public override string ToString()
    {
        return (milliParkAdi + string.Join(", ", ilAdlari) + ilanTarihi.ToShortDateString() + yuzOlcumu);
    }
}