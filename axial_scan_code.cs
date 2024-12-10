using System;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TIS.Imaging; //this is for IC image//This may be x86, not x64 which could cause some issues
using System.Threading; 
using System.Threading.Tasks; 
using System.Diagnostics;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.GenericMotorCLI.Settings;
using Thorlabs.MotionControl.GenericMotorCLI;
using Thorlabs.MotionControl.KCube.DCServoCLI;

// Must run on x64, not Any CPU, not x86

namespace Axial_Scan
{
    class Axial_scan_code
    {
        //public axial_scan_code()
        //{
        //}

        [STAThread] //error if we don't have this
                    //private static TIS.Imaging.ICImagingControl icImagingControl1;

        public static void Main(string[] args)
        {
            //ICimage info (windows form stuff)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //This next line starts a variable at zero that helps us save the image properties for every image
            iterations = 0;
            numberOfImages = 0;

            folder = "R:\\ENG_PROBELab_Shared\\group\\Mitch\\ST Generation\\ST characterization Beam block\\ST Beam block characterizing ultra thin light sheet after block\\12092024";
            folder2 = "R:\\ENG_PROBELab_Shared\\group\\Mitch\\ST Generation\\ST characterization Beam block\\ST Beam block characterizing ultra thin light sheet after block\\12092024\\Image";

            System.IO.Directory.CreateDirectory(folder2);

            //Do you want to load properties to the camera?
            LoadProperties = true;
            imagePropertiesFileName = "ImageProperties_Load.txt";

            //automate the process? Set to false to take a baseline
            automate = true;


            // Set the serial number for the motor
            //string serialNo = "27261344"; // stage S/n is 149100

            // Connect to the motor

            // Enter the serial number for your device
            string serialNo = "27261344";

            DeviceManagerCLI.BuildDeviceList();


            // This creates an instance of KCubeDCServo class, passing in the Serial 
            //Number parameter.  
            KCubeDCServo device = KCubeDCServo.CreateKCubeDCServo(serialNo);

            // We tell the user that we are opening connection to the device. 
            Console.WriteLine("Opening device {0}", serialNo);

            // This connects to the device. 
            device.Connect(serialNo);

            // Wait for the device settings to initialize. We ask the device to 
            // throw an exception if this takes more than 5000ms (5s) to complete. 
            device.WaitForSettingsInitialized(5000);

            // This calls LoadMotorConfiguration on the device to initialize the 
            // DeviceUnitConverter object required for real world unit parameters.
            MotorConfiguration motorSettings = device.LoadMotorConfiguration(device.DeviceID,
            DeviceConfiguration.DeviceSettingsUseOptionType.UseFileSettings);

            // This starts polling the device at intervals of 250ms (0.25s). 

            device.StartPolling(250);

            // We are now able to Enable the device otherwise any move is ignored. 
            // You should see a physical response from your controller. 
            device.EnableDevice();
            Console.WriteLine("Device Enabled");

            // Needs a delay to give time for the device to be enabled. 
            Thread.Sleep(500);
            // Home the stage/actuator.  
            //Console.WriteLine("Actuator is Homing");
            //device.Home(60000);

            // Shut down controller using Disconnect() to close comms
            //device.ShutDown();


            //Set to false to take a baseline
            if (automate == false)
            {
                Application.Run(new Form1());
                //ListAllPropertyItems();
                return;
            }
            //Take images in an automated fashion

            //num_z_steps = 960;
            int num_z_steps = 160;
            int length = 2; // mm
            decimal dz = 0.0125m; //mm
            int start = 12;
            // multiply num_z_steps by gz to get the length in mm
            device.MoveTo(start, 10000000);

            for (i = 0; i <= num_z_steps; i++) // <= is important here to make sure it goes the full distance
            {
                //Motorized stage part
                Console.WriteLine("Actuator is Moving");
                //device.MoveRelative
                device.MoveTo(start - (i*dz), 10000000);
                Thread.Sleep(500);

                // Imaging part
                SavePlace = folder2 + "\\Image" + i.ToString();
                Console.WriteLine(i);
                Application.Run(new Form1());
                Thread.Sleep(500);
                numberOfImages++;
            }

            //Stop polling motor device
            device.StopPolling();

        }



        public static void cmdStartLive_Click(object sender, EventArgs e)
        {
            icImagingControl1.Sink = new TIS.Imaging.FrameSnapSink();

            icImagingControl1.LiveStart();

            cmdStartLive.Enabled = false;
            //cmdStopLive.Enabled = true;
            //cmdSaveBitmap.Enabled = true;
            //properties.Enabled = true;

        }
        private void Form1_Shown(Object sender, EventArgs e)
        {
            cmdStartLive.PerformClick();
        }


        public static TIS.Imaging.ICImagingControl icImagingControl1;
        public static System.Windows.Forms.Button cmdStartLive;
        public static int length;
        public static int I_H = 0;
        public static int I_CH = 0;
        public static int I_V = 0;
        public static int I_CV = 0;
        public static int I_D = 0;
        public static int I_CD = 0;
        public static int i; // a, b, DS or ab
        public static string SavePlace;
        public static bool automate;
        public static string filePath;
        public static string folder;
        public static string folder2;
        public static int iterations;
        public static bool LoadProperties;
        public static string imagePropertiesFileName;
        public static int numberOfImages;
        public static int velocity;
        public static int position;
    }
}
