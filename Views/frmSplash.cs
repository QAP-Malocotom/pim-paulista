using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pim_paulista.Views
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();

            ProgressBarColor.SetState(progressBar1, 3);

            // Configurações para se tornar Splash Screen
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Coloca a Imagem que será a Splash Screen
            //BackgroundImage = Properties.Resources.loadingTwo;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(23);

                    Invoke(new Action(() =>
                    {
                        progressBar1.Increment(1);
                    
                        if (i == 0 || i == 25 || i == 50 || i == 75 || i == 100){
                            label1.Text = "Verificando banco de dados...";
                            if (i == 25 || i == 50 || i == 75 || i == 100){
                                label1.Text = "Acessando banco de dados...";
                                if (i == 50 || i == 75 || i == 100) {
                                    label1.Text = "Carregando modelos...";
                                    if (i == 75 || i == 100){
                                        label1.Text = "Atualizando dados...";
                                        if (i == 100)
                                        {
                                            label1.Text = "Concluido! Acessando Sistema.";
                                            System.Threading.Thread.Sleep(23);
                                        }
                                    }
                                }
                            }
                        }
                    }));
                }
            });


            // Inicia contagem para término da Splash Screen
            Task.Factory.StartNew(() =>
            {

                // Espera 2 segundos para iniciar o sistema
                System.Threading.Thread.Sleep(2700);

                Invoke(new Action(() =>
                {
                    // Abre a tela Inicial
                    frmLogin frm = new frmLogin();
                    frm.Show();
                    Hide();
                }));
            });
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
