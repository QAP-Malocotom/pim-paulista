using pim_paulista.Database;
using pim_paulista.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pim_paulista.Views
{
    public partial class frmMenu : Form
    {
        public frmMenu(List<UsuariosDTO> usuarios)
        {
            InitializeComponent();
            ArredondaCantosdoForm();

            PimDatabase p = new PimDatabase();
            List<CargosDTO> consultarCargo = p.GetRole(usuarios.First().id_Cargo);
            List<InfosDTO> consultarInfo = p.GetInfo(usuarios.First().id_Info);

            textUser.Text = consultarInfo.First().nm_Completo;
            textCargo.Text = consultarCargo.First().ds_Cargo;
            textLastedOn.Text = Convert.ToString(DateTime.Now);
        }

        public void ArredondaCantosdoForm()
        {

            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, this.Size.Width, this.Size.Height));

            //Arredondar canto superior esquerdo        
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

            //Arredondar canto superior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(this.Width - 24, 1, 24, 26, 270, 90);

            //Arredondar canto inferior esquerdo
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, this.Height - 10, 10, 10));
            PastaGrafica.AddPie(1, this.Height - 20, 20, 20, 90, 90);

            //Arredondar canto inferior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, this.Height - 13, 13, 13));
            PastaGrafica.AddPie(this.Width - 24, this.Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            this.Region = new Region(PastaGrafica);
        }

        private void gerarBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void funcionarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void carroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSeguroCarro frm = new frmSeguroCarro();
            frm.ShowDialog();
        }
    }
}
