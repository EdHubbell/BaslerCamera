namespace BaslerCamera
{
    partial class frmDemo
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pboxCamera = new Cyotek.Windows.Forms.ImageBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.btnLinkBaslerGigECamera = new System.Windows.Forms.Button();
            this.btnLoadDemoImage = new System.Windows.Forms.Button();
            this.cbxShowCrosshair = new System.Windows.Forms.CheckBox();
            this.tlpMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pboxCamera, 0, 0);
            this.tlpMain.Controls.Add(this.pnlRight, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 10;
            // 
            // pboxCamera
            // 
            this.pboxCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxCamera.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
            this.pboxCamera.Location = new System.Drawing.Point(3, 3);
            this.pboxCamera.Name = "pboxCamera";
            this.pboxCamera.Size = new System.Drawing.Size(794, 344);
            this.pboxCamera.TabIndex = 3;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.cbxShowCrosshair);
            this.pnlRight.Controls.Add(this.btnLoadDemoImage);
            this.pnlRight.Controls.Add(this.txtSerialNumber);
            this.pnlRight.Controls.Add(this.lblSerialNumber);
            this.pnlRight.Controls.Add(this.btnLinkBaslerGigECamera);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(3, 353);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(794, 94);
            this.pnlRight.TabIndex = 0;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(12, 64);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(177, 20);
            this.txtSerialNumber.TabIndex = 8;
            this.txtSerialNumber.Text = "22811427";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(9, 47);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(73, 13);
            this.lblSerialNumber.TabIndex = 7;
            this.lblSerialNumber.Text = "Serial Number";
            // 
            // btnLinkBaslerGigECamera
            // 
            this.btnLinkBaslerGigECamera.Location = new System.Drawing.Point(12, 14);
            this.btnLinkBaslerGigECamera.Name = "btnLinkBaslerGigECamera";
            this.btnLinkBaslerGigECamera.Size = new System.Drawing.Size(177, 23);
            this.btnLinkBaslerGigECamera.TabIndex = 4;
            this.btnLinkBaslerGigECamera.Text = "Link Basler Camera";
            this.btnLinkBaslerGigECamera.UseVisualStyleBackColor = true;
            this.btnLinkBaslerGigECamera.Click += new System.EventHandler(this.btnLinkBaslerGigECamera_Click);
            // 
            // btnLoadDemoImage
            // 
            this.btnLoadDemoImage.Location = new System.Drawing.Point(249, 14);
            this.btnLoadDemoImage.Name = "btnLoadDemoImage";
            this.btnLoadDemoImage.Size = new System.Drawing.Size(177, 23);
            this.btnLoadDemoImage.TabIndex = 9;
            this.btnLoadDemoImage.Text = "Load Demo Image";
            this.btnLoadDemoImage.UseVisualStyleBackColor = true;
            this.btnLoadDemoImage.Click += new System.EventHandler(this.btnLoadDemoImage_Click);
            // 
            // cbxShowCrosshair
            // 
            this.cbxShowCrosshair.AutoSize = true;
            this.cbxShowCrosshair.Location = new System.Drawing.Point(249, 64);
            this.cbxShowCrosshair.Name = "cbxShowCrosshair";
            this.cbxShowCrosshair.Size = new System.Drawing.Size(99, 17);
            this.cbxShowCrosshair.TabIndex = 10;
            this.cbxShowCrosshair.Text = "Show Crosshair";
            this.cbxShowCrosshair.UseVisualStyleBackColor = true;
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmDemo";
            this.Text = "BaslerCameraDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Button btnLinkBaslerGigECamera;
        internal Cyotek.Windows.Forms.ImageBox pboxCamera;
        private System.Windows.Forms.CheckBox cbxShowCrosshair;
        private System.Windows.Forms.Button btnLoadDemoImage;
    }
}

