
namespace proyecto2_DiegoUmana
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.blCedula = new System.Windows.Forms.Label();
            this.btnFoto = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(121, 226);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(180, 20);
            this.txtCedula.TabIndex = 0;
            // 
            // blCedula
            // 
            this.blCedula.AutoSize = true;
            this.blCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blCedula.Location = new System.Drawing.Point(147, 188);
            this.blCedula.Name = "blCedula";
            this.blCedula.Size = new System.Drawing.Size(144, 24);
            this.blCedula.TabIndex = 1;
            this.blCedula.Text = "Digite su cedula";
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(171, 269);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(75, 23);
            this.btnFoto.TabIndex = 2;
            this.btnFoto.Text = "button1";
            this.btnFoto.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(155, 47);
            this.lblHora.MinimumSize = new System.Drawing.Size(100, 50);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(100, 50);
            this.lblHora.TabIndex = 4;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 428);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.blCedula);
            this.Controls.Add(this.txtCedula);
            this.Name = "frmPrincipal";
            this.Text = "Entradas y Salidas";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label blCedula;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHora;
    }
}

