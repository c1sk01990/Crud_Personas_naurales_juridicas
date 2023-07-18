using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Personas_naurales_juridicas
{
    public class Clientes
    {
        // atributos de clase con sus modificadores de acceso get y set
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Correo { get; set; }
        public int IdCategoría { get; set; }


        // constructor de la clase
        public Clientes(int cedula, string nombre, string dirección, string correo, int idCategoría)
        {
            Cedula = cedula;
            Nombre = nombre;
            Dirección = dirección;
            Correo = correo;
            IdCategoría = idCategoría;
        }
    }
}
