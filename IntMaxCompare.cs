public class IntMaxCompare : IComparer<int> {
    public int Compare(int x, int y) => y.CompareTo(x);
}