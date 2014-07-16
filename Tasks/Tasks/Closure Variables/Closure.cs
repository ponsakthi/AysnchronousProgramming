using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.ContinueWith
{
    public partial class Closure : Form
    {

        public Closure()
        {
            InitializeComponent();
        }

        private void OnDowORK(object sender, EventArgs e)
        {
            int counter = 0;
            while (counter < 20)
            {
                int x = 100;
                var t = new Task(() =>
                {
                    x = x + 1;
                });
                t.Start();
                Thread.Sleep(1000);//If this line is there, then thread will execute first , therefore result will be 101
                //if commented, then UI thread will execute first and hence the result will be 100.
                //x though int, is passed by reference into the task.
                listBox1.Items.Add(x.ToString());
                counter++;
            }

            listBox1.Items.Add("Completed!!!");
        }
    }
}
