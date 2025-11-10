using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Joc
{
    public partial class AlegeForm : Form
    {
        private string name;
        public AlegeForm(string nume)
        {
            InitializeComponent();
            name = nume;
        }

        private void btnJoc_Click(object sender, EventArgs e)
        {
            if (rbSnake.Checked)
            {
                this.Visible = false;
                SnakeForm frm = new SnakeForm(name);
                frm.ShowDialog();
                Application.Exit();
            }
            else if (rbCercuri.Checked)
            {
                this.Visible = false;
                JocForm frm = new JocForm(name);
                frm.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Nu este ales niciun joc");
            }
        }
    }
}
