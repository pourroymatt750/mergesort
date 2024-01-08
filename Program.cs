using System;

public class Program
{
    public static void MergeSort(int[] array)
    {
        //Overloaded, calls method below
        MergeSort(array, new int[array.Length], 0, array.Length - 1);
    }

    //Overloaded MergeSort method
    public static void MergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
    {
        if (leftStart >= rightEnd) return;

        int middle = (leftStart + rightEnd) / 2;
        MergeSort(array, temp, leftStart, middle);
        MergeSort(array, temp, middle + 1, rightEnd);
        MergeHalves(array, temp, leftStart, rightEnd);
    }

    public static void MergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
    {
        int leftEnd = (rightEnd + leftStart) / 2;
        int rightStart = leftEnd + 1;
        int size = rightEnd - leftStart + 1;

        int left = leftStart;
        int right = rightStart;
        int index = leftStart;

        while (left <= leftEnd && right <= rightEnd)
        {
            if (array[left] <= array[right])
            {
                temp[index] = array[left];
                left++;
            }
            else
            {
                temp[index] = array[right];
                right++;
            }

            index++;
        }

        Array.Copy(array, left, temp, index, leftEnd - left + 1);
        Array.Copy(array, right, temp, index, rightEnd - right + 1);
        Array.Copy(temp, leftStart, array, leftStart, size);
    }
}
