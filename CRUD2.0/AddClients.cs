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
    public partial class AddClients : Form
    {

        public AddClients()
        {
            InitializeComponent();
        }
        public Clients ClienteActual { get; set; }  
        private void Save_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();

            clients.Name = txtName.Text;
            clients.LastName = txtLastName.Text;
            clients.Treatment = txtTreatment.Text;
            clients.Phone = txtPhone.Text;

            int result = ClientsDAL.Agregar(clients);

            if (result > 0 )
            {
                   MessageBox.Show("El contacto se guardo correctamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al guardar el contacto, verifique los datos ingresados");
            }
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttSearch_Click(object sender, EventArgs e)
        {
            FormClients add = new FormClients();
            add.ShowDialog();    
            if   (add.ClienteSeleccion != null)
            {
                ClienteActual = add.ClienteSeleccion;
                txtName.Text = add.ClienteSeleccion.Name;
                txtLastName.Text = add.ClienteSeleccion.LastName;
                txtTreatment.Text = add.ClienteSeleccion.Treatment;
                txtPhone.Text = add.ClienteSeleccion.Phone;

                BtnSave.Enabled = false;
                btnModificar.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aun no has seleccionado ningun Cliente");
            }
        }                  
        
        private void AddClients_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            BtnDelete.Enabled = false;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            
            clients.Name = txtName.Text;
            clients.LastName = txtLastName.Text;
            clients.Treatment = txtTreatment.Text;
            clients.Phone = txtPhone.Text;
            clients.Id = ClienteActual.Id;

            int result = ClientsDAL.Modificar(clients);

            if (result > 0 )
            {
                MessageBox.Show("El cliente se modifico con éxito");                
            }           
            else
            {
                MessageBox.Show("Error, no se pudo modificar el cliente!");
            }
        } 
        
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas eliminar este Cliente?", "Estas seguro?" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
                     
            {
                int resultado = ClientsDAL.Delete(ClienteActual.Id);

                if (resultado > 0)
                {
                    MessageBox.Show("Cliente eliminado correctamente", "Alumno Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    BtnDelete.Enabled = false;
                    btnModificar.Enabled = false;
                    BtnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Cliente", "Ocurrio un problema!!");
                }

            }
            else
            {
                MessageBox.Show("Se canceló la eliminacion", "cancelado");
            }
        }
        void Limpiar()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtTreatment.Clear();
            txtPhone.Clear();
        }
    }          
}

    

