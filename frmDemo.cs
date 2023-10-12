using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Basler.Pylon;

namespace BaslerCamera
{
    public partial class frmDemo : Form
    {
        Camera camera = null;

        System.Timers.Timer timer = null;

        public frmDemo()
        {
            InitializeComponent();
            SetTimer();
        }

        private void SetTimer()
        {
            // Get an image from the camera every second.
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Bitmap bitmap = Helper.GetBitmapFromCamera(camera);
            if (bitmap != null) SetImage(bitmap);
        }

        private void SetImage(Bitmap bitmap)
        {
            if (pboxCamera.InvokeRequired)
            {
                pboxCamera.Invoke(new MethodInvoker(() => { SetImage(bitmap); }));
            }
            else
            {
                pboxCamera.Image = bitmap;
            }
        }


        private void btnLinkBaslerGigECamera_Click(object sender, EventArgs e)
        {
            try
            {
                // The initial camera we're messing with is 22811427.  
                camera = Helper.GetGigECameraBySerialNumber(txtSerialNumber.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Linking Basler Camera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                return;
            }

            try
            {
                if (camera != null)
                {
                    Helper.ConfigureCameraForStreaming(camera);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
            }

        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.ShutdownCamera(camera);
        }

        private void btnLoadDemoImage_Click(object sender, EventArgs e)
        {

            // Get path that the executable is running from.
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string bitmapPath = path + "\\SupportFiles\\demoImage.bmp";

            // Load bitmap from demo.bmp file in the SupportFiles folder.
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(bitmapPath);

            if (cbxShowCrosshair.Checked)
            {
                // Draw a crosshair on the bitmap.
                bitmap = Helper.DrawCrosshair(bitmap, Color.Yellow);
            }

            SetImage(bitmap);

        }
    }
}
