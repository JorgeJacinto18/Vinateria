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
    public partial class Ventas : Form
    {

        public int IDEmp;

        public Ventas(int id)
        {
            InitializeComponent();
            asignartexto(id);
            IDEmp = id;
        }

        //Asignar texto en label 2 y muestre ID
        public void asignartexto(int id)
        {
            label2.Text = id.ToString();
        }

        //Cerrar Sesion
        private void button1_Click(object sender, EventArgs e)
        {
            Form log = new Login();
            log.Show();
            this.Hide();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        } 

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string dato = "%" + textBox1.Text + "%";
            getBuscar(dato);
        }

        private void getBuscar(string dato)
        {
            dataGridView1.Rows.Clear();

            ConexionDB conectar = new ConexionDB();
            NpgsqlConnection con = conectar.conexion();

            string sentencia1 = "SELECT * from productos where nomprod like '" + dato + "' or tipo like '"+dato+"';";

            NpgsqlCommand cmd = new NpgsqlCommand(sentencia1, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()){
                dataGridView1.Rows.Add(
                reader.GetInt32(0), //id
                reader.GetString(1), //nombre
                reader.GetFloat(2), //precio mayoreo
                reader.GetFloat(3), //precio menudeo
                reader.GetInt32(4), //existencias
                reader.GetString(5), //tipo
                reader.GetFloat(6) //descuento
                );
            }

            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textBox2.TextLength == 0){
                MessageBox.Show("Error, no ha ingresado una cantidad valida");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error, solo numeros");
                e.Handled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
