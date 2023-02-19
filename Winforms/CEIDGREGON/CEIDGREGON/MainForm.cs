using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ServiceReference1;
using CEIDGREGON.CEIDGREGONBLL;
using CEIDGREGON.CEIDGREGONDAL.GUSValuesBLLTableAdapters;

namespace CEIDGREGON
{
    public partial class MainForm : Form
    {
        DbChooseForm db;
        GetRequests request;
        ProgramGeneralData allData;
        GetFirstNonEmptyValue Value;
        GUSValuesBLL gusData;
        GUSValuesTableAdapter gusConn;
        public MainForm()
        {
            request = new GetRequests();
            allData = new ProgramGeneralData();
            Value = new GetFirstNonEmptyValue();
            gusData = new GUSValuesBLL();
            gusConn = new GUSValuesTableAdapter();
            Settings();
        }
        void Settings()
        {
            if (!IsInternetConnection())
            {
                MessageBox.Show("Program nie mo¿e zostaæ uruchomiony \nSprawdŸ swoje po³¹czenie internetowe", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(allData.DBFile))
            {
                db = new DbChooseForm();
                db.ShowDialog();
            }
            InitializeComponent();
            CenterToScreen();
            SetElementsLocation();

            request.Login(allData.GusToken);
            using (StreamReader sr = new StreamReader(allData.DBFile))
                gusConn.Connection.ConnectionString = sr.ReadToEnd();
        }
        void SetElementsLocation()
        {
            raportyPelne.Location = raportyZbiorcze.Location = NIPBox.Location;
            DataRaportPicker.Location = RegonBox.Location;
            raportRodzBox.SelectedIndex = raportyPelne.SelectedIndex = raportyZbiorcze.SelectedIndex = 0;
        }
        private void SetElementsVisibility(int SelectedRaportIndex)
        {
            SetLabelText(SelectedRaportIndex);

            if (SelectedRaportIndex == 0)
            {
                RegonBox.Visible = NIPBox.Visible = KRSBox.Visible = true;
                DataRaportPicker.Visible = raportyZbiorcze.Visible = raportyPelne.Visible = monthCalendar1.Visible = false;
            }
            else if (SelectedRaportIndex == 1)
            {
                RegonBox.Visible = raportyPelne.Visible = true;
                NIPBox.Visible = KRSBox.Visible = raportyZbiorcze.Visible = DataRaportPicker.Visible = monthCalendar1.Visible = false;
            }
            else //(SelectedRaportIndex == 2)
            {
                RegonBox.Visible = NIPBox.Visible = KRSBox.Visible = raportyPelne.Visible = false;
                raportyZbiorcze.Visible = DataRaportPicker.Visible = true;
            }
        }
        private void SetLabelText(int VersionOfText)
        {
            RegonLabel.Text = "REGON";
            NIPLabel.Text = "Nazwa raportu";
            KRSLabel.Text = string.Empty;

            if (VersionOfText == 0)
            {
                NIPLabel.Text = "NIP";
                KRSLabel.Text = "KRS";
            }
            else if (VersionOfText == 2)
                RegonLabel.Text = "Data raportu";

        }
        private void raportRodzBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetElementsVisibility(raportRodzBox.SelectedIndex);
            SetLabelText(raportRodzBox.SelectedIndex);
        }

        private void DataRaportPicker_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DataRaportPicker.Text = e.End.ToShortDateString();
            monthCalendar1.Visible = false;
        }
        private void GetValuesAndInsertToDB(int SelectedRaportIndex)
        {
            string GetValueFromAPI = string.Empty;

            if (SelectedRaportIndex == 0)
                GetValueFromAPI = request.GetValuesForDanePodmiotu(Value.ReturnFirstNonEmpty(new string[] { RegonBox.Text, NIPBox.Text, KRSBox.Text }));

            else if (SelectedRaportIndex == 1)
                GetValueFromAPI = request.GetValuesForPelnyRaport(RegonBox.Text, raportyPelne.Text);

            else //(SelectedRaportIndex == 2)
                GetValueFromAPI = request.GetValuesForZbiorczyRaport(DataRaportPicker.Text, raportyZbiorcze.Text);

            MessageBox.Show(GetValueFromAPI,"Dane",MessageBoxButtons.OK);
            
            gusData.InsertXMLValuesToDB(GetValueFromAPI, (byte)SelectedRaportIndex);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetValuesAndInsertToDB(raportRodzBox.SelectedIndex);
        }
        private bool IsInternetConnection()
        =>
        NetworkInterface.GetIsNetworkAvailable();
        private void ChangeDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DbChooseForm();
            db.ShowDialog();
        }

        private void EndOfWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Napewno chcesz zakoñczyæ pracê?", "Zakoñczenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Environment.Exit(0);
        }
    }
}