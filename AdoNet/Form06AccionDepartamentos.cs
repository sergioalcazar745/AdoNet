using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Repositories;
using AdoNet.Models;

namespace AdoNet
{
    public partial class Form06AccionDepartamentos : Form
    {
        RepositoryDepartamentos repository;
        List<Departamento> departamentos;
        public Form06AccionDepartamentos()
        {
            InitializeComponent();
            this.repository = new RepositoryDepartamentos();
            this.LoadDepartamentos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.ResetTextBoxDefault();
            if (!this.IsNullOrEmptyTextBoxs())
            {
                int id = int.Parse(this.txtDeptNo.Text);
                string nombre = this.txtNombre.Text;
                string localidad = this.txtLocalidad.Text;
                int insertados = this.repository.InsertDepartamento(id, nombre, localidad);
                if(insertados > 0)
                {
                    this.LoadDepartamentos();
                    this.ClearTextBox();
                    MessageBox.Show("Departamento insertado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Escribe los valores");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.ResetTextBoxDefault();
            if (!this.IsNullOrEmptyTextBoxs())
            {
                int id = int.Parse(this.txtDeptNo.Text);
                string nombre = this.txtNombre.Text;
                string localidad = this.txtLocalidad.Text;
                int modificados = this.repository.UpdateDepartamento(id, nombre, localidad);
                if(modificados > 0)
                {
                    this.LoadDepartamentos();
                    this.ClearTextBox();
                    MessageBox.Show("Departamento modificado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Escribe los valores");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (this.lstDepartamentos.SelectedIndex != -1)
            {
                this.ResetTextBoxDefault();
                if (!this.IsNullOrEmptyTextBoxs())
                {
                    int id = int.Parse(this.txtDeptNo.Text);
                    int eliminados = this.repository.DeleteDepartamento(id);
                    if (eliminados > 0)
                    {
                        this.LoadDepartamentos();
                        this.ClearTextBox();
                        MessageBox.Show("Departamento eliminado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Escribe los valores");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un departamento");
            }
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            this.ResetTextBoxDefault();
            if (this.lstDepartamentos.SelectedIndex != -1)
            {
                int index = this.lstDepartamentos.SelectedIndex;
                Departamento dept = this.departamentos[index];
                this.txtDeptNo.Text = dept.IdDepartamento.ToString();
                this.txtNombre.Text = dept.Nombre;
                this.txtLocalidad.Text = dept.Localidad;
            }
        }

        private void LoadDepartamentos()
        {
            this.lstDepartamentos.Items.Clear();
            this.departamentos = this.repository.GetDepartamentos();
            foreach(Departamento departamento in departamentos)
            {
                this.lstDepartamentos.Items.Add(departamento.Nombre);
            }
        }

        private bool IsNullOrEmptyTextBoxs()
        {
            bool nullOrEmpty = false;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        nullOrEmpty = true;
                        txt.BackColor = Color.Red;
                    }
                }
            }
            return nullOrEmpty;
        }

        private void ResetTextBoxDefault()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.BackColor = Color.Empty;
                }
            }
        }

        private void ClearTextBox()
        {
            this.txtDeptNo.Clear();
            this.txtNombre.Clear();
            this.txtLocalidad.Clear();
        }

        private void txtDeptNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
