using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Algorithm_Visualizer
{
    class BubbleSort : ISortable
    {
        private int[] arrayToSort;
        private Graphics graphics;
        private int maxVal;
        private Brush white = new SolidBrush(Color.White);
        private Brush black = new SolidBrush(Color.Black);
        private Brush red = new SolidBrush(Color.Red);
        private Brush yellow = new SolidBrush(Color.Yellow);
        private Brush green = new SolidBrush(Color.Green);

        public BubbleSort(int[] _arrayToSort, Graphics _graphics, int _maxVal)
        {
            arrayToSort = _arrayToSort;
            graphics = _graphics;
            maxVal = _maxVal;
        }

        public void NextStep()
        {
            for(int i = 0; i < arrayToSort.Count() - 1; i++)
            {
                if (arrayToSort[i] > arrayToSort[i + 1])
                {
                    Swap(i, i + 1);
                }
            }
        }

        private void Swap(int i, int adjacentVal)
        {
            int temp = arrayToSort[i];
            arrayToSort[i] = arrayToSort[i + 1];
            arrayToSort[i + 1] = temp;

            DrawBar(i, arrayToSort[i]);
            DrawBar(adjacentVal, arrayToSort[adjacentVal]);
        }

        private void DrawBar(int position, int height)
        {
            // Black background
            graphics.FillRectangle(black, position, 0, 1, maxVal);
            // Height in white for bars
            graphics.FillRectangle(red, position, maxVal - arrayToSort[position], 1, maxVal);
        }

        public bool IsSorted()
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

        public void ReDraw()
        {
            for(int i = 0; i < (arrayToSort.Count() - 1); i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.White), i, maxVal - arrayToSort[i], 1, maxVal);
            }
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
