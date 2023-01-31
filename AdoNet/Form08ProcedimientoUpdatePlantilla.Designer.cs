namespace AdoNet
{
    partial class Form08ProcedimientoUpdatePlantilla
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
            this.btnModificarSalarios = new System.Windows.Forms.Button();
            this.lstPlantilla = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHospitales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnModificarSalarios
            // 
            this.btnModificarSalarios.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarSalarios.Location = new System.Drawing.Point(328, 53);
            this.btnModificarSalarios.Name = "btnModificarSalarios";
            this.btnModificarSalarios.Size = new System.Drawing.Size(187, 47);
            this.btnModificarSalarios.TabIndex = 9;
            this.btnModificarSalarios.Text = "Modificar salarios";
            this.btnModificarSalarios.UseVisualStyleBackColor = true;
            this.btnModificarSalarios.Click += new System.EventHandler(this.btnModificarSalarios_Click);
            // 
            // lstPlantilla
            // 
            this.lstPlantilla.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstPlantilla.FormattingEnabled = true;
            this.lstPlantilla.ItemHeight = 25;
            this.lstPlantilla.Location = new System.Drawing.Point(54, 168);
            this.lstPlantilla.Name = "lstPlantilla";
            this.lstPlantilla.Size = new System.Drawing.Size(461, 229);
            this.lstPlantilla.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(54, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hospitales";
            // 
            // cbHospitales
            // 
            this.cbHospitales.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbHospitales.FormattingEnabled = true;
            this.cbHospitales.Location = new System.Drawing.Point(54, 65);
            this.cbHospitales.Name = "cbHospitales";
            this.cbHospitales.Size = new System.Drawing.Size(218, 33);
            this.cbHospitales.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hospitales";
            // 
            // Form08ProcedimientoUpdatePlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.btnModificarSalarios);
            this.Controls.Add(this.lstPlantilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbHospitales);
            this.Controls.Add(this.label1);
            this.Name = "Form08ProcedimientoUpdatePlantilla";
            this.Text = "Form08ProcedimientoUpdatePlantilla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnModificarSalarios;
        private ListBox lstPlantilla;
        private Label label2;
        private ComboBox cbHospitales;
        private Label label1;
    }
}