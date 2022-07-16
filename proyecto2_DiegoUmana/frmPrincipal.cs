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
        bool isCameraRunning=true;

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
            CaptureCamera();
            
            if (isCameraRunning)
            {

                // Tome una instantánea de la imagen actual generada por OpenCV en el cuadro de imagen
                
                Bitmap snapshot = new Bitmap(picBoxFoto.Image);

                // Guardar en algún directorio
                // en este ejemplo, generaremos un nombre de archivo aleatorio, por ejemplo 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                snapshot.Save(string.Format("C://Users//franc//source//repos//proyecto2_DiegoUmana//foto.png", Guid.NewGuid()), ImageFormat.Png);
            }
            else
            {
                Console.WriteLine("¡No se pueden tomar fotografías si la cámara no está capturando imágenes!");
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
        
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (btnHabilitar.Text.Equals("habilitar"))
            {
                CaptureCamera();
                btnHabilitar.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                btnHabilitar.Text = "Start";
                isCameraRunning = false;
            }
        }
        
    }
}
