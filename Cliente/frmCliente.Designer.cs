
namespace Cliente
{
    partial class frmCliente
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.rchtCliente = new System.Windows.Forms.RichTextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.imgCarta = new System.Windows.Forms.PictureBox();
            this.btnRepartir = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.lbPalo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgCarta)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rchtCliente
            // 
            this.rchtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.rchtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchtCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.rchtCliente.Font = new System.Drawing.Font("Komika Axis", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchtCliente.ForeColor = System.Drawing.Color.AliceBlue;
            this.rchtCliente.Location = new System.Drawing.Point(29, 107);
            this.rchtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.rchtCliente.Name = "rchtCliente";
            this.rchtCliente.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rchtCliente.Size = new System.Drawing.Size(461, 541);
            this.rchtCliente.TabIndex = 0;
            this.rchtCliente.Text = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.Font = new System.Drawing.Font("ONE PIECE", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCliente.Location = new System.Drawing.Point(50, 14);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(215, 89);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
            // 
            // imgCarta
            // 
            this.imgCarta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCarta.Location = new System.Drawing.Point(28, 26);
            this.imgCarta.Name = "imgCarta";
            this.imgCarta.Size = new System.Drawing.Size(359, 484);
            this.imgCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCarta.TabIndex = 2;
            this.imgCarta.TabStop = false;
            // 
            // btnRepartir
            // 
            this.btnRepartir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(204)))), ((int)(((byte)(101)))));
            this.btnRepartir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRepartir.FlatAppearance.BorderSize = 3;
            this.btnRepartir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnRepartir.Font = new System.Drawing.Font("Komika Axis", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepartir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(38)))), ((int)(((byte)(154)))));
            this.btnRepartir.Location = new System.Drawing.Point(23, 41);
            this.btnRepartir.Name = "btnRepartir";
            this.btnRepartir.Size = new System.Drawing.Size(199, 76);
            this.btnRepartir.TabIndex = 3;
            this.btnRepartir.Text = "Repartir";
            this.btnRepartir.UseVisualStyleBackColor = false;
            this.btnRepartir.Click += new System.EventHandler(this.btnRepartir_Click);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Komika Axis", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblValor.Location = new System.Drawing.Point(173, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(0, 84);
            this.lblValor.TabIndex = 4;
            // 
            // lbPalo
            // 
            this.lbPalo.AutoSize = true;
            this.lbPalo.Font = new System.Drawing.Font("ONE PIECE", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPalo.ForeColor = System.Drawing.Color.Yellow;
            this.lbPalo.Location = new System.Drawing.Point(562, 686);
            this.lbPalo.Name = "lbPalo";
            this.lbPalo.Size = new System.Drawing.Size(0, 84);
            this.lbPalo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3645, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(202)))), ((int)(((byte)(78)))));
            this.btnReset.Font = new System.Drawing.Font("Komika Axis", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Navy;
            this.btnReset.Location = new System.Drawing.Point(23, 391);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(199, 86);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "RESTART";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.imgCarta);
            this.panel1.Location = new System.Drawing.Point(565, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 536);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ONE PIECE", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 48);
            this.label1.TabIndex = 10;
            this.label1.Text = "PUNTAJE:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(81)))), ((int)(((byte)(204)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblValor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1046, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 72);
            this.panel2.TabIndex = 11;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(43)))), ((int)(((byte)(27)))));
            this.btnStop.Font = new System.Drawing.Font("Komika Axis", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnStop.Location = new System.Drawing.Point(23, 139);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(199, 86);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(95)))));
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Controls.Add(this.btnRepartir);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Location = new System.Drawing.Point(1059, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(248, 503);
            this.panel3.TabIndex = 13;
            // 
            // frmCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(76)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1359, 757);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rchtCliente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbPalo);
            this.Controls.Add(this.lblCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BLACK JACK GAME";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCarta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.PictureBox imgCarta;
        private System.Windows.Forms.Button btnRepartir;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lbPalo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel3;
    }
}

