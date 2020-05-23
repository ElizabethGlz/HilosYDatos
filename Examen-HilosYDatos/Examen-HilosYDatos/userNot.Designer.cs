namespace Examen_HilosYDatos
{
    partial class userNot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCerrar = new System.Windows.Forms.Panel();
            this.pctBCerrar = new System.Windows.Forms.PictureBox();
            this.Lista = new System.Windows.Forms.ListBox();
            this.pnlMostrar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCerrar
            // 
            this.pnlCerrar.BackColor = System.Drawing.Color.Silver;
            this.pnlCerrar.Controls.Add(this.label1);
            this.pnlCerrar.Controls.Add(this.pctBCerrar);
            this.pnlCerrar.Location = new System.Drawing.Point(1, 3);
            this.pnlCerrar.Name = "pnlCerrar";
            this.pnlCerrar.Size = new System.Drawing.Size(195, 26);
            this.pnlCerrar.TabIndex = 1;
            this.pnlCerrar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCerrar_Paint);
            // 
            // pctBCerrar
            // 
            this.pctBCerrar.BackgroundImage = global::Examen_HilosYDatos.Properties.Resources._17_128;
            this.pctBCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBCerrar.Location = new System.Drawing.Point(161, 1);
            this.pctBCerrar.Name = "pctBCerrar";
            this.pctBCerrar.Size = new System.Drawing.Size(34, 25);
            this.pctBCerrar.TabIndex = 0;
            this.pctBCerrar.TabStop = false;
            this.pctBCerrar.Click += new System.EventHandler(this.pctBCerrar_Click);
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(1, 30);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(195, 69);
            this.Lista.TabIndex = 0;
            // 
            // pnlMostrar
            // 
            this.pnlMostrar.Location = new System.Drawing.Point(-2, 16);
            this.pnlMostrar.Name = "pnlMostrar";
            this.pnlMostrar.Size = new System.Drawing.Size(199, 83);
            this.pnlMostrar.TabIndex = 1;
            this.pnlMostrar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMostrar_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Productos Agotados";
            // 
            // userNot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCerrar);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.pnlMostrar);
            this.Name = "userNot";
            this.Size = new System.Drawing.Size(199, 103);
            this.Load += new System.EventHandler(this.userNot_Load);
            this.pnlCerrar.ResumeLayout(false);
            this.pnlCerrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCerrar;
        private System.Windows.Forms.PictureBox pctBCerrar;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.Panel pnlMostrar;
        private System.Windows.Forms.Label label1;
    }
}
