using System.Threading;

namespace Axial_Scan
{
    partial class Form1
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdStartLive = new System.Windows.Forms.Button();
            this.cmdSaveBitmap = new System.Windows.Forms.Button();
            this.cmdStopLive = new System.Windows.Forms.Button();
            this.icImagingControl1 = new TIS.Imaging.ICImagingControl();
            this.properties = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdStartLive
            // 
            this.cmdStartLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStartLive.Location = new System.Drawing.Point(76, 777);
            this.cmdStartLive.Name = "cmdStartLive";
            this.cmdStartLive.Size = new System.Drawing.Size(180, 88);
            this.cmdStartLive.TabIndex = 1;
            this.cmdStartLive.Text = "Start Live";
            this.cmdStartLive.UseVisualStyleBackColor = true;
            this.cmdStartLive.Click += new System.EventHandler(this.cmdStartLive_Click);
            // 
            // cmdSaveBitmap
            // 
            this.cmdSaveBitmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveBitmap.Location = new System.Drawing.Point(693, 777);
            this.cmdSaveBitmap.Name = "cmdSaveBitmap";
            this.cmdSaveBitmap.Size = new System.Drawing.Size(180, 88);
            this.cmdSaveBitmap.TabIndex = 2;
            this.cmdSaveBitmap.Text = "Save Bitmap";
            this.cmdSaveBitmap.UseVisualStyleBackColor = true;
            this.cmdSaveBitmap.Click += new System.EventHandler(this.cmdSaveBitmap_Click);
            // 
            // cmdStopLive
            // 
            this.cmdStopLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStopLive.Location = new System.Drawing.Point(384, 777);
            this.cmdStopLive.Name = "cmdStopLive";
            this.cmdStopLive.Size = new System.Drawing.Size(180, 88);
            this.cmdStopLive.TabIndex = 3;
            this.cmdStopLive.Text = "Stop Live";
            this.cmdStopLive.UseVisualStyleBackColor = true;
            this.cmdStopLive.Click += new System.EventHandler(this.cmdStopLive_Click);
            // 
            // icImagingControl1
            // 
            this.icImagingControl1.BackColor = System.Drawing.Color.White;
            this.icImagingControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.icImagingControl1.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icImagingControl1.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icImagingControl1.DeviceState = resources.GetString("icImagingControl1.DeviceState");
            this.icImagingControl1.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icImagingControl1.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icImagingControl1.Location = new System.Drawing.Point(9, 8);
            this.icImagingControl1.MemoryCurrentGrabberColorformat = TIS.Imaging.ICImagingControlColorformats.ICY800;
            this.icImagingControl1.Name = "icImagingControl1";
            this.icImagingControl1.Size = new System.Drawing.Size(1220, 739);
            this.icImagingControl1.TabIndex = 4;
            //this.icImagingControl1.Load += new System.EventHandler(this.icImagingControl1_Load);
            // 
            // properties
            // 
            this.properties.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.properties.Location = new System.Drawing.Point(979, 777);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(180, 88);
            this.properties.TabIndex = 5;
            this.properties.Text = "Properties";
            this.properties.UseVisualStyleBackColor = true;
            this.properties.Click += new System.EventHandler(this.cmdProperties_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 902);
            this.Controls.Add(this.properties);
            this.Controls.Add(this.icImagingControl1);
            this.Controls.Add(this.cmdStopLive);
            this.Controls.Add(this.cmdSaveBitmap);
            this.Controls.Add(this.cmdStartLive);
            this.Name = "Form1";
            this.Text = "Grabbing an Image";
            this.Load += new System.EventHandler(this.Form1_Load);

            if (Axial_scan_code.automate == true)
            {
                this.Activated += new System.EventHandler(this.cmdSaveBitmap_Click);
                this.Activated += new System.EventHandler(this.cmdStopLive_Click);
            }

            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        public System.Windows.Forms.Button cmdStartLive;
        public System.Windows.Forms.Button cmdSaveBitmap;
        public System.Windows.Forms.Button cmdStopLive;
        public System.Windows.Forms.Button properties;
        public TIS.Imaging.ICImagingControl icImagingControl1;
    }
}

