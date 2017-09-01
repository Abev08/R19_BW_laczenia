using System;
using System.Drawing;
using System.Windows.Forms;

namespace R19_BW_laczenia
{
    public partial class Form2 : Form
    {
        public bool IsOpen = false; // flaga otwarcia Form'a
        public string DisplayedTable = "";

        public Form2()
        {
            InitializeComponent();

            IsOpen = true;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Font = new Font("Segoe UI", 9);
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
            this.Dispose();
            this.Close();
        }
    }
}
