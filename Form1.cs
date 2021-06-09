using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    public partial class Form1 : Form
    {
        private int[] arrayToSort;
        private Graphics graphics;
        private BackgroundWorker backgroundWorker = null;

        public Form1()
        {
            InitializeComponent();
            PopulateDropMenu();
        }

        private void PopulateDropMenu()
        {
            List<string> algorithmList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();

            algorithmList.Sort();
            foreach (string algorithmName in algorithmList)
            {
                comboBox1.Items.Add(algorithmName);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // If user clicks start without resetting the array first, then make start button reset array
            if (arrayToSort == null)
            {
                btnReset_Click(sender, e);
            }

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(argument: comboBox1.SelectedItem);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            int numEntries = 500;
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
                graphics.FillRectangle(new SolidBrush(Color.White), i, maxVal - arrayToSort[i], 2, maxVal);
            }

        }

        // Background Worker
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            string sortEngineName = (string)e.Argument;
            Type type = Type.GetType("Algorithm_Visualizer." + sortEngineName);
            var constructors = type.GetConstructors();

            ISortable sortable = (ISortable)constructors[0].Invoke(new object[] {arrayToSort, graphics, panel1.Height});
            while (!sortable.IsSorted())
            {
                sortable.NextStep();
            }
        }
    }
}
