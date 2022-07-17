using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace proyecto2_DiegoUmana
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning=false;

        private dynamic[] ingresarInformacion()
        {
            dynamic[] datos = new dynamic[5];
            if (isCameraRunning == true)
            {
                
                // Tome una instantánea de la imagen actual generada por OpenCV en el cuadro de imagen
                int cedula = int.Parse(txtCedula.Text);
                Bitmap snapshot = new Bitmap(picBoxFoto.Image);
                datos[0] =cedula ;
                datos[1] = snapshot;
                datos[2] = DateTime.Now.ToString("hh:mm:ss");
                datos[3] = DateTime.Now.ToString("dd-MM-yyyy");
                datos[4] = "";


                // Guardar en algún directorio
                //snapshot.Save(string.Format("C://Users//franc//source//repos//proyecto2_DiegoUmana//foto.png", Guid.NewGuid()), ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("¡No se pueden tomar fotografías si la cámara no está capturando imágenes!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
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

        private  void btnIngresar_Click(object sender, EventArgs e)
        {
            dynamic datos = ingresarInformacion();
            string info=consultar.insertar("registromarcas",datos);
            if (info.Equals("error"))
            {
                MessageBox.Show("Informacion NO INGRESADA", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (info.Equals("ok"))
            {
                MessageBox.Show("Informacion INGRESADA", "Aceptada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           
        }

        
        private void btnHabilitar_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

    }
}
