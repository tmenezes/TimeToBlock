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
        bool telaBloqueada = false;

        // contrutor
        public frmPrincipal()
        {
            InitializeComponent();
            timerBloqueio.Enabled = true;

            var userIdleDetect = UserIdleDetect.StartDetection(10000); //10 segundos
            userIdleDetect.UserIdleDetected += userIdleDetect_UserIdleDetected;
            userIdleDetect.UserIdleInterrupted += userIdleDetect_UserIdleInterrupted;
        }

        // botoes form
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

                Pausar();
            }
            else if (estado.Equals("PLAY"))
            {
                this.btnPausePlay.Tag = "PAUSE";
                this.btnPausePlay.Text = "Pause";

                RetornarDoPausa();
            }
        }

        // evento timer bloqueio
        private void timerBloqueio_Tick(object sender, EventArgs e)
        {
            bool bloquear = DateTime.Now > dataDoUltimoBloqueio.AddMinutes(intervaloDeBloqueio);
            if (bloquear)
            {
                telaBloqueada = true;
                timerBloqueio.Enabled = false;
                frmFullScreen.Bloquear(duracaoDeBloqueio);

                dataDoUltimoBloqueio = DateTime.Now;
                timerBloqueio.Enabled = true;
                telaBloqueada = false;
            }
        }

        // idle detection
        void userIdleDetect_UserIdleDetected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                lblIdle.Text = "IDLE";

                bool pausado = this.btnPausePlay.Tag.Equals("PLAY");
                if (telaBloqueada || pausado)
                    return;

                Pausar();
            });
        }
        void userIdleDetect_UserIdleInterrupted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                lblIdle.Text = "NOT idle";

                bool pausado = this.btnPausePlay.Tag.Equals("PLAY");
                if (telaBloqueada || pausado)
                    return;

                RetornarDoPausa();
            });
        }

        private void Pausar()
        {
            this.dataDaPausa = DateTime.Now;
            this.timerBloqueio.Enabled = false;
        }
        private void RetornarDoPausa()
        {
            var tempoEmPausa = DateTime.Now - this.dataDaPausa;
            bool tempoPausadoMuitoLongo = tempoEmPausa.Minutes > (intervaloDeBloqueio / 2);
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
}
