using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpSQL
{
    public partial class InputDialog : Form
    {
        public String input;

        public InputDialog(String text)
        {
            InitializeComponent();
            l_text.Text = text;
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            input = tb_input.Text;
            this.Close();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            input = null;
            this.Close();
        }
    }
}
