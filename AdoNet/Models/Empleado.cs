using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class Empleado
    {
        public Empleado() { }
        public Empleado(int emp_no, string apellido, string oficio, int salario)
        {
            this.Emp_no = emp_no;
            this.Apellido = apellido;
            this.Oficio = oficio;
            this.Salario = salario;
        }
        public int Emp_no { get; set; }
        public string Apellido { get; set; }
        public string Oficio { get; set; }
        public int Salario { get; set; }
    }
}
