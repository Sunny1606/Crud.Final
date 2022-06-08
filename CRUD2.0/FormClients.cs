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


namespace CRUD2._0
{
    public partial class FormClients : Form
    {
        public FormClients()
        {
            InitializeComponent();
        }     
        public Clients ClienteSeleccion { get; set; }       
        private void buttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttSearch_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ClientsDAL.BuscaClientes(txtName.Text, txtLastName.Text);
        }
      
        private void buttAcept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32 (dataGridView1.CurrentRow.Cells[0].Value);
                ClienteSeleccion = ClientsDAL.ObtenerCliente(Id);
                this.Close();
            }
        }
    }
}
