namespace CEIDGREGON
{
    public partial class MainForm : Form
    {
        DbChooseForm db;
        ShowRaportValues ShowInsert;
        CheckAllReq Check;
        ProgramOptions options;
        public MainForm()
        {
            Check = new CheckAllReq();
            Settings();
            ShowInsert = new ShowRaportValues();
        }
        void Settings()
        {
            Check.Requiments();

            InitializeComponent();
            CenterToScreen();
            SetElementsLocation();
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

            RegonBox.Visible = NIPBox.Visible = KRSBox.Visible = raportyPelne.Visible = false;
            raportyZbiorcze.Visible = DataRaportPicker.Visible = true;

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
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowInsert.GetValuesAndInsertToDB(raportRodzBox.SelectedIndex,
                new List<string> { RegonBox.Text, NIPBox.Text, KRSBox.Text,
                    DataRaportPicker.Text }, new List<string> { raportyPelne.Text, raportyZbiorcze.Text }));
        }
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

        private void CheckStanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options = new ProgramOptions();
            options.ShowDialog();
        }
    }
}