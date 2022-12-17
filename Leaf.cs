public class Leaf
{
    private MilliPark park;
    private Leaf? left;
    private Leaf? right;

    public Leaf(MilliPark park)
    {
        this.park = park;
        Left = null;
        Right = null;
    }

    public Leaf? Right { get => right; set => right = value; }
    public Leaf? Left { get => left; set => left = value; }
    public MilliPark Park { get => park; set => park = value; }
}
