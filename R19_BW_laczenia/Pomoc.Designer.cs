namespace R19_BW_laczenia
{
    partial class Pomoc
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
            this.pomocOK = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pomocOK
            // 
            this.pomocOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pomocOK.Location = new System.Drawing.Point(953, 406);
            this.pomocOK.Name = "pomocOK";
            this.pomocOK.Size = new System.Drawing.Size(117, 35);
            this.pomocOK.TabIndex = 0;
            this.pomocOK.Text = "OK";
            this.pomocOK.UseVisualStyleBackColor = true;
            this.pomocOK.Click += new System.EventHandler(this.PomocOK_Click);
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(3, 3);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(1076, 400);
            this.rtbText.TabIndex = 2;
            this.rtbText.Text = "";
            // 
            // Pomoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 453);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.pomocOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Pomoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pomoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pomoc_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pomocOK;
        private System.Windows.Forms.RichTextBox rtbText;
    }
}