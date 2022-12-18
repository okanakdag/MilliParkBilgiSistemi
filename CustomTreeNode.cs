public class CustomTreeNode
{
    private MilliPark park;
    private CustomTreeNode? left;
    private CustomTreeNode? right;

    public CustomTreeNode(MilliPark park)
    {
        this.park = park;
        left = null;
        right = null;
    }

    public CustomTreeNode? Right { get => right; set => right = value; }
    public CustomTreeNode? Left { get => left; set => left = value; }
    public MilliPark Park { get => park; set => park = value; }
}
