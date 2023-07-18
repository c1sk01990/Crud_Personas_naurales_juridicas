using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Crud_Personas_naurales_juridicas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            conexionDB.Conectar();
            MessageBox.Show("conexion establecida...");
            conexionDB conexion=new conexionDB();
            DataTable registro = conexion.ver_Registros();
            dg.DataSource= registro;


            dg.CellFormatting += dg_CellFormatting;




        }
        // metodo para cambiar de color dependiendo la persona si es juridica o natural
        private void dg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs c)
        {
            if (c.RowIndex >= 0 && c.ColumnIndex == dg.Columns["id_categoría"].Index)
            {
                if (c.Value != null)
                {
                    DataGridViewRow fila = dg.Rows[c.RowIndex];
                    string valorCategoria = c.Value.ToString();

                    if (valorCategoria == "1") // Persona Natural
                    {
                        fila.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (valorCategoria == "2") // Persona Jurídica
                    {
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        //  codigo para registrar datos aplicando un objeto de clase clientes
        private void button1_Click(object sender, EventArgs e)
        {
            int cedula = int.Parse(txt_cedula.Text);
            string nombre = txt_nombre.Text;
            string direccion = txt_direccion.Text;
            string correo = txt_correo.Text;
            int idCategoria = int.Parse(cbo_categoria.Text);

            Clientes clientes = new Clientes(cedula, nombre, direccion, correo, idCategoria);

            conexionDB conexion = new conexionDB();

            conexion.Registrar_Datos(clientes);
            conexion.ver_Registros();



        }
        // ver datos 
        private void btn_ver_Click(object sender, EventArgs e)
        {
            conexionDB conexion=new conexionDB();
            DataTable registro = conexion.consultas();
            dg.DataSource = registro;
        }
        // actualizar datos
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            int cedula = int.Parse(txt_cedula.Text);
            string nombre = txt_nombre.Text;
            string direccion = txt_direccion.Text;
            string correo = txt_correo.Text;
            int idCategoria = int.Parse(cbo_categoria.Text);

            // clase cliente con el objeto cliente ejecutando el contructor de clase
            Clientes clientes = new Clientes(cedula, nombre, direccion, correo, idCategoria);

            conexionDB conexion = new conexionDB();
            conexion.Actualizar_Datos(clientes);
            conexion.ver_Registros();
        }
        // Boton para eliminar datos que contiene los atributos de la clase clientes
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int cedula = int.Parse(txt_cedula.Text);
            string nombre = txt_nombre.Text;
            string direccion = txt_direccion.Text;
            string correo = txt_correo.Text;
            int idCategoria = int.Parse(cbo_categoria.Text);



            Clientes clientes = new Clientes(cedula, nombre, direccion, correo, idCategoria);

            conexionDB conexion = new conexionDB();
            conexion.Eliminar_Datos(clientes);
            conexion.ver_Registros();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_cedula.Clear();
            txt_nombre.Clear();
             txt_direccion.Clear();
            txt_correo.Clear();
            cbo_categoria.Items.Clear();
            cbo_categoria.Text="";
        }
    }
}
