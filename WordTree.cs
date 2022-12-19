using System.Globalization;
using System.Text;
class WordTree
{
    private WordTreeNode? root;
    private static CultureInfo cultureTR = new CultureInfo("tr-TR");

    public WordTree()
    {
        root = null;
    }

    public WordTree(WordTreeNode root)
    {
        this.root = root;
    }
    
    public WordTree(string rootWord)
    {
        this.root = new WordTreeNode(rootWord);
    }
    public void AddNode(string word)
    {
        if (root == null) root = new WordTreeNode(word);
        else AddNode(root, word);
    }

    private void AddNode(WordTreeNode localRoot, string word)
    {
        if (String.Compare(localRoot.Word, word, true, cultureTR) == 0)
        {
            localRoot.Count++;
        }
        else if (String.Compare(localRoot.Word, word, true, cultureTR) > 0)
        {
            if (localRoot.Left == null) localRoot.Left = new WordTreeNode(word);
            else AddNode(localRoot.Left, word);
        }
        else
        {
            if (localRoot.Right == null) localRoot.Right = new WordTreeNode(word);
            else AddNode(localRoot.Right, word);
        }
    }

    public override string ToString()
    {   
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("|{0,-24}|{1,-8}|\n","KELİME", "SAYI"));
        ToString(root, sb);

        return sb.ToString();
    }

    private void ToString(WordTreeNode? localRoot, StringBuilder sb)
    {
        if (localRoot != null)
        {
            sb.Append(String.Format("|{0,-24}|{1,-8}|\n", localRoot.Word, localRoot.Count));
            ToString(localRoot.Left, sb);
            ToString(localRoot.Right, sb);
        }
    }
}