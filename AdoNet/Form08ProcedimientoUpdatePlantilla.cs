using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

#region PROCEDIMIENTOS ALMACENADOS
#endregion

namespace AdoNet
{
    public partial class Form08ProcedimientoUpdatePlantilla : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form08ProcedimientoUpdatePlantilla()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cbHospitales.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cbHospitales.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnModificarSalarios_Click(object sender, EventArgs e)
        {
            string nombre = this.cbHospitales.SelectedItem.ToString();
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            //Opcional
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", 100000);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamincremento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_UPDATESALARIOSHOSPITAL";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstPlantilla.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string funcion = this.reader["FUNCION"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.lstPlantilla.Items.Add(apellido + ", " + funcion + ", " + salario);
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
        }
    }
}
