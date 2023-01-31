﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

#region PROCEDIMIENTOS
//ALTER PROCEDURE SP_EMPLEADOS_HOSPITAL
//(@NOMBRE NVARCHAR(50),
//@SUMA INT OUT,
//@MEDIA INT OUT,
//@PERSONAS INT OUT)
//AS
//    DECLARE @ID INT
//	SELECT @ID = HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = 'La paz'

//	SELECT APELLIDO, SALARIO FROM DOCTOR
//	WHERE HOSPITAL_COD = @ID
//	UNION
//	SELECT APELLIDO, SALARIO FROM PLANTILLA
//	WHERE HOSPITAL_COD = @ID

//	SELECT @PERSONAS = COUNT(APELLIDO), @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO) FROM(SELECT APELLIDO, SALARIO, HOSPITAL_COD FROM DOCTOR

//    UNION

//    SELECT APELLIDO, SALARIO, HOSPITAL_COD FROM PLANTILLA) QUERY
//    WHERE QUERY.HOSPITAL_COD = @ID
//GO

//DECLARE @PRUEBA INT
//EXEC SP_EMPLEADOS_HOSPITAL 'La paz', @PRUEBA OUTPUT, 0, 0
//PRINT 'SSSSS' + CAST(@PRUEBA AS NVARCHAR)
#endregion

namespace AdoNet
{
    public partial class Form11HospitalEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form11HospitalEmpleados()
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
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
            }
            this.cn.Close();
            this.reader.Close();
        }

        private void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmd = (ComboBox)sender;
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_HOSPITAL";
            SqlParameter paranombre = new SqlParameter("@NOMBRE", cmd.SelectedItem.ToString());
            this.com.Parameters.Add(paranombre);
            SqlParameter parasuma = new SqlParameter("@SUMA", 0);
            this.com.Parameters.Add(parasuma);
            SqlParameter paramedia = new SqlParameter("@MEDIA", 0);
            this.com.Parameters.Add(paramedia);
            SqlParameter parapersonas = new SqlParameter("@PERSONAS", 0);
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
    }
}
