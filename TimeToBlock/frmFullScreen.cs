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
        DateTime dataDoBloqueio;
        int duracaoDoBloqueio;

        private frmFullScreen()
        {
            InitializeComponent();
        }

        public static void Bloquear(int duracaoDoBloqueio)
        {
            var frmFullScreen = new frmFullScreen();

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
                timerDesbloqueio.Enabled = false;
                this.Close();
                this.Dispose();
            }
        }
    }
}
