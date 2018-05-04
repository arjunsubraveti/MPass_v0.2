namespace MulakatImageCapture
{
    partial class PassImageForm
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
            this.passImageBox = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.Camera_Selection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.passImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // passImageBox
            // 
            this.passImageBox.Location = new System.Drawing.Point(1, 1);
            this.passImageBox.Name = "passImageBox";
            this.passImageBox.Size = new System.Drawing.Size(506, 449);
            this.passImageBox.TabIndex = 0;
            this.passImageBox.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(591, 191);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // Camera_Selection
            // 
            this.Camera_Selection.FormattingEnabled = true;
            this.Camera_Selection.Location = new System.Drawing.Point(524, 141);
            this.Camera_Selection.Name = "Camera_Selection";
            this.Camera_Selection.Size = new System.Drawing.Size(230, 21);
            this.Camera_Selection.TabIndex = 4;
            // 
            // PassImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Camera_Selection);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.passImageBox);
            this.Name = "PassImageForm";
            this.Text = "PassImageForm";
            this.Load += new System.EventHandler(this.PassImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.passImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox passImageBox;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.ComboBox Camera_Selection;
    }
}