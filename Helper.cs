using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;
using NLog;

namespace BaslerCamera
{
    public static class Helper
    {

        public static Camera GetGigECameraBySerialNumber(string serialNumber)
        {
            Camera camera = null;

            try
            {
                // Gets an array of all available GigE cameras.
                List<ICameraInfo> allDeviceInfos = CameraFinder.Enumerate(DeviceType.GigE);

                if (allDeviceInfos.Count == 0) throw new CameraNotFoundException("No GigE cameras found.");

                // Find the camera with the specified serial number.
                allDeviceInfos.ForEach(cameraInfo => { if (cameraInfo[CameraInfoKey.SerialNumber] == serialNumber) { camera = new Camera(cameraInfo); } });

                if (camera == null) throw new CameraNotFoundException("No GigE camera with serial number " + serialNumber + " found.");
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }

            return camera;
        }


        public static void ConfigureCameraForStreaming(Camera camera)
        {
            try
            {
                //camera.Parameters[PLCameraInstance.GrabCameraEvents].SetValue(true);
                camera.CameraOpened += Configuration.AcquireContinuous;

                //camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                camera.Open();

                camera.Parameters[PLStream.MaxNumBuffer].SetValue(10);

                camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByUser);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
        }


        public static Bitmap GetBitmapFromCamera(Camera camera)
        {
            Bitmap bitmap = null;
            try
            {
                if (camera == null || camera.StreamGrabber == null) return null;

                if (camera.StreamGrabber.GrabResultWaitHandle.WaitOne(0))
                {
                    // grab results are waiting
                }

                // Camera will return grab results in the order they arrive.
                IGrabResult grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);

                if (grabResult == null) return null;

                using (grabResult)
                {
                    // Image grabbed successfully?
                    if (grabResult.GrabSucceeded)
                    {
                        // Print the model name and the IP address of the camera.
                        Console.WriteLine("Image grabbed successfully for: {0} ({1})",
                            camera.CameraInfo.GetValueOrDefault(CameraInfoKey.FriendlyName, null),
                            camera.CameraInfo.GetValueOrDefault(CameraInfoKey.DeviceIpAddress, null));

                        bitmap = BitmapFromGrabResult(grabResult);
                    }
                    else
                    {
                        // If a buffer hasn't been grabbed completely, the network bandwidth is possibly insufficient for transferring
                        // multiple images simultaneously. See note above c_maxCamerasToUse.
                        Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
            return bitmap;

        }

        private static Bitmap BitmapFromGrabResult(IGrabResult grabResult)
        {
            Bitmap bitmap = null;
            try
            {
                PixelDataConverter converter = new PixelDataConverter();
                bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                // Lock the bits of the bitmap.
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                // Place the pointer to the buffer of the bitmap.
                converter.OutputPixelFormat = PixelType.BGRA8packed;
                IntPtr ptrBmp = bmpData.Scan0;
                converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                bitmap.UnlockBits(bmpData);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
            return bitmap;

        }

        public static void ShutdownCamera(Camera camera)
        {
            try
            {
                if (camera != null)
                {
                    if (camera.StreamGrabber != null) camera.StreamGrabber.Stop();
                    camera.Close();
                    camera.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
        }

        public static Bitmap DrawCrosshair (Bitmap bitmap, Color color)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Pen pen = new Pen(color, 1);

                    int crosshairDim = (int)(Math.Min(bitmap.Width, bitmap.Height) * .25);

                    g.DrawLine(pen, new Point(bitmap.Width / 2, (int)(bitmap.Height / 2 - crosshairDim)), new Point(bitmap.Width / 2, (int)(bitmap.Height / 2 + crosshairDim)));
                    g.DrawLine(pen, new Point((int)(bitmap.Width / 2 - crosshairDim), bitmap.Height / 2), new Point((int)(bitmap.Width / 2 + crosshairDim), bitmap.Height / 2));

                    // Draw a circle over the center of the crosshair.
                    g.DrawEllipse(pen, new Rectangle((int)(bitmap.Width / 2 - crosshairDim / 2), (int)(bitmap.Height / 2 - crosshairDim / 2), crosshairDim, crosshairDim));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
            return bitmap;
        }

    }
}