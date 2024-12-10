using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using TIS.Imaging;

namespace Axial_Scan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (Axial_scan_code.LoadProperties == true)
            {
                string PropertyFile = File.ReadAllText(Axial_scan_code.folder + "\\" + Axial_scan_code.imagePropertiesFileName);
                //Console.WriteLine(PropertyFile);
                icImagingControl1.VCDPropertyItems.Load(PropertyFile);
            }
        }

        /// <summary>
        /// Form1_Load
        ///
        /// If no device has been selected in the properties window of IC Imaging
        /// Control, the device settings dialog of IC Imaging Control is show at
        /// start of this sample. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //if (!icImagingControl1.LoadShowSaveDeviceState("lastSelectedDeviceState.xml"))
            //{
            //    MessageBox.Show("No device was selected.", "Grabbing an Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}

            cmdStartLive.Enabled = true;
            cmdStopLive.Enabled = false;
            cmdSaveBitmap.Enabled = false;
            properties.Enabled = true;
        }

        /// <summary>
        /// cmdStartLive_Click
        ///
        /// Start the live video. A valid video capture device should have been
        /// selected previsously in the properties window of IC Imaging Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		//<<startlive
        private void cmdStartLive_Click(object sender, EventArgs e)
        {
            icImagingControl1.Sink = new TIS.Imaging.FrameSnapSink();

            icImagingControl1.LiveStart();

            cmdStartLive.Enabled = false;
            cmdStopLive.Enabled = true;
            cmdSaveBitmap.Enabled = true;
            properties.Enabled = true;
        }
        //>>
        /// <summary>
        /// cmdStopLive_Click
        ///
        /// Stop the live video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //<<stoplive
        private void cmdStopLive_Click(object sender, EventArgs e)
        {
            icImagingControl1.LiveStop();

            cmdStartLive.Enabled = true;
            cmdStopLive.Enabled = false;
            cmdSaveBitmap.Enabled = false;
            properties.Enabled = true;
            if (Axial_scan_code.automate == true)
            {

                this.Show();
                this.Activated -= new System.EventHandler(this.cmdStartLive_Click);
                this.Activated -= new System.EventHandler(this.cmdSaveBitmap_Click);

                this.Close(); //don't use application.exit

            }
        }
        //>>

        /// <summary>
        /// cmdSaveBitmap_Click
        ///
        /// Snap an image from the live video stream and show the file save
        /// dialog. After a file name has been selected, the image is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //<<savebitmap
        private void cmdSaveBitmap_Click(object sender, EventArgs e)
        {
            if (Axial_scan_code.automate == true)
            {
                //take image automatically

                //count how many times an image is saved. Add that to saved file names
                numberOfsaves += 1;

                //convert int to string
                string c = numberOfsaves.ToString();
                //string d = numberOfsaves.ToString();

                //FrameSnapSink sink = new FrameSnapSink(MediaSubtypes.RGB32);
                FrameSnapSink sink = new FrameSnapSink(MediaSubtypes.Y800);
                icImagingControl1.Sink = sink;
                icImagingControl1.LiveStart();
                // fetch a single image
                IFrameQueueBuffer frame = sink.SnapSingle(TimeSpan.FromSeconds(500));

                frame.SaveAsBitmap(Axial_scan_code.SavePlace + ".bmp");
            
            }
            else
            {
                TIS.Imaging.FrameSnapSink snapSink = icImagingControl1.Sink as TIS.Imaging.FrameSnapSink;

                TIS.Imaging.IFrameQueueBuffer frm = snapSink.SnapSingle(TimeSpan.FromDays(365));
                // This seems to fail when I open up the properties tab

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.FileName = "baseline";
                saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                //saveFileDialog1.ShowDialog();
                //DialogResult.OK;
                //DialogResult oK = DialogResult.OK ;

                //this.DialogResult = DialogResult.OK;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frm.SaveAsBitmap(saveFileDialog1.FileName);

                    //this.cmdSaveBitmap.Image.Save("5", System.Drawing.Imaging.ImageFormat.Bmp);

                }
                Thread.Sleep(500);
            }

            //save image properties
            string x = icImagingControl1.VCDPropertyItems.Save();
            //Console.WriteLine(x);
            

            if (Axial_scan_code.automate == true)
            {
                filePath_2 = Axial_scan_code.folder + "\\ImageProperties" + Axial_scan_code.iterations.ToString() + ".txt";
                File.WriteAllText(filePath_2, x);
            }
            Axial_scan_code.iterations++;
        }

        private void cmdProperties_Click(object sender, EventArgs e)
        {
            icImagingControl1.LiveStop();
            cmdStartLive.Enabled = true;
            cmdStopLive.Enabled = false;
            cmdSaveBitmap.Enabled = false;
            properties.Enabled = true;

            if (!icImagingControl1.LoadShowSaveDeviceState("lastSelectedDeviceState.xml"))
            {
                MessageBox.Show("No device was selected.", "Grabbing an Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
        public static int numberOfsaves = 0;

        public VCDAbsoluteValueProperty absValItf;
        public static string filePath_2;

        //private void Form1_Load_1(object sender, EventArgs e)
        //{

        //}

        //private void icImagingControl1_Load(object sender, EventArgs e)
        //{

        //}
    }
}