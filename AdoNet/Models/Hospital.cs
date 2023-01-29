using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class Hospital
    {
        public Hospital() 
        {
        
        }

        #region PROPIEDADES
        public int Hopistal_Cod {get; set;}
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Num_Cama { get; set; }
        #endregion
    }
}
