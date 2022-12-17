using System.Globalization;
class Tree {
    private Leaf? root;
    private int leafCount;
    // to compare turkish letters
    private static CultureInfo cultureTR = new CultureInfo("tr-TR");

    public Tree(Leaf root)
    {
        this.root = root;
        leafCount = 1;
    }

    public Tree()
    {
        root = null;
        leafCount = 0;
    }

    public void AddLeaf(MilliPark park)
    {
        if (root == null) root = new Leaf(park);
        else AddLeaf(root, park);
        leafCount++;
    }

    private void AddLeaf(Leaf localRoot, MilliPark park)
    {
        if (String.Compare(localRoot.Park.IlAdi, park.IlAdi, true, cultureTR) > 0)
        {
            if (localRoot.Left == null) localRoot.Left = new Leaf(park);
            else AddLeaf(localRoot.Left, park);
        }
        else
        {
            if (localRoot.Right == null) localRoot.Right = new Leaf(park);
            else AddLeaf(localRoot.Right, park);
        }
    }

    public bool IsEmpty()
    {
        return (root == null);
    }

    public void PrintPreorder() 
    {
        PrintPreorder(root);
    }

    private void PrintPreorder(Leaf? leaf)
    {
        if (leaf != null)
        {
            Console.WriteLine(leaf.Park);
            PrintPreorder(leaf.Left);
            PrintPreorder(leaf.Right);
        }
    }
}