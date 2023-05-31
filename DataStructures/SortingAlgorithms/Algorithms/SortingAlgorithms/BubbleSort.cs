namespace SortingAlgorithms
{
    public class BubbleSort
    {
        //Baloncuk sıralama
        public static void Sort<T>(T[] arr)
            where T: IComparable<T>
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    //CompareTo;
                    // -1 => küçükse
                    // 0 eşitse
                    // 1 => büyükse
                    if (arr[j].CompareTo(arr[j+1]) >= 1)
                        Sorting.Swap(arr, j, j+1);
        }
    }
}