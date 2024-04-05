using System;
using System.Windows.Forms;

namespace Navigation
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
