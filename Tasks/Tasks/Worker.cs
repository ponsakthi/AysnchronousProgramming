using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    class Worker
    {

        public void DoWorkFor5Sec()
        {
            Thread.Sleep(5000);
        }

        public void UpdateListBoxAfter3Sec(ListBox listBox2, TextBox textBox1)
        {
            Thread.Sleep(3000);
            listBox2.Items.Add("Item added from Worker");
            textBox1.Text = "Writing from worker";
        }
    }
}
