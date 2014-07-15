using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class Mainform : Form
    {
        private Worker _worker;

        public Mainform()
        {
            InitializeComponent();
            _worker = new Worker();
        }

        private void OnDoWorkSync(object sender, EventArgs e)
        {
            _worker.DoWorkFor5Sec();
            listBox2.Items.Add("Work Done!!!");
        }

        private void OnDoWorkAsync(object sender, EventArgs e)
        {
            Task t = new Task(() => _worker.DoWorkFor5Sec());
            t.Start();
            listBox2.Items.Add("Worker Started!!!");
        }

        private void OnThreadOnMain(object sender, EventArgs e)
        {
            Task t = new Task(() => _worker.UpdateListBoxAfter3Sec(listBox2,textBox1));
            t.Start();
            listBox2.Items.Add("Thread on Worker Started!!!");
        }

        private void OnThreadThatUsesUI(object sender, EventArgs e)
        {
            Task t = new Task(() => _worker.UpdateListBoxAfter3Sec(listBox2,textBox1));
            t.Start(TaskScheduler.FromCurrentSynchronizationContext()); //This will run on main thread and UI will not work
            listBox2.Items.Add("Thread on Main Started!!!");
        }

        
    }
}
