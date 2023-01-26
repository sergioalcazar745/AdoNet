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
    public partial class Form03EliminarEnfermero : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form03EliminarEnfermero()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadEnfermos();
        }

        private void LoadEnfermos()
        {
            string sql = "SELECT * FROM ENFERMO";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion + " - " + apellido);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int inscripcion = int.Parse(this.txtInscripcion.Text);
            //string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION = " + inscripcion;
            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION=@INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            //paminscripcion.ParameterName = "@INSCRIPCION";
            //paminscripcion.Value = inscripcion;
            //paminscripcion.DbType = DbType.Int32;
            //paminscripcion.SqlDbType = SqlDbType.Int;
            //NO ES NECESARIO A NO SER QUE DESEEAMOS CAMBIAR SU VALOR POR DEFECTO (Input)
            paminscripcion.Direction = ParameterDirection.Input;
            this.com.Parameters.Add(paminscripcion);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            MessageBox.Show("Enfermeros eliminados: " + eliminados);
            this.LoadEnfermos();
        }
    }
}
