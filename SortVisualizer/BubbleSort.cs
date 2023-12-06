using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class BubbleSort : ISortable
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        bool sorted = false;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void doWork(int[] ar, Graphics graph, int mv)
        {
            TheArray = ar;
            g = graph;
            MaxVal = mv;

            while(!sorted)
            {
                for (int i = 0; i < TheArray.Count() - 1; i++)
                {
                    if (TheArray[i] > TheArray[i + 1])
                    {
                        Swap(i, i + 1);
                    }
                }
                sorted = isSorted();
            }
        }

        private void Swap(int i, int j)
        {
            // Temporary color for swapping
            Brush swapBrush = new SolidBrush(Color.Red);

            // Highlight bars about to be swapped
            DrawBar(i, TheArray[i], swapBrush);
            DrawBar(j, TheArray[j], swapBrush);

            // Introduce a delay to visualize the swap
            Thread.Sleep(01); // Adjust the time as needed

            // Perform the swap
            int temp = TheArray[i];
            TheArray[i] = TheArray[j];
            TheArray[j] = temp;

            // Redraw the bars in original color after swap
            DrawBar(i, TheArray[i], WhiteBrush);
            DrawBar(j, TheArray[j], WhiteBrush);
        }

        private void DrawBar(int position, int height, Brush brush)
        {
            int barWidth = 4;
            g.FillRectangle(BlackBrush, position * barWidth, 0, barWidth, MaxVal); // Clear the bar area
            g.FillRectangle(brush, position * barWidth, MaxVal - height, barWidth, MaxVal); // Draw the bar
        }

        private bool isSorted()
        {
            for(int i = 0; i < TheArray.Count()-1; i++)
            {
                if (TheArray[i] > TheArray[i + 1]) return false;
            }
            return true;
        }
    }
}
