using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace proyect2_DiegoUmanaAdmin
{
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "")
            {
                MessageBox.Show("Agregar Codigo...", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] datos = {"nombre", "edad", "salarioXHora" };
                string condicion = " where cedula= " + txtCedula.Text;
                DataTable informacionEmpleado = new DataTable();
                informacionEmpleado = consulta.consultaTodosElementos("empleados", datos, condicion);
                cargarInformacion(informacionEmpleado);
            }
        }

        private void cargarInformacion(DataTable informacionEmpleado)
        {
            txtNombre.Text = informacionEmpleado.Rows[0]["nombre"].ToString();
            txtEdad.Text = informacionEmpleado.Rows[0]["edad"].ToString();
            txtSalarioXHora.Text = informacionEmpleado.Rows[0]["salarioXHora"].ToString();
          
        }
    }
}
