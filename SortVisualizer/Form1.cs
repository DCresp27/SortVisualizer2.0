using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortVisualizer
{
    public partial class Form1 : Form
    { 
        int[] TheArray;
        Graphics g;
        BackgroundWorker bgw = null;
        bool paused = false;
        ISortable sort = new BubbleSort();


        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            
            int NumEntries = panel1.Width/4;
            int MaxVal = panel1.Height;
            TheArray = new int[NumEntries];
            Random rand = new Random();
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries*4, MaxVal); //Times 4 so that it fills the whole screen.

            for (int i = 0; i < NumEntries; i++)
            {
                TheArray[i] = rand.Next(0, MaxVal);
            }
            for (int i = 0; i < NumEntries; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i*4, MaxVal - TheArray[i], 4, MaxVal); //Times 4 so that the bars dont overlap. If they are 4 pixels wide, we only need to draw a bar every 4 pixels.
            }

        }

        private void btnStart(object sender, EventArgs e)
        {
            
            sort.doWork(TheArray, g, panel1.Height);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Bubble Sort":
                    sort = new BubbleSort();
                    break;
                case "Radix Sort":
                    sort = new RadixSort();
                    break;
                case "Insertion Sort":
                    sort = new InsertionSort();
                    break;
                case "Quick Sort":
                    sort = new QuickSort();
                    break;
                default:
                    // Code for when none of the above options are selected
                    break;
            }
        }
    }
}
