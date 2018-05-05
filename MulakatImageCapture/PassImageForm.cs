using DirectShowLib;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulakatImageCapture
{
    public partial class PassImageForm : Form
    {
        #region Variables
        #region Camera Capture Variables
        private VideoCapture _capture = null; //Camera
        public string tempFilePath;
        private bool _captureInProgress = false; //Variable to track camera state
        int CameraDevice = 0; //Variable to track camera device selected
        Video_Device[] WebCams; //List containing all the camera available
        #endregion
        #endregion
        public PassImageForm()
        {
            InitializeComponent();
            //-> Find systems cameras with DirectShow.Net dll
            //thanks to carles lloret
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Camera_Selection.Items.Add(WebCams[i].ToString());
            }
            if (Camera_Selection.Items.Count > 0)
            {
                Camera_Selection.SelectedIndex = 0; //Set the selected device the default
                btnCapture.Enabled = true; //Enable the start
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
            try
            {

                //Image<Bgr, Byte> image = _capture.QueryFrame().ToImage<Bgr, Byte>();
                 Mat frame = new Mat();
                _capture.Retrieve(frame, 0);
                tempFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + "tmpImg.jpg";
                frame.Save(tempFilePath);
                DisplayImage(frame.Bitmap);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                //because we are using an autosize picturebox we need to do a thread safe update
                
        }

        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (passImageBox.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                passImageBox.Image = Image;
                

            }
        }



        private void SetupCapture(int Camera_Identifier)
        {
            //update the selected device
            CameraDevice = Camera_Identifier;

            //Dispose of Capture if it was created before
            if (_capture != null) _capture.Dispose();
            try
            {
                //Set up capture device
                _capture = new VideoCapture(CameraDevice);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }


        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    btnCapture.Text = "Start"; //Change text on button
                    _capture.Pause(); //Pause the capture
                    _captureInProgress = false; //Flag the state of the camera
                }
                else
                {
                    //Check to see if the selected device has changed
                    if (Camera_Selection.SelectedIndex != CameraDevice)
                    {
                        SetupCapture(Camera_Selection.SelectedIndex); //Setup capture with the new device
                    }

                    btnCapture.Text = "Stop"; //Change text on button
                    _capture.Start(); //Start the capture
                    _captureInProgress = true; //Flag the state of the camera
                }

            }
            else
            {
                //set up capture with selected device
                SetupCapture(Camera_Selection.SelectedIndex);
                //Be lazy and Recall this method to start camera
                btnCapture_Click(null, null);
            }

        }
    }
}
