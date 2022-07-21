using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace proyect2_DiegoUmanaAdmin
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        VideoCapture capture;
        Mat frame;
        Bitmap image,snapshot;
        private Thread camera;
        bool isCameraRunning = false;

        /*
        private  bool  buscarCedula()//buscar en la BD si el empleado esta registrado
        {
            string resultado;
            bool flag = true;
            string[] datos = { "cedula"};
            string condicion = " where cedula= " + txtCedula.Text;
            DataTable informacion = new DataTable();
            informacion = consultar.consultaTodosElementos("empleados", datos, condicion);
            try{

               resultado = informacion.Rows[0]["cedula"].ToString();
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }
        */

        private void foto()
        {
            if (isCameraRunning == true)
            {
                // Tome una instantánea de la imagen actual generada por OpenCV en el cuadro de imagen
                snapshot = new Bitmap(picBoxFoto.Image);
                MessageBox.Show("¡Empleado Capturado!", "Aceptado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Guardar en algún directorio
                //snapshot.Save(string.Format("C://Users//franc//source//repos//proyecto2_DiegoUmana//foto.png", Guid.NewGuid()), ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("¡No se pueden tomar fotografías si la cámara no está capturando imágenes!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (picBoxFoto.Image != null)
                    {
                        picBoxFoto.Image.Dispose();
                    }
                    picBoxFoto.Image = image;
                }
            }
        }




        private dynamic[] ingresarInformacion()
        {
            dynamic[] datos = new dynamic[5];
            try
            {
                int cedula = int.Parse(txtCedula.Text);
                string nombre = txtNombre.Text;
                int edad = int.Parse(txtEdad.Text);
                int salario = int.Parse(txtSalarioXHora.Text);
                datos[0] = cedula;
                datos[1] = nombre;
                datos[2] = edad;
                datos[3] = salario;
                datos[4] = snapshot;
            }
            catch (Exception)
            {
                MessageBox.Show("Informacion NO INGRESADA", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            dynamic datos = ingresarInformacion();
            string info = consulta.insertar("empleados", datos);
            if (info.Equals("error"))
            {
                MessageBox.Show("Informacion NO INGRESADA", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (info.Equals("ok"))
            {
                MessageBox.Show("Informacion INGRESADA", "Aceptada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtSalarioXHora.Clear();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnHabilitar_Click_1(object sender, EventArgs e)
        {
            if (btnHabilitar.Text.Equals("Habilitar Camara"))
            {
                CaptureCamera();
                btnHabilitar.Text = "Deshabilitar Camara";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                btnHabilitar.Text = "Habilitar Camara";
                isCameraRunning = false;
            }
        }

        private void buscarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscar ventanaBuscar = new frmBuscar();
            ventanaBuscar.Visible = true;
        }

        private void btnCapturar_Click_1(object sender, EventArgs e)
        {
           foto();
        }
    }
}
