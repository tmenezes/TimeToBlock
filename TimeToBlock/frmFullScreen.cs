using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeToBlock
{
    public partial class frmFullScreen : Form
    {
        public static bool BloqueioInterrompido { get; private set; }

        DateTime dataDoBloqueio;
        int duracaoDoBloqueio;
        int contadorEsc = 0;

        private frmFullScreen()
        {
            InitializeComponent();
        }
        public static void Bloquear(int duracaoDoBloqueio)
        {
            var frmFullScreen = new frmFullScreen();
            BloqueioInterrompido = false;

            frmFullScreen.dataDoBloqueio = DateTime.Now;
            frmFullScreen.duracaoDoBloqueio = duracaoDoBloqueio;
            frmFullScreen.timerDesbloqueio.Enabled = true;

            frmFullScreen.ShowDialog();
        }

        private void timerDesbloqueio_Tick(object sender, EventArgs e)
        {
            bool desbloquear = DateTime.Now > dataDoBloqueio.AddMinutes(duracaoDoBloqueio);
            if (desbloquear)
            {
                this.FecharForm();
            }
        }
        private void frmFullScreen_KeyDown(object sender, KeyEventArgs e)
        {
            bool esc = e.KeyCode == Keys.Escape;
            if (esc)
                this.contadorEsc++;

            if (this.contadorEsc >= 3)
            {
                BloqueioInterrompido = true;
                this.FecharForm();
            }
        }

        private void FecharForm()
        {
            this.timerDesbloqueio.Enabled = false;
            this.Close();
            this.Dispose();
        }
    }
}
