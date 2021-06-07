using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Visualizer
{
    class BubbleSort : ISortable
    {
        private bool isSorted = false;
        private int[] arrayToSort;
        private Graphics graphics;
        private int maxVal;
        private Brush white = new SolidBrush(Color.White);
        private Brush black = new SolidBrush(Color.Black);

        public void RunBubbleSort(int[] _arrayToSort, Graphics _graphics, int _maxVal)
        {
            arrayToSort = _arrayToSort;
            graphics = _graphics;
            maxVal = _maxVal;

            while (!isSorted)
            {
                for(int i = 0; i < arrayToSort.Count() - 1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        Swap(i, i + 1);
                    }
                }

                isSorted = IsArraySorted();
            }
        }

        private void Swap(int i, int adjacentVal)
        {
            int temp = arrayToSort[i];
            arrayToSort[i] = arrayToSort[i + 1];
            arrayToSort[i + 1] = temp;

            graphics.FillRectangle(black, i, 0, 1, maxVal);
            graphics.FillRectangle(black, adjacentVal, 0, 1, maxVal);

            graphics.FillRectangle(white, i, maxVal - arrayToSort[i], 1, maxVal);
            graphics.FillRectangle(white, adjacentVal, maxVal - arrayToSort[adjacentVal], 1, maxVal);
        }

        private bool IsArraySorted()
        {
            for (int i = 0; i < arrayToSort.Count() - 1; i++)
            {
                if (arrayToSort[i] > arrayToSort[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

/* An additional bubble sort solution that I made using recursion:
 
    public static void RunBubbleSort(int[] arrayToSort)
    {
        for(int i = 0; i < arrayToSort.Length; i++)
        {
            for(int inner = i + 1; inner < arrayToSort.Length; inner++)
            {
                if (arrayToSort[i] <= arrayToSort[inner])
                {
                    continue;
                }
                else
                {
                    arrayToSort[i] = arrayToSort[inner];
                    arrayToSort[inner] = arrayToSort[i];
                }
            }
        }

        // Check if array is sorted

        for (int i = 1; i < arrayToSort.Length; i++)
        {
            if (arrayToSort[i - 1] > arrayToSort[i])
            {
                RunBubbleSort(arrayToSort);
            }
            else
            {
                Console.WriteLine("Array is sorted");
                return;
            }
        }
    }
 */
