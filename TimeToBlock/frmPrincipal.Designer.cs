namespace TimeToBlock
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtIntervaloBloqueio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuracaoBloqueio = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.timerBloqueio = new System.Windows.Forms.Timer(this.components);
            this.btnPausePlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervaloBloqueio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracaoBloqueio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(202, 149);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(93, 23);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "&Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtIntervaloBloqueio
            // 
            this.txtIntervaloBloqueio.Location = new System.Drawing.Point(148, 38);
            this.txtIntervaloBloqueio.Name = "txtIntervaloBloqueio";
            this.txtIntervaloBloqueio.Size = new System.Drawing.Size(75, 20);
            this.txtIntervaloBloqueio.TabIndex = 0;
            this.txtIntervaloBloqueio.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intervalo de Bloqueio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(em minutos)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(em minutos)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duração do Bloqueio";
            // 
            // txtDuracaoBloqueio
            // 
            this.txtDuracaoBloqueio.Location = new System.Drawing.Point(148, 73);
            this.txtDuracaoBloqueio.Name = "txtDuracaoBloqueio";
            this.txtDuracaoBloqueio.Size = new System.Drawing.Size(75, 20);
            this.txtDuracaoBloqueio.TabIndex = 1;
            this.txtDuracaoBloqueio.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(106, 149);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // timerBloqueio
            // 
            this.timerBloqueio.Interval = 5000;
            this.timerBloqueio.Tick += new System.EventHandler(this.timerBloqueio_Tick);
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.Location = new System.Drawing.Point(202, 120);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(93, 23);
            this.btnPausePlay.TabIndex = 7;
            this.btnPausePlay.Tag = "PAUSE";
            this.btnPausePlay.Text = "Pause";
            this.btnPausePlay.UseVisualStyleBackColor = true;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            // 
            // frmPrincipal
            // 
            this.AcceptButton = this.btnAplicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(314, 184);
            this.Controls.Add(this.btnPausePlay);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDuracaoBloqueio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntervaloBloqueio);
            this.Controls.Add(this.btnAplicar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMenezes - Time to Block - 10/2012";
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervaloBloqueio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracaoBloqueio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.NumericUpDown txtIntervaloBloqueio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtDuracaoBloqueio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Timer timerBloqueio;
        private System.Windows.Forms.Button btnPausePlay;
    }
}

