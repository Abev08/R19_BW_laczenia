namespace R19_BW_laczenia
{
    partial class EditWindow
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
            this.cbEditLoadedItems = new System.Windows.Forms.ComboBox();
            this.TextLoadedItems = new System.Windows.Forms.Label();
            this.cbEditPref = new System.Windows.Forms.ComboBox();
            this.cbEditBaza = new System.Windows.Forms.ComboBox();
            this.cbEditSuf = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEditLoadedItems
            // 
            this.cbEditLoadedItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditLoadedItems.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbEditLoadedItems.FormattingEnabled = true;
            this.cbEditLoadedItems.Location = new System.Drawing.Point(221, 10);
            this.cbEditLoadedItems.Name = "cbEditLoadedItems";
            this.cbEditLoadedItems.Size = new System.Drawing.Size(450, 29);
            this.cbEditLoadedItems.TabIndex = 43;
            this.cbEditLoadedItems.SelectedIndexChanged += new System.EventHandler(this.CbEditLoadedItems_SelectedIndexChanged);
            // 
            // TextLoadedItems
            // 
            this.TextLoadedItems.BackColor = System.Drawing.Color.Transparent;
            this.TextLoadedItems.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextLoadedItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextLoadedItems.Location = new System.Drawing.Point(12, 9);
            this.TextLoadedItems.Name = "TextLoadedItems";
            this.TextLoadedItems.Size = new System.Drawing.Size(203, 29);
            this.TextLoadedItems.TabIndex = 44;
            this.TextLoadedItems.Text = "Załadowane przedmioty:";
            this.TextLoadedItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEditPref
            // 
            this.cbEditPref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditPref.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbEditPref.FormattingEnabled = true;
            this.cbEditPref.Location = new System.Drawing.Point(16, 60);
            this.cbEditPref.Name = "cbEditPref";
            this.cbEditPref.Size = new System.Drawing.Size(214, 29);
            this.cbEditPref.TabIndex = 46;
            // 
            // cbEditBaza
            // 
            this.cbEditBaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBaza.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbEditBaza.FormattingEnabled = true;
            this.cbEditBaza.Location = new System.Drawing.Point(236, 60);
            this.cbEditBaza.Name = "cbEditBaza";
            this.cbEditBaza.Size = new System.Drawing.Size(214, 29);
            this.cbEditBaza.TabIndex = 48;
            // 
            // cbEditSuf
            // 
            this.cbEditSuf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditSuf.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbEditSuf.FormattingEnabled = true;
            this.cbEditSuf.Location = new System.Drawing.Point(456, 60);
            this.cbEditSuf.Name = "cbEditSuf";
            this.cbEditSuf.Size = new System.Drawing.Size(215, 29);
            this.cbEditSuf.TabIndex = 50;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(48, 110);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(151, 38);
            this.btnEdit.TabIndex = 51;
            this.btnEdit.Text = "Zamień";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(268, 110);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 38);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(488, 110);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 38);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "Usuń";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(682, 163);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cbEditSuf);
            this.Controls.Add(this.cbEditBaza);
            this.Controls.Add(this.cbEditPref);
            this.Controls.Add(this.TextLoadedItems);
            this.Controls.Add(this.cbEditLoadedItems);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edytor załadowanych przedmiotów";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbEditLoadedItems;
        private System.Windows.Forms.Label TextLoadedItems;
        private System.Windows.Forms.ComboBox cbEditPref;
        private System.Windows.Forms.ComboBox cbEditBaza;
        private System.Windows.Forms.ComboBox cbEditSuf;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}