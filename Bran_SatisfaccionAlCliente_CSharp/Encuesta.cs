using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//tuve que aplicar la referencia, de lo contrario no reconocia el enum servicios
using static Bran_SatisfaccionAlCliente_CSharp.servicio;

namespace Bran_SatisfaccionAlCliente_CSharp
{
    //aqui me observo de que no he dado uso de los objetos asi que decidi crear una clase Encuesta para almacenar los datos de la encuesta
    public class Encuesta
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public servicios Servicio { get; set; }
        public double Promedio { get; set; }
        public string Comentario { get; set; }
    }
}
