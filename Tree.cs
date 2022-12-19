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

    public int GetTreeDepth()
    {
        return GetTreeDepth(root);
    }

    private int GetTreeDepth(CustomTreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            int leftDepth = GetTreeDepth(node.Left);
            int rightDepth = GetTreeDepth(node.Right);

            return (Math.Max(leftDepth, rightDepth) + 1);
        }
    }

    public int GetBalancedTreeDepth()
    {
        return ((int)Math.Floor(Math.Log(nodeCount, 2)) + 1);
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

    public string? SearchPark(string parkName)
    {
        if (parkName.Length != 3) return null;
        return SearchPark(root, parkName);
    }

    private string? SearchPark(CustomTreeNode? localRoot, string parkName)
    {
        if (localRoot == null)
        {
            return null;
        }
        else if (String.Compare(localRoot.Park.MilliParkAdi.Substring(0, 3),
                                 parkName, true, cultureTR) == 0)
        {
            return localRoot.Park.IlAdi;
        }
        else if (String.Compare(localRoot.Park.MilliParkAdi.Substring(0, 3),
                                 parkName, true, cultureTR) > 0)
        {
            return SearchPark(localRoot.Left, parkName);
        }
        else
        {
            return SearchPark(localRoot.Right, parkName);
        }
    }

    public void FillWordTree(WordTree tree)
    {
        FillWordTree(root, tree);
    }

    private void FillWordTree(CustomTreeNode? localRoot, WordTree tree)
    {
        if (localRoot != null)
        {
            foreach (string line in localRoot.Park.ParkBilgileri)
            {
                foreach (string word in line.Split(" "))
                tree.AddNode(TrimPuncuation(word));
            }
            FillWordTree(localRoot.Left, tree);
            FillWordTree(localRoot.Right, tree);
        }
    }

    private string TrimPuncuation(string word)
    {
        char[] punctuation = {'’', '\'', '-', '.', ',', '?', '!', ';', ':'};
        word = word.Trim(punctuation);

        int index;
        foreach(char c in punctuation)
        {
            index = word.IndexOf(c);
            if (index >= 0)
            {
                word = word.Substring(0, index);
                break;
            }
        }

        return word;
    }

    public bool IsEmpty()
    {
        return (root == null);
    }
}