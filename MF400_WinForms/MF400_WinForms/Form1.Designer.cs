namespace MF400_Winforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl = new OpenTK.WinForms.GLControl();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glControl.APIVersion = new System.Version(3, 3, 0, 0);
            this.glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glControl.IsEventDriven = true;
            this.glControl.Location = new System.Drawing.Point(314, 46);
            this.glControl.Name = "glControl";
            this.glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            this.glControl.Size = new System.Drawing.Size(391, 353);
            this.glControl.TabIndex = 0;
            this.glControl.Text = "glControl1";
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Click += new System.EventHandler(this.glControl_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(31, 135);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Minimum = 10;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(221, 41);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Value = 10;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.glControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.WinForms.GLControl glControl;
        private HScrollBar hScrollBar1;
    }
}