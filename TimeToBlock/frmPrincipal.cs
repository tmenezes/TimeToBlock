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
    public partial class frmPrincipal : Form
    {
        DateTime dataDaPausa = DateTime.Now;
        DateTime dataDoUltimoBloqueio = DateTime.Now;
        int intervaloDeBloqueio = 30;
        int duracaoDeBloqueio = 5;

        public frmPrincipal()
        {
            InitializeComponent();
            timerBloqueio.Enabled = true;
        }


        private void btnAplicar_Click(object sender, EventArgs e)
        {
            intervaloDeBloqueio = Convert.ToInt32(txtIntervaloBloqueio.Value);
            duracaoDeBloqueio = Convert.ToInt32(txtDuracaoBloqueio.Value);

            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            string estado = this.btnPausePlay.Tag.ToString();
            if (estado.Equals("PAUSE"))
            {
                this.btnPausePlay.Tag = "PLAY";
                this.btnPausePlay.Text = "Continuar";

                this.dataDaPausa = DateTime.Now;
                this.timerBloqueio.Enabled = false;
            }
            else if (estado.Equals("PLAY"))
            {
                this.btnPausePlay.Tag = "PAUSE";
                this.btnPausePlay.Text = "Pause";

                var tempoEmPausa = DateTime.Now - this.dataDaPausa;
                bool tempoPausadoMuitoLongo=tempoEmPausa.Minutes > (intervaloDeBloqueio / 2);
                if (tempoPausadoMuitoLongo)
                {
                    this.dataDoUltimoBloqueio = DateTime.Now;
                }
                else
                {
                    this.dataDoUltimoBloqueio = this.dataDoUltimoBloqueio.AddMinutes(tempoEmPausa.Minutes);
                }
                this.timerBloqueio.Enabled = true;
            }
        }


        private void timerBloqueio_Tick(object sender, EventArgs e)
        {
            bool bloquear = DateTime.Now > dataDoUltimoBloqueio.AddMinutes(intervaloDeBloqueio);
            if (bloquear)
            {
                timerBloqueio.Enabled = false;
                frmFullScreen.Bloquear(duracaoDeBloqueio);

                dataDoUltimoBloqueio = DateTime.Now;
                timerBloqueio.Enabled = true;
            }
        }
    }
}
