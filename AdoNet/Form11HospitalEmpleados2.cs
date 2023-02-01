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
    public partial class Form11HospitalEmpleados2 : Form
    {
        private RepositoryHospital repo;
        public Form11HospitalEmpleados2()
        {
            InitializeComponent();
            this.repo = new RepositoryHospital();
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            List<string> hospitales = this.repo.GetHospitales();
            foreach (string hospital in hospitales)
            {
                this.cmbHospitales.Items.Add(hospital);
            }
        }

        private void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbHospitales.SelectedIndex != -1)
            {
                string nombreHospital = this.cmbHospitales.SelectedItem.ToString();
                DatosHospital datos = this.repo.GetDatosHospital(nombreHospital);
                this.lstEmpleados.Items.Clear();
                foreach (EmpleadoHospital empleado in datos.Empleados)
                {
                    this.lstEmpleados.Items.Add(empleado.Apellido + " - " + empleado.Salario);
                }
                this.txtSuma.Text = datos.SumaSalario.ToString();
                this.txtMedia.Text = datos.MediaSalario.ToString();
                this.txtPersonas.Text = datos.Personas.ToString();
            }
        }
    }
}
