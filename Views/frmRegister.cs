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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
        }

        bool clicado = false;

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

            comboCargo.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Caso campos vazios
            if(comboCargo.SelectedIndex == 0 || textName.Text == "" || textSenha.Text == "" || textSenhaConfirm.Text == "")
            {
                MessageBox.Show("Campos vazios na sessão: Acesso", "Sistema de cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if(textName.Text == "" || maskedCel.Text == "" || maskedCEP.Text == "" || maskedCPF.Text == "")
            {
                MessageBox.Show("Campos vazios na sessão: Informações", "Sistema de cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //tb_Cargos
            IDictionary<int, string> cargo = new Dictionary<int, string>()
            {
                {0, Convert.ToString(comboCargo.Items[0])},
                {1, Convert.ToString(comboCargo.Items[1])},
                {2, Convert.ToString(comboCargo.Items[2])},
                {3, Convert.ToString(comboCargo.Items[3])}
            };

            
            if(textSenha.Text == textSenhaConfirm.Text)
            {
                //tb_Info
                InfosDTO infosDTO = new InfosDTO();
                infosDTO.nm_Completo = textName.Text;
                infosDTO.ds_Endereco = textEndereco.Text;
                infosDTO.nm_Numero = textNumero.Text;
                infosDTO.ds_Cel = maskedCel.Text;
                infosDTO.ds_Cpf = maskedCPF.Text;
                infosDTO.ds_Cep = maskedCEP.Text;
                infosDTO.ds_Formacao = textFormacao.Text;
                infosDTO.dt_Aniv = dateTimePicker1.Value;
                infosDTO.dt_UpdateOn = DateTime.Now;

                PimDatabase p = new PimDatabase();
                var resultado = p.SaveInfo(infosDTO);

                //tb_Usuarios
                UsuariosDTO usuariosDTO = new UsuariosDTO();
                usuariosDTO.nm_Usuarios = textUser.Text;
                usuariosDTO.ds_Senhas = textSenha.Text;
                    usuariosDTO.id_Cargo = Convert.ToInt32(cargo.Keys);
                usuariosDTO.id_Info = resultado;
                usuariosDTO.dt_LastedOn = DateTime.Now;
                usuariosDTO.dt_UpdatedOn = DateTime.Now;
                usuariosDTO.dt_CreatedOn = DateTime.Now;

                p.SaveUsuarios(usuariosDTO);

                MessageBox.Show("Funcionario cadastrado com sucesso!", "Sistema de cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("As senhas não conferem!", "Sistema de cadastro - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {           

            if (clicado == false)
            {
                textSenha.PasswordChar = '*';
                clicado = true;
            }
            else
            {
                textSenha.PasswordChar = default;
                clicado = default;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (clicado == false)
            {
                textSenha.PasswordChar = '*';
                clicado = true;
            }
            else
            {
                textSenha.PasswordChar = default;
                clicado = default;
            }
        }
    }
}
