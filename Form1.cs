using System.Data;
using System.Data.SQLite;

namespace NoteApp
{
    public partial class MainForm : Form
    {
        bool editing = false;
        DataTable dt;
        SQLiteConnection conn;

        public MainForm()
        {
            InitializeComponent();
            conn = CreateConnection();
            if (!File.Exists("database.db"))
            {
                CreateTable(conn);
            }
            dt = FillDataTable(conn, "SELECT * FROM Notes");
        }

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection conn = new SQLiteConnection
                ("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                conn.Open();
            } catch (Exception e)
            {

            }
            return conn;
        }

        public void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            string command =
                "CREATE TABLE NOTES(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Title VARCHAR(50) NOT NULL, Note VARCHAR(250));";
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        public DataTable FillDataTable(SQLiteConnection conn, string sql)
        {
            DataTable dt = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand(sql);
            using (conn)
            {
                cmd.Connection = conn;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
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
                dt.Rows[TableContent.CurrentCell.RowIndex]["Title"] = TitleInput.Text;
                dt.Rows[TableContent.CurrentCell.RowIndex]["Note"] = NoteInput.Text;
            }
            else
            {
                dt.Rows.Add(1, TitleInput.Text, NoteInput.Text);
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