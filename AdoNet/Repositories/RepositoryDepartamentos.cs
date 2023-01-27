using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AdoNet.Models;

namespace AdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            this.cn = new SqlConnection(@"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public int InsertDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@ID, @NOMBRE, @LOCALIDAD)";
            SqlParameter paraId = new SqlParameter("@ID", id);
            SqlParameter paraNombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter paraLocalidad = new SqlParameter("@LOCALIDAD", localidad);
            this.com.Parameters.Add(paraId);
            this.com.Parameters.Add(paraNombre);
            this.com.Parameters.Add(paraLocalidad);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int insertados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return insertados;
        }

        public int UpdateDepartamento(int id, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE = @NOMBRE, LOC = @LOCALIDAD WHERE DEPT_NO = @ID";
            SqlParameter paraId = new SqlParameter("@ID", id);
            SqlParameter paraNombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter paraLocalidad = new SqlParameter("@LOCALIDAD", localidad);
            this.com.Parameters.Add(paraId);
            this.com.Parameters.Add(paraNombre);
            this.com.Parameters.Add(paraLocalidad);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int modificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return modificados;
        }

        public int DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO=@ID";
            SqlParameter paraId = new SqlParameter("@ID", id);
            this.com.Parameters.Add(paraId);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return eliminados;
        }

        public List<Departamento> GetDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            string sql = "SELECT * FROM DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();
                departamentos.Add(departamento);
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            return departamentos;
        }

        public Departamento GetDepartamentoById(int id)
        {
            Departamento departamento = new Departamento();
            string sql = "SELECT * FROM DEPT WHERE DEPT_NO = @ID";
            SqlParameter paraId = new SqlParameter("@ID", id);
            this.com.Parameters.Add(paraId);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
            departamento.Nombre = this.reader["DNOMBRE"].ToString();
            departamento.Localidad = this.reader["LOC"].ToString();
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            return departamento;
        }


        private int GetMaxIdDepartamento()
        {
            string sql = "SELECT MAX(DEPT_NO) + 10 AS MAXIMO FROM DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int maximo = Convert.ToInt32(this.com.ExecuteScalar());
            this.cn.Close();
            return maximo;
        }
    }
}
