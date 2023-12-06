using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizer
{
    public class InsertionSort : ISortable
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        private Brush WhiteBrush = new SolidBrush(Color.White);
        private Brush BlackBrush = new SolidBrush(Color.Black);

        public void doWork(int[] array, Graphics graph, int maxValue)
        {
            TheArray = array;
            g = graph;
            MaxVal = maxValue;

            for (int i = 1; i < TheArray.Length; i++)
            {
                int j = i;
                while (j > 0 && TheArray[j] < TheArray[j - 1])
                {
                    Swap(j, j - 1);
                    j--;
                }
            }
        }

        private void Swap(int i, int j)
        {
            HighlightBar(i, Color.Red);
            HighlightBar(j, Color.Red);

            int temp = TheArray[i];
            TheArray[i] = TheArray[j];
            TheArray[j] = temp;

            Thread.Sleep(1); // 1 millisecond sleep

            DrawBar(i, TheArray[i]);
            DrawBar(j, TheArray[j]);
        }


        private void DrawBar(int position, int height)
        {
            int barWidth = 4;
            g.FillRectangle(BlackBrush, position * barWidth, 0, barWidth, MaxVal);
            g.FillRectangle(WhiteBrush, position * barWidth, MaxVal - height, barWidth, MaxVal);
        }

        private void HighlightBar(int position, Color color)
        {
            int barWidth = 4;
            Brush highlightBrush = new SolidBrush(color);
            g.FillRectangle(highlightBrush, position * barWidth, MaxVal - TheArray[position], barWidth, MaxVal);
        }

    }

}
