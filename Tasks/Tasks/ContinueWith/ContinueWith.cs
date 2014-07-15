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
    public partial class ContinueWith : Form
    {
        private Worker _worker;
        private string _threadResult;

        public ContinueWith()
        {
            InitializeComponent();
            _worker = new Worker();
        }

        private void OnDowORK(object sender, EventArgs e)
        {
            var t = new Task(() =>
            {
                Thread.Sleep(2000);
                _threadResult = "Result";
            });

            
            t.ContinueWith((antecedent) =>
            {
                //this task will be executed after above task
                listBox1.Items.Add(_threadResult);
            },TaskScheduler.FromCurrentSynchronizationContext());//run on ui

            t.Start();
        }
    }
}
