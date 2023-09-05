using System.Data;
using System.Data.SQLite;

namespace NoteApp
{
    public partial class MainForm : Form
    {
        bool editing = false;
        DataTable dt;
        int id;
        string? command;

        public MainForm()
        {
            SQLiteConnection conn;
            InitializeComponent();
            conn = CreateConnection();
            CreateTable(conn);
            dt = FillDataTable(conn);
        }

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection conn = new SQLiteConnection
                ("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {

            }
            return conn;
        }

        public void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            command =
                "CREATE TABLE IF NOT EXISTS Notes" +
                "(ID INTEGER NOT NULL PRIMARY KEY, " +
                "Title VARCHAR(50) NOT NULL, " +
                "Note VARCHAR(250), " +
                "Completed INTEGER DEFAULT 0" +
                ");";
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        public DataTable FillDataTable(SQLiteConnection conn)
        {
            command = "SELECT ID, Title, Note, Completed FROM Notes";
            DataTable dt = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand(command);

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
            SQLiteCommand cmd;
            SQLiteConnection conn = CreateConnection();
            if (editing)
            {
                id = Convert.ToInt32(dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[0]);
                command = "UPDATE Notes SET Title = @title, Note = @note, Completed = @completedStatus WHERE ID = @id";
                cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("title", TitleInput.Text);
                cmd.Parameters.AddWithValue("note", NoteInput.Text);
                cmd.Parameters.AddWithValue("completedStatus", CompletedBox.Checked);
                cmd.ExecuteNonQuery();

                dt.Rows[TableContent.CurrentCell.RowIndex]["Title"] = TitleInput.Text;
                dt.Rows[TableContent.CurrentCell.RowIndex]["Note"] = NoteInput.Text;
                dt.Rows[TableContent.CurrentCell.RowIndex]["Completed"] = CompletedBox.Checked;
            }
            else
            {
                id += 1;
                command = "INSERT INTO NOTES(ID, Title, Note, Completed) VALUES (@id, @title, @note, @completedStatus)";
                cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("title", TitleInput.Text);
                cmd.Parameters.AddWithValue("note", NoteInput.Text);
                cmd.Parameters.AddWithValue("completedStatus", CompletedBox.Checked);
                cmd.ExecuteNonQuery();

                dt.Rows.Add(id, TitleInput.Text, NoteInput.Text, CompletedBox.CheckState);
            }

            TitleInput.Text = "";
            NoteInput.Text = "";
            CompletedBox.Checked = false;
            editing = false;
            MessageBox.Show("Successfully save the note");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd;
            SQLiteConnection conn = CreateConnection();
            try
            {
                id = Convert.ToInt32(dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[0]);
                command = "DELETE FROM Notes WHERE ID =@id ";
                cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                dt.Rows[TableContent.CurrentCell.RowIndex].Delete();
                MessageBox.Show("Record Successfully Deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TableContent.DataSource = dt;
            TableContent.Columns[0].Width = 30;
            TableContent.Columns[2].Width = 340;
            
            SQLiteConnection conn;
            SQLiteCommand cmd;
            command = "SELECT ID FROM Notes ORDER BY ID DESC LIMIT 1";
            conn = CreateConnection();
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void TableContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TitleInput.Text = dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[1]!.ToString();
            NoteInput.Text = dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[2]!.ToString();
            CompletedBox.Checked = Convert.ToBoolean(dt.Rows[TableContent.CurrentCell.RowIndex].ItemArray[3]);
            editing = true;
        }
    }
}