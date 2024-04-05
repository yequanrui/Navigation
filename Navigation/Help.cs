using System;
using System.Windows.Forms;

namespace Navigation
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}