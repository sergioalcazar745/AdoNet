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
//CREATE PROCEDURE SP_DEPARTAMENTOS
//AS
//	SELECT * FROM DEPT
//GO
//------------------------------
//CREATE PROCEDURE SP_INSERTAR_DEPARTAMENTO
//(@ID INT, @NOMBRE NVARCHAR(50), @LOC NVARCHAR(50))
//AS
//    --DECLARE @MAXIMOID INT
//	--SELECT @MAXIMOID = MAX(DEPT_NO) FROM DEPT
//	INSERT INTO DEPT VALUES(@ID, @NOMBRE, @LOC)
//GO
#endregion

namespace AdoNet
{
    public partial class Form09MensajesServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form09MensajesServidor()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.cn.InfoMessage += Cn_InfoMessage;
            this.LoadDepartamentos();
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensajes.Text = e.Message;
            string message = e.Message;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_INSERTAR_DEPARTAMENTO";
            SqlParameter paraid = new SqlParameter("@ID", int.Parse(this.txtId.Text));
            SqlParameter paranombre = new SqlParameter("@NOMBRE", this.txtNombre.Text);
            SqlParameter paraloc = new SqlParameter("@LOC", this.txtLocalidad.Text);
            this.com.Parameters.Add(paraid);
            this.com.Parameters.Add(paranombre);
            this.com.Parameters.Add(paraloc);
            this.cn.Open();
            int insertado = this.com.ExecuteNonQuery();
            if(insertado > 0)
            {
                this.txtId.Clear();
                this.txtNombre.Clear();
                this.txtLocalidad.Clear();
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            this.LoadDepartamentos();
        }

        private void LoadDepartamentos()
        {
            this.lstDepartamentos.Items.Clear();
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DEPARTAMENTOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string id = this.reader["DEPT_NO"].ToString();
                string nombre = this.reader["DNOMBRE"].ToString();
                string loc = this.reader["LOC"].ToString();
                this.lstDepartamentos.Items.Add(id.ToUpper() + " - " + nombre.ToUpper() + " - " + loc.ToUpper());
            }
            this.cn.Close();
            this.reader.Close();
        }
    }
}
