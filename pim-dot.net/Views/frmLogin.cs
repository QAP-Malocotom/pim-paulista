using pim_paulista.Database;
using pim_paulista.Models;
using pim_paulista.Views;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pim_paulista
{
    public partial class frmLogin : Form
    {        
        public frmLogin()
        {
            InitializeComponent();
            ArredondaCantosdoForm();

            panel1.Visible = false;
            labelTwo.Visible = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            int countLoading = 0;   
            panel1.Visible = true;
            labelTwo.Visible = true;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(23);

                    Invoke(new Action(() =>
                    {                       
                        countLoading++;
                        if (i == 0 || i == 25 || i == 50 || i == 75 || i >= 86)
                        {
                            labelTwo.Text = "Carregando banco...";
                            if (i == 25 || i == 50 || i == 75 || i >= 86)
                            {
                                labelTwo.Text = "Validando usuário...";
                                if (i == 50 || i == 75 || i >= 86)
                                {
                                    labelTwo.Text = "Validando senha...";
                                    if (i == 75 || i >= 85)
                                    {
                                        labelTwo.Text = "Carregando telas...";
                                        if (i >= 85)
                                        {
                                            labelTwo.Text = "⠀⠀⠀Entrando!";
                                            System.Threading.Thread.Sleep(23);
                                        }
                                    }
                                }
                            }
                        }
                    }));
                }
            });

            Task.Factory.StartNew(() =>
            {

                // Espera 2 segundos para iniciar o sistema
                System.Threading.Thread.Sleep(2700);

                Invoke(new Action(() =>
                {
                    if(countLoading >= 85)
                    {
                        //Caso usuario não exista ou digitou algo errado, esta quebrando na hr de atualizar.
                        PimDatabase p = new PimDatabase();
                        List<UsuariosDTO> consultar = p.GetAllUsers(textBox1.Text, textBox2.Text);
                        

                        if (consultar.Count > 0 )
                        {
                            panel1.Visible = false;
                            p.AttLastedOn(consultar.First().id_Usuarios);

                            MessageBox.Show("Logado!", "Sistema de acesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            var frmMenu = new frmMenu(consultar);
                            this.Hide();
                            frmMenu.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Usúario não existe!", "Sistema de acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                }));
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister r = new frmRegister();
            this.Hide();
            r.Show();
        }
    }
}