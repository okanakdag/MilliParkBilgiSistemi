using System.Globalization;
class Tree {
    private CustomTreeNode? root;
    private int nodeCount;
    // to compare turkish letters
    private static CultureInfo cultureTR = new CultureInfo("tr-TR");

    public Tree(CustomTreeNode root)
    {
        this.root = root;
        nodeCount = 1;
    }

    public Tree()
    {
        root = null;
        nodeCount = 0;
    }

    public int NodeCount { get => nodeCount;}

    public void AddNode(MilliPark park)
    {
        if (root == null) root = new CustomTreeNode(park);
        else AddNode(root, park);
        nodeCount++;
    }

    private void AddNode(CustomTreeNode localRoot, MilliPark park)
    {
        if (String.Compare(localRoot.Park.MilliParkAdi, park.MilliParkAdi, true, cultureTR) > 0)
        {
            if (localRoot.Left == null) localRoot.Left = new CustomTreeNode(park);
            else AddNode(localRoot.Left, park);
        }
        else
        {
            if (localRoot.Right == null) localRoot.Right = new CustomTreeNode(park);
            else AddNode(localRoot.Right, park);
        }
    }
    
    public void PrintPreorder() 
    {
        PrintPreorder(root);
    }

    private void PrintPreorder(CustomTreeNode? node)
    {
        if (node != null)
        {
            Console.WriteLine(node.Park);
            PrintPreorder(node.Left);
            PrintPreorder(node.Right);
        }
    }

    public bool IsEmpty()
    {
        return (root == null);
    }
}