using Microsoft.Win32;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace CEIDGREGON
{
    public partial class DbChooseForm : Form
    {
        ProgramGeneralData data;
        DBOperations dbFile;
        string ConnectionString = string.Empty;
        public DbChooseForm()
        {
            InitializeComponent();
            data = new ProgramGeneralData();
            dbFile = new DBOperations();
        }
        private IEnumerable<string> GetServerName()
        {
            string ServerName = Environment.MachineName;

            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        yield return ServerName + "\\" + instanceName;
                    }
                }
            }
        }

        private void DbChoose_Load(object sender, EventArgs e)
        {
            foreach(var DbName in GetServerName())
                DbBox.Items.Add(DbName);
            DbBox.SelectedIndex = DbBox.Items.Count - 1;
        }

        private void btnConnTest_Click(object sender, EventArgs e)
        {
            string MessageType = TestDbConn();
            string MessageText;
            MessageBoxIcon MessageIcon = MessageBoxIcon.Information;

            if (!MessageType.Contains("Połączenie zostało nawiązane"))
            {
                MessageType = "Połączenie niezostało nawiązane";
                MessageIcon = MessageBoxIcon.Error;
            }
            MessageBox.Show($"{MessageType}","Stan",MessageBoxButtons.OK, MessageIcon);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno zrezygnować z połączenia z bazą?","Baza",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                this.Hide();
        }
        private string TestDbConn()
        {
            string ConnStateMess = "Połączenie zostało nawiązane";

            ConnectionString = $"Data Source={DbBox.Text};Initial Catalog=master;USER ID={LoginBox.Text};Password={PassBox.Text}";
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    sql.Open();
                    sql.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                if (data.SqlErrorsNumbers.ContainsKey(sqlEx.Number))
                    ConnStateMess = data.SqlErrorsNumbers[sqlEx.Number];
                else
                    ConnStateMess = "Wystąpił nieoczekiwany błąd, spróbuj ponownie później";
            }
            return ConnStateMess;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            string MessageType = TestDbConn();
            if (!MessageType.Contains("Połączenie zostało nawiązane"))
            {
                MessageBox.Show($"{MessageType}", "Stan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dbFile.Operations(DbBox.Text, LoginBox.Text, PassBox.Text);
            this.Hide();
        }
    }
}
