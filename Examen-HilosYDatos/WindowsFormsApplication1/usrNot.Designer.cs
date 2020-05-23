namespace WindowsFormsApplication1
{
    partial class usrNot
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
            this.components = new System.ComponentModel.Container();
            this.pnlMostrar = new System.Windows.Forms.Panel();
            this.pnlCerrar = new System.Windows.Forms.Panel();
            this.pctBCerrar = new System.Windows.Forms.PictureBox();
            this.Lista = new System.Windows.Forms.ListBox();
            this.tmrDuracion = new System.Windows.Forms.Timer(this.components);
            this.pnlMostrar.SuspendLayout();
            this.pnlCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMostrar
            // 
            this.pnlMostrar.Controls.Add(this.pnlCerrar);
            this.pnlMostrar.Controls.Add(this.Lista);
            this.pnlMostrar.Location = new System.Drawing.Point(3, 3);
            this.pnlMostrar.Name = "pnlMostrar";
            this.pnlMostrar.Size = new System.Drawing.Size(258, 162);
            this.pnlMostrar.TabIndex = 0;
            // 
            // pnlCerrar
            // 
            this.pnlCerrar.BackColor = System.Drawing.Color.Silver;
            this.pnlCerrar.Controls.Add(this.pctBCerrar);
            this.pnlCerrar.Location = new System.Drawing.Point(3, 0);
            this.pnlCerrar.Name = "pnlCerrar";
            this.pnlCerrar.Size = new System.Drawing.Size(253, 26);
            this.pnlCerrar.TabIndex = 1;
            // 
            // pctBCerrar
            // 
            this.pctBCerrar.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._17_128;
            this.pctBCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBCerrar.Location = new System.Drawing.Point(220, 0);
            this.pctBCerrar.Name = "pctBCerrar";
            this.pctBCerrar.Size = new System.Drawing.Size(34, 25);
            this.pctBCerrar.TabIndex = 0;
            this.pctBCerrar.TabStop = false;
            this.pctBCerrar.Click += new System.EventHandler(this.pctBCerrar_Click);
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(3, 27);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(252, 121);
            this.Lista.TabIndex = 0;
            // 
            // tmrDuracion
            // 
            this.tmrDuracion.Interval = 1000;
            this.tmrDuracion.Tick += new System.EventHandler(this.tmrDuracion_Tick);
            // 
            // usrNot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMostrar);
            this.Name = "usrNot";
            this.Size = new System.Drawing.Size(262, 169);
            this.Load += new System.EventHandler(this.usrNot_Load);
            this.pnlMostrar.ResumeLayout(false);
            this.pnlCerrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctBCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMostrar;
        private System.Windows.Forms.Panel pnlCerrar;
        private System.Windows.Forms.PictureBox pctBCerrar;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.Timer tmrDuracion;
    }
}
