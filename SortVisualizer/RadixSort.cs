using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizer
{
    public class RadixSort : ISortable
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

            int i, m = TheArray.Max(), exp = 1;
            int[] b = new int[TheArray.Length];
            while (m / exp > 0)
            {
                int[] bucket = new int[10];

                for (i = 0; i < TheArray.Length; i++)
                    bucket[(TheArray[i] / exp) % 10]++;
                for (i = 1; i < 10; i++)
                    bucket[i] += bucket[i - 1];
                for (i = TheArray.Length - 1; i >= 0; i--)
                    b[--bucket[(TheArray[i] / exp) % 10]] = TheArray[i];
                for (i = 0; i < TheArray.Length; i++)
                {
                    HighlightBar(i, Color.Red);
                    TheArray[i] = b[i];
                    Thread.Sleep(5); // 1 millisecond sleep
                    DrawBar(i, TheArray[i]);
                }

                exp *= 10;
            }
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
