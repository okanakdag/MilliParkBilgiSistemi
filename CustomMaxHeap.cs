public class CustomMaxHeap {

    private MilliPark[] heapArr;
    private int size;
    private int index = 0;
    public CustomMaxHeap(int size) {
        this.size = size;
        heapArr = new MilliPark[size+1];
    }

    public void insert(MilliPark park) {
        heapArr[++index] = park;
    }

    public void printHeap() {
        for (int i = 1; i <= index; i++)
        {
            Console.WriteLine(heapArr[i].YuzOlcumu);
        }
    }

    private int getLeftChild(int itemIndex) {
        return (2 * itemIndex);
    }
    private int getRightChild(int itemIndex) {
        return (2 * itemIndex) + 1;
    }
    private int getParent(int itemIndex) {
        return itemIndex/2;
    }    
    private bool hasLeftChild(int itemIndex) {
        return getLeftChild(itemIndex) < index;
    }
    private bool hasRightChild(int itemIndex) {
        return getRightChild(itemIndex) < index;
    }

    private void swap(int first, int second) {
        MilliPark p = heapArr[first];
        heapArr[first] = heapArr[second];
        heapArr[second] = p;
    }

    public MilliPark pop() {
        if(isEmpty())
            throw new IndexOutOfRangeException();
        MilliPark park = heapArr[1];
        heapArr[1] = heapArr[index--];
        heapify();
        return park;   
    }
    
    private void heapify() {
        int i = 1;
        while (hasLeftChild(i))
        {
            int j  = getLeftChild(i);
            if (hasRightChild(i) && heapArr[getRightChild(i)].YuzOlcumu > heapArr[getLeftChild(i)].YuzOlcumu)
                j = getRightChild(i);
            if (heapArr[j].YuzOlcumu < heapArr[i].YuzOlcumu)
                break;
            swap(j, i);
            i = j;
        }
    }
    public bool isEmpty() {
        return index == 0;
    }

}