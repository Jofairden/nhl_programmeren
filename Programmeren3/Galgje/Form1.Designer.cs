namespace Galgje
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.inputTextbox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.hangManImages = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// inputTextbox
			// 
			this.inputTextbox.Location = new System.Drawing.Point(113, 84);
			this.inputTextbox.Name = "inputTextbox";
			this.inputTextbox.Size = new System.Drawing.Size(44, 20);
			this.inputTextbox.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(178, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "try";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// hangManImages
			// 
			this.hangManImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hangManImages.ImageStream")));
			this.hangManImages.TransparentColor = System.Drawing.Color.Transparent;
			this.hangManImages.Images.SetKeyName(0, "galgje_spelen_0.gif");
			this.hangManImages.Images.SetKeyName(1, "galgje_spelen_1.gif");
			this.hangManImages.Images.SetKeyName(2, "galgje_spelen_2.gif");
			this.hangManImages.Images.SetKeyName(3, "galgje_spelen_3.gif");
			this.hangManImages.Images.SetKeyName(4, "galgje_spelen_4.gif");
			this.hangManImages.Images.SetKeyName(5, "galgje_spelen_5.gif");
			this.hangManImages.Images.SetKeyName(6, "galgje_spelen_6.gif");
			this.hangManImages.Images.SetKeyName(7, "galgje_spelen_7.gif");
			this.hangManImages.Images.SetKeyName(8, "galgje_spelen_8.gif");
			this.hangManImages.Images.SetKeyName(9, "galgje_spelen_9.gif");
			this.hangManImages.Images.SetKeyName(10, "galgje_spelen_10.gif");
			this.hangManImages.Images.SetKeyName(11, "galgje_spelen_11.gif");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 471);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.inputTextbox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList hangManImages;

    }
}

