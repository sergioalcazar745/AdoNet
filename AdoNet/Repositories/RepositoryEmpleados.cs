using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdoNet.Models;
using AdoNet.Helpers;
using System.Data;

namespace AdoNet.Repositories
{
    public class RepositoryEmpleados
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryEmpleados()
        {
            this.cn = new SqlConnection(HelperConfiguration.GetConnectionString("SqlHospitalCasa"));
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<string> GetOficios()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_OFICIOS_EMPLEADOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> oficios = new List<string>();
            while (this.reader.Read())
            {
                string oficio = this.reader["OFICIO"].ToString();
                oficios.Add(oficio);
            }
            this.Close();
            return oficios;
        }

        public List<Empleado> GetEmpleados()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Empleado> empleados = this.readEmpleados(this.reader);
            this.Close();
            return empleados;
        }

        public List<Empleado> GetEmpleadosOficio(string nombre)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_OFICIOS";
            SqlParameter paraid = new SqlParameter("@OFICIO", nombre);
            this.com.Parameters.Add(paraid);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Empleado> empleados = this.readEmpleados(this.reader);
            this.Close();
            return empleados;
        }

        public int UpdateEmpleadosOficio(string nombre, int incremento)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_INCREMENTO_EMPLEADOS_OFICIO";
            SqlParameter paraid = new SqlParameter("@OFICIO", nombre);
            this.com.Parameters.Add(paraid);
            SqlParameter paraincremento = new SqlParameter("@INCREMENTO", incremento);
            this.com.Parameters.Add(paraincremento);
            this.cn.Open();
            int actualizados = this.com.ExecuteNonQuery();
            this.Close();
            return actualizados;
        }

        public int DeleteEmpleadosOficio(int id)
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DELETE_EMPLEADO";
            SqlParameter paraid = new SqlParameter("@ID", id);
            this.com.Parameters.Add(paraid);
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.Close();
            return eliminados;
        }

        private List<Empleado> readEmpleados(SqlDataReader reader)
        {
            List<Empleado> empleados = new List<Empleado>();
            while (reader.Read())
            {
                int dept_no = int.Parse(reader["EMP_NO"].ToString());
                string apellido = reader["APELLIDO"].ToString();
                string oficio = reader["OFICIO"].ToString();
                int salario = int.Parse(reader["SALARIO"].ToString());
                Empleado empleado = new Empleado(dept_no, apellido, oficio, salario);
                empleados.Add(empleado);
            }
            return empleados;
        }

        private void Close()
        {
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
        }
    }
}
