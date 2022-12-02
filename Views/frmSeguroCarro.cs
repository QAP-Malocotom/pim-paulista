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

namespace pim_paulista.Views
{
    public partial class frmSeguroCarro : Form
    {
        public frmSeguroCarro()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
            OpenView();
        }

        public void OpenView()
        {
            //Combo nacionalidade
            PimDatabase pimDatabase = new PimDatabase();
            List<NacionalidadeDTO> nacionalidadeDTOs = pimDatabase.LoadingNacionalidade();

            this.comboNacionalidade.DataSource = nacionalidadeDTOs;
            this.comboNacionalidade.DisplayMember = "ds_Nome";
            this.comboNacionalidade.ValueMember = "id_Pais";

            //Combo estado ciivil
            this.comboCivil.Items.Add("Solteiro(a)");
            this.comboCivil.Items.Add("Casado(a)");
            this.comboCivil.Items.Add("Separado(a)");
            this.comboCivil.Items.Add("Divorciado(a)");
            this.comboCivil.Items.Add("Viúvo(a)");

            //Combo genero
            this.comboGenero.Items.Add("Masculino");
            this.comboGenero.Items.Add("Feminino");

            //Combo aposetado
            this.comboAposentado.Items.Add("Sim");
            this.comboAposentado.Items.Add("Não");

            //Combo policamente exposto
            this.comboAposentado.Items.Add("Sim");
            this.comboAposentado.Items.Add("Não");
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkCPF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkRG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkPais_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
