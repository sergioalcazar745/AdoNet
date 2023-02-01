namespace AdoNet
{
    partial class Form12EmpleadosOficios
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOficios = new System.Windows.Forms.ComboBox();
            this.lstviewEmpleados = new System.Windows.Forms.ListView();
            this.columnApellido = new System.Windows.Forms.ColumnHeader();
            this.columnOficio = new System.Windows.Forms.ColumnHeader();
            this.columnSalario = new System.Windows.Forms.ColumnHeader();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnIncrementar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIncremento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(46, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oficios";
            // 
            // cmbOficios
            // 
            this.cmbOficios.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbOficios.FormattingEnabled = true;
            this.cmbOficios.Location = new System.Drawing.Point(46, 99);
            this.cmbOficios.Name = "cmbOficios";
            this.cmbOficios.Size = new System.Drawing.Size(178, 33);
            this.cmbOficios.TabIndex = 1;
            this.cmbOficios.SelectedIndexChanged += new System.EventHandler(this.cmbOficios_SelectedIndexChanged);
            // 
            // lstviewEmpleados
            // 
            this.lstviewEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnApellido,
            this.columnOficio,
            this.columnSalario});
            this.lstviewEmpleados.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstviewEmpleados.FullRowSelect = true;
            this.lstviewEmpleados.Location = new System.Drawing.Point(46, 175);
            this.lstviewEmpleados.Name = "lstviewEmpleados";
            this.lstviewEmpleados.Size = new System.Drawing.Size(576, 280);
            this.lstviewEmpleados.TabIndex = 2;
            this.lstviewEmpleados.UseCompatibleStateImageBehavior = false;
            this.lstviewEmpleados.View = System.Windows.Forms.View.Details;
            // 
            // columnApellido
            // 
            this.columnApellido.Text = "Apellido";
            this.columnApellido.Width = 150;
            // 
            // columnOficio
            // 
            this.columnOficio.DisplayIndex = 2;
            this.columnOficio.Text = "Oficio";
            this.columnOficio.Width = 150;
            // 
            // columnSalario
            // 
            this.columnSalario.DisplayIndex = 1;
            this.columnSalario.Text = "Salario";
            this.columnSalario.Width = 150;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(264, 90);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(163, 48);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnIncrementar
            // 
            this.btnIncrementar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIncrementar.ForeColor = System.Drawing.Color.Black;
            this.btnIncrementar.Location = new System.Drawing.Point(462, 95);
            this.btnIncrementar.Name = "btnIncrementar";
            this.btnIncrementar.Size = new System.Drawing.Size(160, 39);
            this.btnIncrementar.TabIndex = 4;
            this.btnIncrementar.Text = "Incrementar";
            this.btnIncrementar.UseVisualStyleBackColor = true;
            this.btnIncrementar.Click += new System.EventHandler(this.btnIncrementar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(462, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Incremento";
            // 
            // txtIncremento
            // 
            this.txtIncremento.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIncremento.Location = new System.Drawing.Point(462, 49);
            this.txtIncremento.Name = "txtIncremento";
            this.txtIncremento.Size = new System.Drawing.Size(160, 33);
            this.txtIncremento.TabIndex = 6;
            // 
            // Form12EmpleadosOficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 496);
            this.Controls.Add(this.txtIncremento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIncrementar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lstviewEmpleados);
            this.Controls.Add(this.cmbOficios);
            this.Controls.Add(this.label1);
            this.Name = "Form12EmpleadosOficios";
            this.Text = "Form12EmpleadosOficios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbOficios;
        private ListView lstviewEmpleados;
        private Button btnEliminar;
        private Button btnIncrementar;
        private Label label2;
        private TextBox txtIncremento;
        private ColumnHeader columnApellido;
        private ColumnHeader columnOficio;
        private ColumnHeader columnSalario;
    }
}