using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace RealVisualSorting
{


    public partial class Form1 : Form
    {
        private static int[] array;
        private static string[] sorts = { "Simple Swap Sort" , "Selection Sort", "Bubble Sort", "Insertion Sort", "Quick Sort", "Merge Sort",
                                          "Heap Sort", "Intro Sort", "Shell Sort", "Cycle Sort", "Gravity Sort","Cocktail Shaker Sort",
                                          "Comb Sort", "Gnome Sort", "Odd-Even Sort","Bitonic Sort(only sorts powers of 2)","Random Number Sort",
                                          "Radix Sort", "Slow Sort", "Quick Merge Sort", "Double Insertion Sort", "Counting Sort", "Selection Merge Sort",
                                          "Bubble Merge Sort", "Insertion Merge Sort", "Shell Merge Sort" };
        int selected = 0;
        private static Panel pnlArray2; private static int h;
        private static Diagram diag; private int oszto = 2; int delay = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void General(out int[] array, int h, int k, int min, int max)
        {
            Random rnd = new Random();
            array = new int[h];
            for (int i = 0; i < h; i++)
            {
                array[i] = rnd.Next(min, max);
            }

            for (int i = 0; i < k; i++)
            {
                int x = rnd.Next(0, h);
                int y = rnd.Next(0, h);
                int s = array[x];
                array[x] = array[y];
                array[y] = s;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            listBox1.Items.AddRange(sorts);
            pnlArray2 = pnlArray;
            h = pnlArray2.Width / oszto;
            listBox1.SelectedIndex = 0;
            General(out array, h, 5000, 1, pnlArray2.Height / oszto);
            diag = new Diagram(h, array.Max() - array.Min(), pnlArray2);
            diag.DrawDiagram(array, pnlArray2, 0);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            General(out array, h, 5000, 1, pnlArray2.Height / oszto);
            diag.RegenerateDiagram(pnlArray2, array.Max() - array.Min(), h);
            diag.DrawDiagram(array, pnlArray2, 0);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                callSortDelayOverride();
            }
            else
            {
                callSort();
            }
        }

        private void callSortDelayOverride()
        {
            if (selected < 10)
            {
                if (selected < 5)
                {
                    if (selected == 0) simpleSwap();
                    else if (selected == 1) selectionSort();
                    else if (selected == 2) bubbleSort();
                    else if (selected == 3) insertionSort();
                    else if (selected == 4) quickSortS();
                }
                else
                {
                    if (selected == 5) mergeSortS();
                    else if (selected == 6) heapSortS();
                    else if (selected == 7) introSortS();
                    else if (selected == 8) shellSort();
                    else if (selected == 9) cycleSort();
                }               
            }
            else if (selected < 20)
            {
                if (selected < 15)
                {
                    if (selected == 10) BeadSort();
                    else if (selected == 11) cocktailSort();
                    else if (selected == 12) combSort();
                    else if (selected == 13) gnomeSort();
                    else if (selected == 14) oddEvenSort();
                }
                else
                {
                    if (selected == 15) bitonicSortS();
                    else if (selected == 16) randomNumberSort();
                    else if (selected == 17) RadixSort();
                    else if (selected == 18) SlowSort();
                    else if (selected == 19) ExpS();
                }                
            }
            else if (selected < 30)
            {
                if (selected < 25)
                {
                    if (selected == 20) DInsertionSort();
                    else if (selected == 21) CountingSort();
                    else if (selected == 22) SMS();
                    else if (selected == 23) BMS();
                    else if (selected == 24) IMS();
                }
                else
                {
                    if (selected == 25) SHMS();
                }
            }
        }

        /* int[] arr = new int[array.Length]; Array.Copy(array, arr, array.Length);
           int n = arr.Length;*/

        private void callSort()
        {
            if (selected < 10)
            {
                if (selected < 5)
                {
                    if (selected == 0) { delay = 0; simpleSwap(); }
                    else if (selected == 1) { delay = 1; selectionSort(); }
                    else if (selected == 2) { delay = 0; bubbleSort(); }
                    else if (selected == 3) { delay = 0; insertionSort(); }
                    else if (selected == 4) { delay = 1; quickSortS(); }
                }
                else
                {
                    if (selected == 5) { delay = 1; mergeSortS(); }
                    else if (selected == 6) { delay = 1; heapSortS(); }
                    else if (selected == 7) { delay = 1; introSortS(); }
                    else if (selected == 8) { delay = 0; shellSort(); }
                    else if (selected == 9) { delay = 1; cycleSort(); }
                }  
            }
            else if (selected < 20)
            {
                if (selected < 15)
                {
                    if (selected == 10) { delay = 6; BeadSort(); }
                    else if (selected == 11) { delay = 0; cocktailSort(); }
                    else if (selected == 12) { delay = 1; combSort(); }
                    else if (selected == 13) { delay = 0; gnomeSort(); }
                    else if (selected == 14) { delay = 0; oddEvenSort(); }
                }
                else
                {
                    if (selected == 15) { delay = 0; bitonicSortS(); }
                    else if (selected == 16) { delay = 0; randomNumberSort(); }
                    else if (selected == 17) { delay = 2; RadixSort(); }
                    else if (selected == 18) { delay = 0; SlowSort(); }
                    else if (selected == 19) { delay = 1; ExpS(); }
                }               
            }
            else if(selected < 30)
            {
                if (selected < 25)
                {
                    if (selected == 20) { delay = 1; DInsertionSort(); }
                    else if (selected == 21) { delay = 2; CountingSort(); }
                    else if (selected == 22) { delay = 1; SMS(); }
                    else if (selected == 23) { delay = 0; BMS(); }
                    else if (selected == 24) { delay = 0; IMS(); }
                }
                else
                {
                    if (selected == 25) { delay = 0; SHMS(); }
                }
            }
        }

        //Shell Merge Sort
        private void SHMS()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);

            diag.DrawDiagram(sA, pnlArray, delay);

            SHMSAux(ref sA, 0, sA.Length - 1);

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        private void SHMSAux(ref int[] a, int b, int e)
        {

            if (b < e)
            {
                int m = (b + e) / 2;
                SHMSAux(ref a, b, m);
                SHMSAux(ref a, m + 1, e);
            }

            int[] gaps = { 701, 301, 132, 57, 23, 10, 4, 1 };

            foreach (int gap in gaps)
            {
                for (int i = b + gap; i < e; i++)
                {
                    int temp = a[i];
                    int j;
                    for (j = i; j >= b + gap && a[j - gap] > temp; j -= gap)
                    {
                        a[j] = a[j - gap];
                        diag.DrawDiagram(a, pnlArray2, delay, j, j - gap);
                    }
                    a[j] = temp;
                    diag.DrawDiagram(a, pnlArray2, delay, j, i);
                }
            }
        }

        //Insertion Merge Sort
        private void IMS()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);

            diag.DrawDiagram(sA, pnlArray, delay);

            IMSAux(ref sA, 0, sA.Length - 1);

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        private void IMSAux(ref int[] a, int b, int e)
        {

            if (b < e)
            {
                int m = (b + e) / 2;
                IMSAux(ref a, b, m);
                IMSAux(ref a, m + 1, e);
            }

            for (int i = b; i < e; i++)
            {
                int temp = a[i];
                int j = i;
                while (j > b && temp < a[j - 1])
                {
                    a[j] = a[j - 1];
                    diag.DrawDiagram(a, pnlArray2, delay, j, j - 1);
                    j = j - 1;
                }
                a[j] = temp;
                diag.DrawDiagram(a, pnlArray2, delay, i, j);
            }
        }

        //Bubble Merge Sort
        private void BMS()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);

            diag.DrawDiagram(sA, pnlArray, delay);

            BMSAux(ref sA, 0, sA.Length - 1);

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        private void BMSAux(ref int[] a, int b, int e)
        {
            
            if (b < e)
            {
                int m = (b + e) / 2;
                BMSAux(ref a, b, m);
                BMSAux(ref a, m + 1, e);                             
            }

            bool flag = true;

            for (int i = b + 1; i < e - 1 && flag; i++)
            {
                flag = false;
                for (int j = b; j < e - 1; j++)
                {
                    if (a[j + 1] < a[j])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        diag.DrawDiagram(a, pnlArray2, delay, j, j + 1);
                        a[j + 1] = temp;
                        diag.DrawDiagram(a, pnlArray2, delay, j, j + 1);
                        flag = true;
                    }
                }
            }
        }

        //Selection Merge Sort
        private void SMS()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);

            diag.DrawDiagram(sortingArray, pnlArray, delay);

            SMSAux(ref sortingArray, 0, sortingArray.Length - 1);

            diag.DrawDiagram(sortingArray, pnlArray, delay);
        }
        
        private void SMSAux(ref int[] a, int b, int e)
        {
            if (b < e)
            {
                int m = (b + e) / 2;
                SMSAux(ref a, b, m);
                SMSAux(ref a, m + 1, e);
            }

            for (int i = b; i < e; i++)
            {
                int min = i;
                for (int j = i + 1; j <= e; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int s = a[i];
                    a[i] = a[min];
                    diag.DrawDiagram(a, pnlArray2, delay, i, min);
                    a[min] = s;
                    diag.DrawDiagram(a, pnlArray2, delay, i, min);
                }
            }
        }

        //Counting Sort
        private void CountingSort()
        {
            int[] arr = new int[array.Length]; Array.Copy(array, arr, array.Length);
            int n = arr.Length;

            diag.DrawDiagram(arr, pnlArray, delay);

            int[] count = new int[arr.Max()];

            int[] output = new int[n];
            Array.Copy(arr, output, n);

            for (int i = 0; i < n; i++)
            {
                count[arr[i] - 1]++;
                diag.DrawDiagram(output, pnlArray, delay, i, i);
            }
                
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
                diag.DrawDiagram(output, pnlArray, delay, i, i);
            }
                
            for (int i = 0; i < n; i++)
            {
                output[count[arr[i] - 1] - 1] = arr[i];
                diag.DrawDiagram(output, pnlArray, delay, i, i);
                count[arr[i] - 1]--;
            }
        }

        //MinMaxSort = Double Insertion Sort
        private void DInsertionSort()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);
            int n = sA.Length;

            diag.DrawDiagram(sA, pnlArray, delay);

            int a = 0; int b = n - 1;

            for (int i = 0; i < n / 2; i++)
            {
                int mini = a;

                for (int j = a + 1; j < n; j++)
                {
                    if (sA[j] < sA[mini])
                    {
                        mini = j;
                    }
                }

                int s1 = sA[mini];               
                sA[mini] = sA[a];
                diag.DrawDiagram(sA, pnlArray, delay, mini, a);
                sA[a] = s1;
                diag.DrawDiagram(sA, pnlArray, delay, mini, a);
                a++;

                int maxi = b;

                for (int j = b - 1; j >= 0; j--)
                {
                    if (sA[j] > sA[maxi])
                    {
                        maxi = j;
                    }
                }

                int s2 = sA[maxi];
                sA[maxi] = sA[b];
                diag.DrawDiagram(sA, pnlArray, delay, maxi, b);
                sA[b] = s2;
                diag.DrawDiagram(sA, pnlArray, delay, maxi, b);
                b--;
            }

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        //Experimental Sort
        private void ExpS()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);
            int n = sA.Length;

            diag.DrawDiagram(sA, pnlArray, delay);

            ExpSAux(ref sA, 0, sA.Length - 1);

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        private void ExpSAux(ref int[] a, int i, int j)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                ExpSAux(ref a, i, m);
                ExpSAux(ref a, m + 1, j);
            }

            int left = i, right = j;
            int pivot = a[(left + right) / 2];

            while (i <= j)
            {
                while (a[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (a[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    diag.DrawDiagram(a, pnlArray2, delay, i, j);
                    a[j] = tmp;
                    diag.DrawDiagram(a, pnlArray2, delay, i, j);

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                quickSort(a, left, j, delay);
            }

            if (i < right)
            {
                quickSort(a, i, right, delay);
            }
            diag.DrawDiagram(a, pnlArray2, delay);
        }

        //Slow Sort
        private void SlowSort()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);
            int n = sA.Length;

            diag.DrawDiagram(sA, pnlArray, delay);

            SlowSortAux(ref sA, 0, sA.Length - 1);

            diag.DrawDiagram(sA, pnlArray, delay);
        }

        private void SlowSortAux(ref int[] a, int i, int j)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                SlowSortAux(ref a, i, m);
                SlowSortAux(ref a, m + 1, j);
                if (a[j] < a[m])
                {
                    int s = a[j];
                    a[j] = a[m];
                    diag.DrawDiagram(a, pnlArray, delay, j, m);
                    a[m] = s;
                    diag.DrawDiagram(a, pnlArray, delay, j, m);                   
                }
                SlowSortAux(ref a, i, j - 1);
            }
        }

        //Radix Sort
        private void RadixSort()
        {
            int[] sA = new int[array.Length]; Array.Copy(array, sA, array.Length);
            int n = sA.Length;

            diag.DrawDiagram(sA, pnlArray, delay);

            RadixSortAux(sA, 1);

        }

        private int[] RadixSortAux(int[] array, int digit)
        {       
            bool Empty = true;
            KVEntry[] digits = new KVEntry[array.Length];//array that holds the digits;
            int[] SortedArray = new int[array.Length];//Hold the sorted array
            Array.Copy(array, SortedArray, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                digits[i] = new KVEntry();
                digits[i].Key = i;
                digits[i].Value = (array[i] / digit) % 10;
                if (array[i] / digit != 0)
                    Empty = false;
            }

            if (Empty)
            {
                diag.DrawDiagram(SortedArray, pnlArray, delay);
                return array;
            }
                

            KVEntry[] SortedDigits = CountingSort(digits);
            for (int i = 0; i < SortedArray.Length; i++)
            {
                SortedArray[i] = array[SortedDigits[i].Key];
                diag.DrawDiagram(SortedArray, pnlArray, delay, i, SortedDigits[i].Key);
            }

            return RadixSortAux(SortedArray, digit * 10);
        }

        static KVEntry[] CountingSort(KVEntry[] ArrayA)
        {
            int[] ArrayB = new int[MaxValue(ArrayA) + 1];
            KVEntry[] ArrayC = new KVEntry[ArrayA.Length];

            for (int i = 0; i < ArrayB.Length; i++)
                ArrayB[i] = 0;

            for (int i = 0; i < ArrayA.Length; i++)
                ArrayB[ArrayA[i].Value]++;

            for (int i = 1; i < ArrayB.Length; i++)
                ArrayB[i] += ArrayB[i - 1];

            for (int i = ArrayA.Length - 1; i >= 0; i--)
            {
                int value = ArrayA[i].Value;
                int index = ArrayB[value];
                ArrayB[value]--;
                ArrayC[index - 1] = new KVEntry();
                ArrayC[index - 1].Key = i;
                ArrayC[index - 1].Value = value;
            }
            return ArrayC;
        }

        static int MaxValue(KVEntry[] arr)
        {
            int Max = arr[0].Value;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i].Value > Max)
                    Max = arr[i].Value;
            return Max;
        }

        //Random Number Sort (Experimental)
        private void randomNumberSort()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            int n = sortingArray.Length;

            diag.DrawDiagram(sortingArray, pnlArray, delay);

            while (!checkSorted(sortingArray))
            {
                int i = rnd1.Next(0, n);
                int j = rnd1.Next(0, n);
                diag.DrawDiagram(sortingArray, pnlArray, delay, i, j);
                if (i < j)
                {
                    diag.DrawDiagram(sortingArray, pnlArray, delay, i, j);
                    if (sortingArray[i] > sortingArray[j])
                    {
                        int s = sortingArray[i];
                        sortingArray[i] = sortingArray[j];
                        diag.DrawDiagram(sortingArray, pnlArray, delay, i, j);
                        sortingArray[j] = s;
                        diag.DrawDiagram(sortingArray, pnlArray, delay, i, j);
                    }
                }
                else if(i > j)
                {
                    diag.DrawDiagram(sortingArray, pnlArray, delay, j, i);
                    if (sortingArray[i] < sortingArray[j])
                    {
                        int s = sortingArray[i];
                        sortingArray[i] = sortingArray[j];
                        diag.DrawDiagram(sortingArray, pnlArray, delay, j, i);
                        sortingArray[j] = s;
                        diag.DrawDiagram(sortingArray, pnlArray, delay, j, i);
                    }
                }
            }

            diag.DrawDiagram(sortingArray, pnlArray, delay);
        }

        private bool checkSorted(int[] a)
        {
            int i = a.Length - 1;
            if (i <= 0) return true;
            if ((i & 1) > 0) { if (a[i] < a[i - 1]) return false; i--; }
            for (int ai = a[i]; i > 0; i -= 2)
                if (ai < (ai = a[i - 1]) || ai < (ai = a[i - 2])) return false;
            return a[0] <= a[1];
        }

        //Bitonic Sort
        private void bitonicSortS()
        {
            int n = array.Length;
            int h = n;
            int logn = 0;
            while (h > 1)
            {
                logn++;
                h /= 2;
            }
            int[] arr = new int[Convert.ToInt32(Math.Pow(2,logn))]; Array.Copy(array, arr, Convert.ToInt32(Math.Pow(2, logn)));
            diag.ClearDiagram();
            bitonicSort(logn, arr, arr.Length);
        }

        private void kernel(int[] a, int p, int q, int h)
        {
            int d = 1 << (p - q);

            for (int i = 0; i < h; i++)
            {
                bool up = ((i >> p) & 2) == 0;

                if ((i & d) == 0 && (a[i] > a[i | d]) == up)
                {
                    int t = a[i];
                    a[i] = a[i | d];
                    diag.DrawDiagram(a, pnlArray2, delay, i, i | d);
                    a[i | d] = t;
                    diag.DrawDiagram(a, pnlArray2, delay, i, i | d);
                }
            }
        }

        private void bitonicSort(int logn, int[] a, int h)
        {
            h = 1 << logn;

            for (int i = 0; i < logn; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    kernel(a, i, j, h);
                }
            }
            diag.DrawDiagram(a, pnlArray2, delay);
        }

        //Odd-Even Sort
        private void oddEvenSort()
        {
            int[] arr = new int[array.Length]; Array.Copy(array, arr, array.Length);
            int n = arr.Length;

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 1; i < n - 1; i+= 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int s = arr[i];
                        arr[i] = arr[i + 1];
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + 1);
                        arr[i + 1] = s;
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + 1);
                        sorted = false;
                    }
                }

                for (int i = 0; i < n - 1; i+= 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int s = arr[i];
                        arr[i] = arr[i + 1];
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + 1);
                        arr[i + 1] = s;
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + 1);
                        sorted = false;
                    }
                }
            }
            diag.DrawDiagram(arr, pnlArray2, delay);
        }

        //Gnome Sort
        private void gnomeSort()
        {
            int[] arr = new int[array.Length]; Array.Copy(array, arr, array.Length);
            int n = arr.Length;

            int pos = 0;
            while (pos < n)
            {
                if (pos == 0 || arr[pos] >= arr[pos - 1])
                {
                    pos++;
                }
                else
                {
                    int s = arr[pos];
                    arr[pos] = arr[pos - 1];
                    diag.DrawDiagram(arr, pnlArray2, delay, pos, pos - 1);
                    arr[pos - 1] = s;
                    diag.DrawDiagram(arr, pnlArray2, delay, pos, pos - 1);
                    pos--;
                }
            }
            diag.DrawDiagram(arr, pnlArray2, delay);
        }

        //Comb Sort
        private void combSort()
        {
            int[] arr = new int[array.Length]; Array.Copy(array, arr, array.Length);
            int n = arr.Length;
            int gap = n;
            double shrink = 1.3;

            bool sorted = false;

            while (!sorted)
            {
                gap = Convert.ToInt32(Math.Floor(gap / shrink));
                if (gap > 1)
                {
                    sorted = false;
                }
                else
                {
                    gap = 1;
                    sorted = true;
                }

                int i = 0;
                while (i + gap < n)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        int s = arr[i];
                        arr[i] = arr[i + gap];
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + gap);
                        arr[i + gap] = s;
                        diag.DrawDiagram(arr, pnlArray2, delay, i, i + gap);
                        sorted = false;
                    }
                    i++;
                }
            }
            diag.DrawDiagram(arr, pnlArray2, delay);
        }

        //Cocktail Sort
        private void cocktailSort()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            int n = sortingArray.Length;

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (sortingArray[i] > sortingArray[i + 1])
                    {
                        int s = sortingArray[i];
                        sortingArray[i] = sortingArray[i + 1];
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, i, i + 1);
                        sortingArray[i + 1] = s;
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, i, i + 1);
                        swapped = true;
                    }
                }

                if (swapped)
                {
                    swapped = false;
                    for (int i = n - 2; i >= 0; i--)
                    {
                        if (sortingArray[i] > sortingArray[i + 1])
                        {
                            int s = sortingArray[i];
                            sortingArray[i] = sortingArray[i + 1];
                            diag.DrawDiagram(sortingArray, pnlArray2, delay, i, i + 1);
                            sortingArray[i + 1] = s;
                            diag.DrawDiagram(sortingArray, pnlArray2, delay, i, i + 1);
                            swapped = true;
                        }
                    }

                }

            } while (swapped);
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Gravity(Bead) Sort
        private void BeadSort()
        {
            int[] data = new int[array.Length]; Array.Copy(array, data, array.Length);

            int i, j, max, sum;
            byte[] beads;

            for (i = 1, max = data[0]; i < data.Length; ++i)
                if (data[i] > max)
                    max = data[i];
                    diag.DrawDiagram(data, pnlArray2, delay, i, Array.IndexOf(data,max));

            beads = new byte[max * data.Length];

            for (i = 0; i < data.Length; ++i)
                for (j = 0; j < data[i]; ++j)
                    beads[i * max + j] = 1;

            for (j = 0; j < max; ++j)
            {
                for (sum = i = 0; i < data.Length; ++i)
                {
                    sum += beads[i * max + j];
                    beads[i * max + j] = 0;
                }

                for (i = data.Length - sum; i < data.Length; ++i)
                    beads[i * max + j] = 1;
            }

            for (i = 0; i < data.Length; ++i)
            {
                for (j = 0; j < max && Convert.ToBoolean(beads[i * max + j]); ++j) ;
                data[i] = j;
                diag.DrawDiagram(data, pnlArray2, delay, i, j);
            }

            diag.DrawDiagram(data, pnlArray2, delay);
        }

        //Cycle Sort
        private void cycleSort()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            int n = sortingArray.Length;
            for (int cycleStart = 0; cycleStart < n; cycleStart++)
            {
                int item = sortingArray[cycleStart];
                int pos = cycleStart;
                do
                {
                    int to = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (i != cycleStart && sortingArray[i] < item)
                        {
                            to++;
                        }
                    }
                    if (pos != to)
                    {
                        while (pos != to && item == sortingArray[to])
                        {
                            to++;
                            diag.DrawDiagram(sortingArray, pnlArray2, delay, to, pos);
                        }

                        int temp = sortingArray[to];
                        sortingArray[to] = item;
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, to, pos);
                        item = temp;
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, to, pos);
                        pos = to;
                    }
                } while (cycleStart != pos);
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Shell Sort
        private void shellSort()
        {
            int[] gaps = { 701, 301, 132, 57, 23, 10, 4, 1 };
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            int n = sortingArray.Length;

            foreach (int gap in gaps)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = sortingArray[i];
                    int j;
                    for (j = i; j >= gap && sortingArray[j - gap] > temp; j -= gap)
                    {
                        sortingArray[j] = sortingArray[j - gap];
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, j, j - gap);
                    }
                    sortingArray[j] = temp;
                    diag.DrawDiagram(sortingArray, pnlArray2, delay, j, i);
                }
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Intro Sort
        private void introSortS()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            IntroSort(sortingArray, delay);
        }

        private void IntroSort(int[] data, int delay)
        {
            int partitionSize = Partition(ref data, 0, data.Length - 1, delay);

            if (partitionSize < 16)
            {
                InsertionSort(ref data, delay);
            }
            else if (partitionSize > (2 * Math.Log(data.Length)))
            {
                HeapSort(ref data, delay);
            }
            else
            {
                QuickSortRecursive(ref data, 0, data.Length - 1, delay);
            }
            diag.DrawDiagram(data, pnlArray2, delay);
        }

        private static void InsertionSort(ref int[] data, int delay)
        {
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i;

                while ((j > 0))
                {
                    if (data[j - 1] > data[j])
                    {
                        data[j - 1] ^= data[j];
                        diag.DrawDiagram(data, pnlArray2, delay, j - 1, j);
                        data[j] ^= data[j - 1];
                        diag.DrawDiagram(data, pnlArray2, delay, j - 1, j);
                        data[j - 1] ^= data[j];
                        diag.DrawDiagram(data, pnlArray2, delay, j - 1, j);

                        --j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void HeapSort(ref int[] data, int delay)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(ref data, heapSize, p, delay);

            for (int i = data.Length - 1; i > 0; --i)
            {
                int temp = data[i];
                
                data[i] = data[0];
                diag.DrawDiagram(data, pnlArray2, delay, i, 0);
                data[0] = temp;
                diag.DrawDiagram(data, pnlArray2, delay, i, 0);

                --heapSize;
                MaxHeapify(ref data, heapSize, 0, delay);
            }
        }

        private static void MaxHeapify(ref int[] data, int heapSize, int index, int delay)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                diag.DrawDiagram(data, pnlArray2, delay, index, largest);
                data[largest] = temp;
                diag.DrawDiagram(data, pnlArray2, delay, index, largest);

                MaxHeapify(ref data, heapSize, largest, delay);
            }
        }

        private static void QuickSortRecursive(ref int[] data, int left, int right, int delay)
        {
            if (left < right)
            {
                int q = Partition(ref data, left, right, delay);
                QuickSortRecursive(ref data, left, q - 1, delay);
                QuickSortRecursive(ref data, q + 1, right, delay);
            }
        }

        private static int Partition(ref int[] data, int left, int right, int delay)
        {
            int pivot = data[right];
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (data[j] <= pivot)
                {
                    temp = data[j];
                    data[j] = data[i];
                    diag.DrawDiagram(data, pnlArray2, delay, j, i);
                    data[i] = temp;
                    diag.DrawDiagram(data, pnlArray2, delay, j, i);
                    i++;
                }
            }

            data[right] = data[i];
            diag.DrawDiagram(data, pnlArray2, delay, right, i);
            data[i] = pivot;
            diag.DrawDiagram(data, pnlArray2, delay, right, i);

            return i;
        }

        //Heap Sort
        private void heapSortS()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            heapSort(sortingArray, delay);
        }

        private static void heapSort(int[] array, int delay)
        {
            int heapSize = array.Length;

            buildMaxHeap(array, delay);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                int s = array[i];
                array[i] = array[0];
                diag.DrawDiagram(array, pnlArray2, delay, i, 0);
                array[0] = s;
                diag.DrawDiagram(array, pnlArray2, delay, i, 0);
                heapSize--;
                sink(array, heapSize, 0, delay);
            }
            diag.DrawDiagram(array, pnlArray2, delay);
        }

        private static void buildMaxHeap(int[] array, int delay)
        {
            int heapSize = array.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                sink(array, heapSize, i, delay);
            }
        }

        private static void sink(int[] array, int heapSize, int toSinkPos, int delay)
        {
            if (getLeftKidPos(toSinkPos) >= heapSize)
            {
                return;
            }

            int largestKidPos;
            bool leftIsLargest;

            if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)
            {
                largestKidPos = getLeftKidPos(toSinkPos);
                leftIsLargest = true;
            }
            else
            {
                largestKidPos = getRightKidPos(toSinkPos);
                leftIsLargest = false;
            }

            if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
            {
                int s = array[toSinkPos];
                array[toSinkPos] = array[largestKidPos];
                diag.DrawDiagram(array, pnlArray2, delay, toSinkPos, largestKidPos);
                array[largestKidPos] = s;
                diag.DrawDiagram(array, pnlArray2, delay, toSinkPos, largestKidPos);
                if (leftIsLargest)
                {
                    sink(array, heapSize, getLeftKidPos(toSinkPos), delay);

                }
                else
                {
                    sink(array, heapSize, getRightKidPos(toSinkPos), delay);
                }
            }

        }

        private static int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        private static int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }

        //Merge Sort
        private void mergeSortS()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            MergeSort1(ref sortingArray);
        }

        private void MergeSort2(ref int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort2(ref input, low, middle);
                MergeSort2(ref input, middle + 1, high);
                Merge(ref input, low, middle, high);
            }
        }

        private void MergeSort1(ref int[]input)
        {
            this.MergeSort2(ref input, 0, input.Length - 1);
        }

        private void Merge(ref int[] input, int low, int middle, int high)
        {
            int[] inputs = new int[input.Length]; Array.Copy(input, inputs, input.Length);
            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    inputs[low + tmpIndex] = input[left];
                    diag.DrawDiagram(inputs, pnlArray2, delay, low + tmpIndex, left);
                    left = left + 1;
                }
                else
                {
                    inputs[low + tmpIndex] = input[right];
                    diag.DrawDiagram(inputs, pnlArray2, delay, low + tmpIndex, right);
                    right = right + 1;
                }
                diag.DrawDiagram(inputs, pnlArray2, delay, left, right);
                tmpIndex = tmpIndex + 1;
            }

            while (left <= middle)
            {
                inputs[low + tmpIndex] = input[left];
                diag.DrawDiagram(inputs, pnlArray2, delay, low + tmpIndex, left);
                left = left + 1;
                tmpIndex = tmpIndex + 1;
            }

            while (right <= high)
            {
                inputs[low + tmpIndex] = input[right];
                diag.DrawDiagram(inputs, pnlArray2, delay, low + tmpIndex, right);
                right = right + 1;
                tmpIndex = tmpIndex + 1;
            }

            Array.Copy(inputs, input, inputs.Length);
            diag.DrawDiagram(inputs, pnlArray2, delay);
        }

        //Quick Sort
        private void quickSortS()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            quickSort(sortingArray, 0, sortingArray.Length - 1, delay);
        }

        public static void quickSort(int[] a, int left, int right, int delay)
        {
            int i = left, j = right;
            int pivot = a[(left + right) / 2];

            while (i <= j)
            {
                while (a[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (a[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    diag.DrawDiagram(a, pnlArray2, delay, i, j);
                    a[j] = tmp;
                    diag.DrawDiagram(a, pnlArray2, delay, i, j);

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                quickSort(a, left, j, delay);
            }

            if (i < right)
            {
                quickSort(a, i, right, delay);
            }
            diag.DrawDiagram(a, pnlArray2, delay);
        }

        //Insertion Sort
        private void insertionSort()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            int n = sortingArray.Length;
            for (int i = 0; i < n; i++)
            {
                int temp = sortingArray[i];
                int j = i;
                while (j > 0 && temp < sortingArray[j - 1])
                {
                    sortingArray[j] = sortingArray[j - 1];
                    diag.DrawDiagram(sortingArray, pnlArray2, delay, j, j - 1);
                    j = j - 1;
                }
                sortingArray[j] = temp;
                diag.DrawDiagram(sortingArray, pnlArray2, delay, i, j);
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Bubble Sort("best")
        private void bubbleSort()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            bool flag = true;
            int aL = sortingArray.Length;

            for (int i = 1; i < aL - 1 && flag; i++)
            {
                flag = false;
                for (int j = 0; j < aL - 1; j++)
                {
                    if (sortingArray[j + 1] < sortingArray[j])
                    {
                        int temp = sortingArray[j];
                        sortingArray[j] = sortingArray[j + 1];
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, j, j + 1);
                        sortingArray[j + 1] = temp;
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, j, j + 1);
                        flag = true;
                    }
                }
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Selection Sort(min)
        private void selectionSort()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            for (int i = 0; i < sortingArray.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < sortingArray.Length; j++)
                {
                    if (sortingArray[j] < sortingArray[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int s = sortingArray[i];
                    sortingArray[i] = sortingArray[min];
                    diag.DrawDiagram(sortingArray, pnlArray2, delay, i, min);
                    sortingArray[min] = s;
                    diag.DrawDiagram(sortingArray, pnlArray2, delay, i, min);
                }
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //Simple Swap Sort
        private void simpleSwap()
        {
            int[] sortingArray = new int[array.Length]; Array.Copy(array, sortingArray, array.Length);
            for (int i = 0; i < sortingArray.Length - 1; i++)
            {
                for (int j = i + 1; j < sortingArray.Length; j++)
                {
                    if (sortingArray[i] > sortingArray[j])
                    {
                        int s = sortingArray[i];
                        sortingArray[i] = sortingArray[j];
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, i, j);
                        sortingArray[j] = s;
                        diag.DrawDiagram(sortingArray, pnlArray2, delay, i, j);
                    }
                    diag.DrawDiagram(sortingArray, pnlArray2, delay, i, j);
                }
            }
            diag.DrawDiagram(sortingArray, pnlArray2, delay);
        }

        //End of sorts
        private void btnGnrtNew_Click(object sender, EventArgs e)
        {
            int h = pnlArray2.Width / oszto;
            General(out array, h, 5000, 1, pnlArray2.Height / oszto);
            //diag.ClearDiagram();
            diag.DrawDiagram(array, pnlArray2, delay);
        }

        private void btnDrawOriginal_Click(object sender, EventArgs e)
        {
            diag.DrawDiagram(array, pnlArray2, delay);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = listBox1.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > -1 && numericUpDown1.Value <= 1000)
            {
                delay = Convert.ToInt32(numericUpDown1.Value);
            }          
        }
    }

    class Diagram
    {
        private int range; private int length;
        Panel[] cuccok;

        public Diagram(int db, int r, Panel p)
        {
            range = r; length = db;
            cuccok = new Panel[p.Width];

            int w = p.Width / length;
            int h = p.Height / r;

            for (int i = 0; i < p.Width; i++)
            {
                cuccok[i] = new Panel();
                cuccok[i].Name = i.ToString();
                cuccok[i].ClientSize = new Size(w, h);
                cuccok[i].Location = new Point(i * w, 0);
                cuccok[i].BackColor = Color.White;
                cuccok[i].Dock = DockStyle.None;
                cuccok[i].Parent = p;
            }
        }

        public void ClearDiagram()
        {
            for (int i = 0; i < cuccok.Length; i++)
            {
                cuccok[i].BackColor = Color.White;
            }
        }

        private void DeleteDiagram(Panel p)
        {
            int i = 0;
            while (p.Controls.Count > 0)
            {
                p.Controls.Remove(cuccok[i]);
                p.Controls.RemoveAt(0);
                i++;
            }
        }

        private void CreateNewDiagram(Panel p, int r, int db)
        {
            range = r; length = db;
            cuccok = new Panel[p.Width];

            int w = p.Width / length;
            int h = p.Height / r;

            for (int i = 0; i < p.Width; i++)
            {
                cuccok[i] = new Panel();
                cuccok[i].Name = i.ToString();
                cuccok[i].ClientSize = new Size(w, h);
                cuccok[i].Location = new Point(i * w, 0);
                cuccok[i].BackColor = Color.White;
                cuccok[i].Dock = DockStyle.None;
                cuccok[i].Parent = p;
            }
        }

        public void RegenerateDiagram(Panel p, int r, int db)
        {
            DeleteDiagram(p);
            CreateNewDiagram(p, r, db);
        }

        public void DrawDiagram(int[] array, Panel p, int delay)
        {
            int height = p.Height; int width = p.Width;
            int w = width;
            w /= this.length;
            int h = height;
            h /= this.range;
            for (int i = 0; i < array.Length; i++)
            {
                cuccok[i].Location = new Point(i * w, (range - array[i]) * h);
                cuccok[i].Size = new Size(w, h * array[i]);
                cuccok[i].BackColor = Color.Black;     
            }
            Thread.Sleep(delay);
        }

        public void DrawDiagram(int[] array, Panel p, int delay, int i1, int i2)
        {
            int height = p.Height; int width = p.Width;
            int w = width;
            w /= this.length;
            int h = height;
            h /= this.range;
            for (int i = 0; i < array.Length; i++)
            {
                cuccok[i].Location = new Point(i * w, (range - array[i]) * h);
                cuccok[i].Size = new Size(w, h * array[i]);
                if (i == i1)
                {
                    cuccok[i].BackColor = Color.Red;
                }
                else if(i == i2)
                {
                    cuccok[i].BackColor = Color.LimeGreen;
                }
                else
                {
                    cuccok[i].BackColor = Color.Black;
                }                
            }
            Thread.Sleep(delay);
        }
    }

    struct KVEntry
    {
        int key;
        int value;

        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                if (key >= 0)
                    key = value;
                else
                    throw new Exception("Invalid key value");
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
    }

}