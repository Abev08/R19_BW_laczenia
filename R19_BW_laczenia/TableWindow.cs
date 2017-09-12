using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace R19_BW_laczenia
{
    public partial class TableWindow : Form
    {
        public bool IsOpen = false; // flaga otwarcia Form'a
        public string DisplayedTable = "";

        public TableWindow()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.Table_icon;
            this.IsOpen = true;
            
            DataGridView.ReadOnly = true;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.ColumnHeadersVisible = false;
            DataGridView.RowHeadersVisible = false;
            DataGridView.Font = new Font("Segoe UI", 9);
            DataGridView.RowTemplate.Height = 20;
            DataGridView.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
            DataGridView.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DataGridView.RowCount = 1;
            DataGridView.ColumnCount = 1;
            DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Włączenie DoubleBuffered dla dataGridView
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(DataGridView, true, null);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsOpen = false;
            this.Dispose();
            this.Close();
        }

        private void DataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Jeżeli wybrano komórkę tabeli podświetl wiersz i kolumnę
            if ((e.RowIndex != 0) & (e.ColumnIndex != 0))
            {
                DataGridView.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.PaleGreen;
                DataGridView.Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.PaleGreen;
            }
        }

        private void DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Jeżeli opuszczono wybraną komórkę tabeli zresetuj podświetlenie wiersza i kolumny
            DataGridView.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gainsboro;
            DataGridView.Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.Gainsboro;
        }
    }
}
