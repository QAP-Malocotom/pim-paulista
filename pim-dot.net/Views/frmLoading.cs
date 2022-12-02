using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_paulista.Views
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
            desaparece();
        }
        void desaparece()
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            this.Opacity = 1;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ativo = true;

            if (ativo){
                this.Opacity -= 0.001D;
            }

            if (this.Opacity == 0){
                ativo = false;
                timer1.Enabled = false;
            }
        }

    }
}
