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

namespace AdoNet
{
    public partial class Form05DepartamentosEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form05DepartamentosEmpleados()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }

        private void btnModificarDatos_Click(object sender, EventArgs e)
        {
            string oficio = this.txtOficio.Text;
            string salario = this.txtSalario.Text;
            string apellido = this.lstEmpleados.SelectedItem.ToString();
            string sql = "UPDATE EMP SET OFICIO = @NEWOFICIO, SALARIO = @NEWSALARIO WHERE APELLIDO = @APELLIDO";
            SqlParameter paraNewOficio = new SqlParameter("@NEWOFICIO", oficio);
            SqlParameter paraNewSalario = new SqlParameter("@NEWSALARIO", salario);
            SqlParameter paraNewApellido = new SqlParameter("@APELLIDO", apellido);
            this.com.Parameters.Add(paraNewOficio);
            this.com.Parameters.Add(paraNewSalario);
            this.com.Parameters.Add(paraNewApellido);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int afectados = this.com.ExecuteNonQuery();
            if(afectados > 0)
            {
                this.txtOficio.Text = "";
                this.txtSalario.Text = "";
                this.lstEmpleados.SelectedIndex = -1;
                MessageBox.Show("Modificado correctamente");
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
        }

        private void LoadDepartamentos()
        {
            string sql = "SELECT DNOMBRE FROM DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                this.lstDepartamentos.Items.Add(nombre);
            }
            this.cn.Close();
            this.reader.Close();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstEmpleados.Items.Clear();
            this.txtOficio.Text = "";
            this.txtSalario.Text = "";
            string departamento = this.lstDepartamentos.SelectedItem.ToString();
            string sql = "SELECT APELLIDO FROM EMP LEFT JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO WHERE DEPT.DNOMBRE = @NOMBRE";
            SqlParameter paraNombre = new SqlParameter("@NOMBRE", departamento);
            this.com.Parameters.Add(paraNombre);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedIndex > 0)
            {
                string apellido = this.lstEmpleados.SelectedItem.ToString();
                string sql = "SELECT OFICIO, SALARIO FROM EMP WHERE APELLIDO = @APELLIDO";
                SqlParameter paraApellido = new SqlParameter("@APELLIDO", apellido);
                this.com.Parameters.Add(paraApellido);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                this.cn.Open();
                this.reader = this.com.ExecuteReader();
                while (this.reader.Read())
                {
                    string oficio = this.reader["OFICIO"].ToString();
                    string salario = this.reader["SALARIO"].ToString();
                    this.txtOficio.Text = oficio;
                    this.txtSalario.Text = salario;
                }
                this.cn.Close();
                this.reader.Close();
                this.com.Parameters.Clear();
            }
        }
    }
}
