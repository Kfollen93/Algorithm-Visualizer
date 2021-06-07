using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    public partial class Form1 : Form
    {
        int[] arrayToSort;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            int numEntries = panel1.Width;
            int maxVal = panel1.Height;
            arrayToSort = new int[numEntries];
            graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxVal);
            Random random = new Random();

            for(int i = 0; i < numEntries; i++)
            {
                arrayToSort[i] = random.Next(0, maxVal);
            }

            for (int i = 0; i < numEntries; i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.White), i, maxVal - arrayToSort[i], 10, maxVal);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ISortable bubbleSort = new BubbleSort();
            bubbleSort.RunBubbleSort(arrayToSort, graphics, panel1.Height);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Method for the drop down selection. Values are typed in as a collection from the properties box.
        }
    }
}
