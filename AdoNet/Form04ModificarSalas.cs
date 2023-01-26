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
    public partial class Form04ModificarSalas : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form04ModificarSalas()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadSalas();
        }

        private void LoadSalas()
        {
            this.lstSalas.Items.Clear();
            string sql = "SELECT DISTINCT(NOMBRE) FROM SALA";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string sala = this.reader["NOMBRE"].ToString();
                this.lstSalas.Items.Add(sala);
            }
            this.cn.Close();
            this.reader.Close();
        }

        private void btnModificarSala_Click(object sender, EventArgs e)
        {
            if(this.lstSalas.SelectedIndex != -1)
            {
                int index = this.lstSalas.SelectedIndex;
                string sala = this.lstSalas.Items[index].ToString();
                string sql = "UPDATE SALA SET NOMBRE=@SETNOMBRE WHERE NOMBRE=@VALUENOMBRE";
                SqlParameter paraSetNombre = new SqlParameter("@SETNOMBRE", this.txtSala.Text);
                SqlParameter paraValueNombre = new SqlParameter("@VALUENOMBRE", sala);
                this.com.Parameters.Add(paraSetNombre);
                this.com.Parameters.Add(paraValueNombre);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                this.cn.Open();
                int modificados = this.com.ExecuteNonQuery();
                this.cn.Close();
                this.com.Parameters.Clear();
                this.LoadSalas();
                MessageBox.Show("Elementos modificados: " + modificados);
            }
            else
            {
                MessageBox.Show("Selecciona una sala");
            }
        }
    }
}
