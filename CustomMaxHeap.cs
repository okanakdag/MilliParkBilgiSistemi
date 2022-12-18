public class CustomMaxHeap {

    private MilliPark[] heapArr;
    private int size;
    private int index = 1;
    public CustomMaxHeap(int size) {
        this.size = size;
        heapArr = new MilliPark[size+1];
    }

    public void insert(MilliPark park) {
        heapArr[index++] = park;
    }

    public void printHeap() {
        foreach (MilliPark item in heapArr)
        {
            Console.WriteLine(item);
        }
    }

}