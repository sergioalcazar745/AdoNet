using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class OficiosEmpleados
    {
        public OficiosEmpleados(List<string> oficiosempleados)
        {
            this.GetOficiosEmpleados = oficiosempleados;
        }
        public List<string> GetOficiosEmpleados { get; set; }
    }
}
