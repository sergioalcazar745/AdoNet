using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class DatosHospital
    {
        public List<EmpleadoHospital> Empleados { get; set; }
        public int SumaSalario { get; set; }
        public int MediaSalario { get; set; }
        public int Personas { get; set; }
    }
}
