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

#region
//ALTER PROCEDURE SP_EMPLEADOS_DEPARTAMENTO
//(@NOMBRE NVARCHAR(50),
//@SUMA INT OUT,
//@MEDIA INT OUT,
//@PERSONAS INT OUT)
//AS
//	SELECT * FROM EMP INNER JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO WHERE DNOMBRE = @NOMBRE
//	SELECT @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO), @PERSONAS = COUNT(EMP_NO) FROM EMP
//	INNER JOIN DEPT
//	ON EMP.DEPT_NO = DEPT.DEPT_NO WHERE DNOMBRE = @NOMBRE
//GO
#endregion

namespace AdoNet
{
    public partial class Form10ParametrosSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form10ParametrosSalida()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartametos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmd = (ComboBox)sender;
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_DEPARTAMENTO";

            SqlParameter paraid = new SqlParameter("@NOMBRE", cmd.SelectedItem.ToString());
            this.com.Parameters.Add(paraid);
            SqlParameter parasuma = new SqlParameter("@SUMA", 0);
            parasuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(parasuma);
            SqlParameter paramedia = new SqlParameter("@MEDIA", 0);
            paramedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(paramedia);
            SqlParameter parapersonas = new SqlParameter("@PERSONAS", 0);
            parapersonas.Direction = ParameterDirection.Output;

            this.com.Parameters.Add(parapersonas);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);                
            }
            this.cn.Close();
            this.reader.Close();

            this.txtSuma.Text = parasuma.Value.ToString();
            this.txtMedia.Text = paramedia.Value.ToString();
            this.txtPersonas.Text = parapersonas.Value.ToString();

            this.com.Parameters.Clear();
        }

        private void LoadDepartametos()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DEPARTAMENTOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                this.cmbDepartamentos.Items.Add(nombre);
            }
            this.cn.Close();
            this.reader.Close();
        }
    }
}
