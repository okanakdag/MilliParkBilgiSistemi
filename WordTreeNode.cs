class WordTreeNode
{
    private string word;
    private int count = 0;
    private WordTreeNode? left;
    private WordTreeNode? right;

    public WordTreeNode(string word)
    {
        this.word = word;
        count++;
    }

    public int Count { get => count; set => count = value; }
    public string Word { get => word; set => word = value; }
    public WordTreeNode? Right { get => right; set => right = value; }
    public WordTreeNode? Left { get => left; set => left = value; }
}