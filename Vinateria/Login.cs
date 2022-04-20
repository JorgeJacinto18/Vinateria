using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Vinateria
{ 
   
    public partial class Login : Form
    {

        
        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionDB conectar = new ConexionDB();
            NpgsqlConnection con = conectar.conexion();

            string sentencia1 = "SELECT IDEmp FROM Empleados WHERE Usuario = '"+ textBox1.Text +"' and Contraseña = '"+
            textBox2.Text +"';";

            NpgsqlCommand cmd = new NpgsqlCommand(sentencia1, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                int id = reader.GetInt32(0);
                MessageBox.Show("Bienvenido");

                
                Form formulario = new Ventas(id);
                formulario.Show();
                con.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error, usuario o contraseña incorrectos");
            }

            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    } 
     
}
