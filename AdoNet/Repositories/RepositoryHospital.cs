using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Models;
using System.Data.SqlClient;
using System.Data;
using AdoNet.Helpers;

namespace AdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            this.cn = new SqlConnection(HelperConfiguration.GetConnectionString("SqlHospital"));
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public List<string> GetHospitales ()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";
            List<string> hospitales = new List<string>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                hospitales.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public DatosHospital GetDatosHospital(string nombre)
        {
            SqlParameter paranombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(paranombre);
            SqlParameter parasuma = new SqlParameter("@SUMA", 0);
            this.com.Parameters.Add(parasuma);
            parasuma.Direction = ParameterDirection.Output;
            SqlParameter paramedia = new SqlParameter("@MEDIA", 0);
            this.com.Parameters.Add(paramedia);
            paramedia.Direction = ParameterDirection.Output;
            SqlParameter parapersonas = new SqlParameter("@PERSONAS", 0);
            parapersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(parapersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_HOSPITAL";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<EmpleadoHospital> empleados = new List<EmpleadoHospital>();
            while (this.reader.Read())
            {
                int idempleado = int.Parse(this.reader["IDEMPLEADO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                EmpleadoHospital empleado = new EmpleadoHospital();
                empleado.IdEmpleado = idempleado;
                empleado.Apellido = apellido;
                empleado.Salario = salario;
                empleados.Add(empleado);
            }
            this.reader.Close();
            DatosHospital datos = new DatosHospital();
            datos.Empleados = empleados;
            datos.SumaSalario = int.Parse(parasuma.Value.ToString());
            datos.MediaSalario = int.Parse(paramedia.Value.ToString());
            datos.Personas = int.Parse(parapersonas.Value.ToString());
            this.cn.Close();
            this.com.Parameters.Clear();
            return datos;
        }
    }
}
