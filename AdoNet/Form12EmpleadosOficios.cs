﻿using System;
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
    public partial class Form12EmpleadosOficios : Form
    {
        RepositoryEmpleados repo;
        List<Empleado> empleados;
        public Form12EmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryEmpleados();
            this.LoadOficios();
            this.LoadEmpleados();
        }

        private void LoadOficios()
        {
            this.cmbOficios.Items.Clear();
            List<string> oficios = this.repo.GetOficios();
            foreach (string oficio in oficios)
            {
                this.cmbOficios.Items.Add(oficio);
            }
        }

        private void LoadEmpleados()
        {
            this.lstviewEmpleados.Items.Clear();
            List<Empleado> empleados = this.repo.GetEmpleados();
            foreach (Empleado empleado in empleados)
            {
                int deptno = empleado.Emp_no;
                string apellido = empleado.Apellido;
                string oficioempleado = empleado.Oficio;
                string salario = empleado.Salario.ToString();
                ListViewItem item = new ListViewItem(apellido);
                item.SubItems.Add(oficioempleado);
                item.SubItems.Add(salario);
                item.Tag = deptno;
                this.lstviewEmpleados.Items.Add(item);
            }
        }

        private void cmbOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbOficios.SelectedIndex != -1)
            {
                this.LoadEmpleadosOficio();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)this.lstviewEmpleados.SelectedItems[0];
            int id = int.Parse(item.Tag.ToString());
            int eliminados = this.repo.DeleteEmpleadosOficio(id);
            if (eliminados > 0)
            {
                MessageBox.Show("Se ha eliminado corretamente");
                this.LoadEmpleados();
            }
        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            if(this.txtIncremento.Text.Length > 0 && this.cmbOficios.SelectedIndex != -1)
            {
                string oficio = cmbOficios.SelectedItem.ToString();
                int incremento = int.Parse(this.txtIncremento.Text);
                int actualizados = this.repo.UpdateEmpleadosOficio(oficio, incremento);
                this.LoadEmpleadosOficio();
            }
            else
            {
                MessageBox.Show("Selecciona oficio e incremento");
            }
        }

        private void LoadEmpleadosOficio()
        {
            this.lstviewEmpleados.Items.Clear();
            string oficio = this.cmbOficios.SelectedItem.ToString();
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            foreach (Empleado empleado in empleados)
            {
                int deptno = empleado.Emp_no;
                string apellido = empleado.Apellido;
                string oficioempleado = empleado.Oficio;
                string salario = empleado.Salario.ToString();
                ListViewItem item = new ListViewItem(apellido);
                item.SubItems.Add(oficioempleado);
                item.SubItems.Add(salario);
                item.Tag = deptno;
                this.lstviewEmpleados.Items.Add(item);
            }
        }
    }
}
