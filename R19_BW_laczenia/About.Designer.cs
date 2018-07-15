namespace R19_BW_laczenia
{
    partial class About
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.byMe = new System.Windows.Forms.LinkLabel();
            this.repo = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pomocOK
            // 
            this.pomocOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pomocOK.Location = new System.Drawing.Point(297, 8);
            this.pomocOK.Margin = new System.Windows.Forms.Padding(8);
            this.pomocOK.Name = "pomocOK";
            this.pomocOK.Size = new System.Drawing.Size(94, 28);
            this.pomocOK.TabIndex = 1;
            this.pomocOK.Text = "OK";
            this.pomocOK.UseVisualStyleBackColor = true;
            this.pomocOK.Click += new System.EventHandler(this.pomocOK_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pomocOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 44);
            this.panel2.TabIndex = 2;
            // 
            // text
            // 
            this.text.BackColor = System.Drawing.Color.Transparent;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Margin = new System.Windows.Forms.Padding(5);
            this.text.Name = "text";
            this.text.Padding = new System.Windows.Forms.Padding(5);
            this.text.Size = new System.Drawing.Size(399, 152);
            this.text.TabIndex = 60;
            this.text.Text = "...";
            this.text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.text);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 152);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.repo);
            this.panel3.Controls.Add(this.byMe);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 30);
            this.panel3.TabIndex = 4;
            // 
            // byMe
            // 
            this.byMe.ActiveLinkColor = System.Drawing.SystemColors.ControlLightLight;
            this.byMe.BackColor = System.Drawing.Color.Transparent;
            this.byMe.Dock = System.Windows.Forms.DockStyle.Right;
            this.byMe.LinkColor = System.Drawing.Color.Teal;
            this.byMe.Location = new System.Drawing.Point(339, 0);
            this.byMe.Name = "byMe";
            this.byMe.Size = new System.Drawing.Size(60, 30);
            this.byMe.TabIndex = 62;
            this.byMe.TabStop = true;
            this.byMe.Text = "by Abev";
            this.byMe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.byMe.Click += new System.EventHandler(this.byMe_Click);
            // 
            // repo
            // 
            this.repo.ActiveLinkColor = System.Drawing.SystemColors.ControlLightLight;
            this.repo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repo.LinkColor = System.Drawing.Color.Teal;
            this.repo.Location = new System.Drawing.Point(0, 0);
            this.repo.Name = "repo";
            this.repo.Size = new System.Drawing.Size(339, 30);
            this.repo.TabIndex = 61;
            this.repo.TabStop = true;
            this.repo.Text = "https://github.com/Abev08/R19_BW_laczenia";
            this.repo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.repo.Click += new System.EventHandler(this.repo_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 236);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pomocOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel byMe;
        private System.Windows.Forms.LinkLabel repo;
    }
}