namespace R19_BW_laczenia
{
    partial class TableWindow
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
            this.tabTabela = new System.Windows.Forms.TabControl();
            this.tabMinus = new System.Windows.Forms.Button();
            this.tabPlus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTabela
            // 
            this.tabTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTabela.Location = new System.Drawing.Point(0, 0);
            this.tabTabela.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabTabela.Name = "tabTabela";
            this.tabTabela.SelectedIndex = 0;
            this.tabTabela.Size = new System.Drawing.Size(346, 181);
            this.tabTabela.TabIndex = 1;
            this.tabTabela.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabTabela_MouseUp);
            // 
            // tabMinus
            // 
            this.tabMinus.Location = new System.Drawing.Point(44, 0);
            this.tabMinus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabMinus.Name = "tabMinus";
            this.tabMinus.Size = new System.Drawing.Size(38, 24);
            this.tabMinus.TabIndex = 2;
            this.tabMinus.Text = "-";
            this.tabMinus.UseVisualStyleBackColor = true;
            this.tabMinus.Click += new System.EventHandler(this.TabMinus_Click);
            // 
            // tabPlus
            // 
            this.tabPlus.Location = new System.Drawing.Point(0, 0);
            this.tabPlus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPlus.Name = "tabPlus";
            this.tabPlus.Size = new System.Drawing.Size(38, 24);
            this.tabPlus.TabIndex = 3;
            this.tabPlus.Text = "+";
            this.tabPlus.UseVisualStyleBackColor = true;
            this.tabPlus.Click += new System.EventHandler(this.TabPlus_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPlus);
            this.panel1.Controls.Add(this.tabMinus);
            this.panel1.Location = new System.Drawing.Point(225, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 24);
            this.panel1.TabIndex = 4;
            // 
            // TableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 181);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabTabela);
            this.DoubleBuffered = true;
            this.Name = "TableWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tabela łączeń";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Resize += new System.EventHandler(this.TableWindow_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabTabela;
        private System.Windows.Forms.Button tabMinus;
        private System.Windows.Forms.Button tabPlus;
        private System.Windows.Forms.Panel panel1;
    }
}