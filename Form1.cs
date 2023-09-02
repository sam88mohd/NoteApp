using System.Data;

namespace NoteApp
{
    public partial class MainForm : Form
    {
        DataTable dt = new DataTable();
        bool editing = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            TitleInput.Text = "";
            NoteInput.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                dt.Rows[TableContent.CurrentCell.RowIndex]["title"] = TitleInput.Text;
                dt.Rows[TableContent.CurrentCell.RowIndex]["note"] = NoteInput.Text;
            }
            else
            {
                dt.Rows.Add(TitleInput.Text, NoteInput.Text);
            }

            TitleInput.Text = "";
            NoteInput.Text = "";
            editing = false;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows[TableContent.CurrentCell.RowIndex].Delete();
            }
            catch
            {
                Console.WriteLine("Invalid note clicked.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Note", typeof(string));
            TableContent.DataSource = dt;
        }

        private void TableContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TitleInput.Text = dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[0]!.ToString();
            NoteInput.Text = dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[1]!.ToString();
            editing = true;
        }
    }
}