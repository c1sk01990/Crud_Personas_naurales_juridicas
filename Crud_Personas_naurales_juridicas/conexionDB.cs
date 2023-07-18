using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Crud_Personas_naurales_juridicas
{
    internal class conexionDB
    {

        public static SqlConnection Conectar()
        {
            // cadena de conexion para conectar a la base de datos
            SqlConnection db = new SqlConnection("SERVER=C1SK0\\SQLEXPRESS;DATABASE=REGISTRO_CLIENTES;integrated security=true;");
            db.Open();
            return db;


        }

        // metodo que muestra los registros de la tablas en este caso la tabla clientes
        public DataTable ver_Registros()
        {


            conexionDB.Conectar();
            DataTable tabla=new DataTable();
            string consulta = "Select * from Clientes";
            SqlCommand comando= new SqlCommand(consulta,conexionDB.Conectar());
            SqlDataAdapter data=new SqlDataAdapter(comando);
            data.Fill(tabla);
            return tabla;


        }

        // metodo para registrar datos
        public void Registrar_Datos(Clientes clientes)
        {

            conexionDB.Conectar();
            string insertar = "Insert into Clientes(cedula,nombre,dirección,correo,id_categoría)Values(@cedula,@nombre,@direccion,@correo,@id_categoria)";
            SqlCommand comando= new SqlCommand(insertar,conexionDB.Conectar());
            comando.Parameters.AddWithValue("@cedula", clientes.Cedula);
            comando.Parameters.AddWithValue("@nombre", clientes.Nombre);
            comando.Parameters.AddWithValue("@direccion", clientes.Dirección);
            comando.Parameters.AddWithValue("@correo", clientes.Correo);
            comando.Parameters.AddWithValue("@id_categoria", clientes.IdCategoría);

            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Guardados...");
            
        }


        // metodo para ejecutar consultas adicionales 
        public DataTable consultas()
        {


            conexionDB.Conectar();
            DataTable tabla = new DataTable();
            string consulta = "SELECT clientes.*, cat.descripción AS categoria\r\nFROM Clientes clientes\r\nJOIN Categoria cat ON clientes.id_categoría = cat.id_categoría;";
            SqlCommand comando = new SqlCommand(consulta, conexionDB.Conectar());
            SqlDataAdapter data = new SqlDataAdapter(comando);
            data.Fill(tabla);
            return tabla;
        }

        // metodo actualizar datos
        public void Actualizar_Datos(Clientes clientes)
        {
            conexionDB.Conectar();

            string consulta_actuali = "UPDATE Clientes SET cedula=@cedula,nombre=@nombre,dirección=@dirección,correo=@correo,id_categoría=@id_categoría WHERE cedula=@cedula";
            SqlCommand comando = new SqlCommand(consulta_actuali, conexionDB.Conectar());
            comando.Parameters.AddWithValue("@cedula", clientes.Cedula);
            comando.Parameters.AddWithValue("@nombre", clientes.Nombre);
            comando.Parameters.AddWithValue("@dirección", clientes.Dirección); // Corregido el nombre de la variable
            comando.Parameters.AddWithValue("@correo", clientes.Correo);
            comando.Parameters.AddWithValue("@id_categoría", clientes.IdCategoría);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Actualizados");
        }
        // metodo eliminar datos
        public void Eliminar_Datos(Clientes clientes)
        {
            conexionDB.Conectar();
            string consulta_elimi = "DELETE FROM Clientes WHERE cedula=@cedula";
            SqlCommand comando = new SqlCommand(consulta_elimi,conexionDB.Conectar());
            comando.Parameters.AddWithValue("@cedula", clientes.Cedula);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Eliminados");
        }
    }
}
