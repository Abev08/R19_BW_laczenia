using System;
using System.Drawing;
using System.Reflection;
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
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 1;
            // Włączenie DoubleBuffered dla dataGridView
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(dataGridView1, true, null);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
            this.Dispose();
            this.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != 0) & (e.ColumnIndex != 0))
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.PaleGreen;
                dataGridView1.Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.PaleGreen;
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gainsboro;
            dataGridView1.Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.Gainsboro;
        }
    }
}
