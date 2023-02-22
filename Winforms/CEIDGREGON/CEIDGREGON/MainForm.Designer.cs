namespace CEIDGREGON
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.raportRodzBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RegonBox = new System.Windows.Forms.TextBox();
            this.NIPBox = new System.Windows.Forms.TextBox();
            this.KRSBox = new System.Windows.Forms.TextBox();
            this.RegonLabel = new System.Windows.Forms.Label();
            this.NIPLabel = new System.Windows.Forms.Label();
            this.KRSLabel = new System.Windows.Forms.Label();
            this.raportyPelne = new System.Windows.Forms.ComboBox();
            this.raportyZbiorcze = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.DataRaportPicker = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EndOfWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPCJEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckStanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // raportRodzBox
            // 
            this.raportRodzBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raportRodzBox.FormattingEnabled = true;
            this.raportRodzBox.Items.AddRange(new object[] {
            "SzukajPodmioty",
            "PelnyRaportResponse",
            "PobierzRaportZbiorczy"});
            this.raportRodzBox.Location = new System.Drawing.Point(314, 136);
            this.raportRodzBox.Name = "raportRodzBox";
            this.raportRodzBox.Size = new System.Drawing.Size(229, 23);
            this.raportRodzBox.TabIndex = 0;
            this.raportRodzBox.SelectedIndexChanged += new System.EventHandler(this.raportRodzBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rodzaj raportu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wybierz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegonBox
            // 
            this.RegonBox.Location = new System.Drawing.Point(314, 200);
            this.RegonBox.Name = "RegonBox";
            this.RegonBox.Size = new System.Drawing.Size(229, 23);
            this.RegonBox.TabIndex = 3;
            // 
            // NIPBox
            // 
            this.NIPBox.Location = new System.Drawing.Point(314, 261);
            this.NIPBox.Name = "NIPBox";
            this.NIPBox.Size = new System.Drawing.Size(229, 23);
            this.NIPBox.TabIndex = 4;
            // 
            // KRSBox
            // 
            this.KRSBox.Location = new System.Drawing.Point(314, 314);
            this.KRSBox.Name = "KRSBox";
            this.KRSBox.Size = new System.Drawing.Size(229, 23);
            this.KRSBox.TabIndex = 5;
            // 
            // RegonLabel
            // 
            this.RegonLabel.AutoSize = true;
            this.RegonLabel.Location = new System.Drawing.Point(314, 182);
            this.RegonLabel.Name = "RegonLabel";
            this.RegonLabel.Size = new System.Drawing.Size(46, 15);
            this.RegonLabel.TabIndex = 6;
            this.RegonLabel.Text = "REGON";
            // 
            // NIPLabel
            // 
            this.NIPLabel.AutoSize = true;
            this.NIPLabel.Location = new System.Drawing.Point(314, 243);
            this.NIPLabel.Name = "NIPLabel";
            this.NIPLabel.Size = new System.Drawing.Size(26, 15);
            this.NIPLabel.TabIndex = 7;
            this.NIPLabel.Text = "NIP";
            // 
            // KRSLabel
            // 
            this.KRSLabel.AutoSize = true;
            this.KRSLabel.Location = new System.Drawing.Point(314, 296);
            this.KRSLabel.Name = "KRSLabel";
            this.KRSLabel.Size = new System.Drawing.Size(27, 15);
            this.KRSLabel.TabIndex = 8;
            this.KRSLabel.Text = "KRS";
            // 
            // raportyPelne
            // 
            this.raportyPelne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raportyPelne.FormattingEnabled = true;
            this.raportyPelne.Items.AddRange(new object[] {
            "BIR11OsFizycznaDaneOgolne",
            "BIR11OsFizycznaDzialalnoscCeidg",
            "BIR11OsFizycznaDzialalnoscRolnicza",
            "BIR11OsFizycznaDzialalnoscPozostala",
            "BIR11OsFizycznaDzialalnoscSkreslonaDo20141108",
            "BIR11OsFizycznaPkd",
            "BIR11OsFizycznaListaJednLokalnych",
            "BIR11JednLokalnaOsFizycznej",
            "BIR11JednLokalnaOsFizycznejPkd",
            "BIR11OsPrawna",
            "BIR11OsPrawnaPkd",
            "BIR11OsPrawnaListaJednLokalnych",
            "BIR11JednLokalnaOsPrawnej",
            "BIR11JednLokalnaOsPrawnejPkd",
            "BIR11OsPrawnaSpCywilnaWspolnicy",
            "BIR11TypPodmiotu"});
            this.raportyPelne.Location = new System.Drawing.Point(549, 261);
            this.raportyPelne.Name = "raportyPelne";
            this.raportyPelne.Size = new System.Drawing.Size(229, 23);
            this.raportyPelne.TabIndex = 9;
            this.raportyPelne.Visible = false;
            // 
            // raportyZbiorcze
            // 
            this.raportyZbiorcze.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raportyZbiorcze.FormattingEnabled = true;
            this.raportyZbiorcze.Items.AddRange(new object[] {
            "BIR11NowePodmiotyPrawneOrazDzialalnosciOsFizycznych",
            "BIR11AktualizowanePodmiotyPrawneOrazDzialalnosciOsFizycznych",
            "BIR11SkreslonePodmiotyPrawneOrazDzialalnosciOsFizycznych",
            "BIR11NoweJednostkiLokalne",
            "BIR11AktualizowaneJednostkiLokalne",
            "BIR11JednostkiLokalneSkreslone"});
            this.raportyZbiorcze.Location = new System.Drawing.Point(79, 261);
            this.raportyZbiorcze.Name = "raportyZbiorcze";
            this.raportyZbiorcze.Size = new System.Drawing.Size(229, 23);
            this.raportyZbiorcze.TabIndex = 10;
            this.raportyZbiorcze.Visible = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 200);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // DataRaportPicker
            // 
            this.DataRaportPicker.Location = new System.Drawing.Point(549, 200);
            this.DataRaportPicker.Name = "DataRaportPicker";
            this.DataRaportPicker.ReadOnly = true;
            this.DataRaportPicker.Size = new System.Drawing.Size(229, 23);
            this.DataRaportPicker.TabIndex = 12;
            this.DataRaportPicker.Visible = false;
            this.DataRaportPicker.Click += new System.EventHandler(this.DataRaportPicker_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EndOfWorkToolStripMenuItem,
            this.oPCJEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // EndOfWorkToolStripMenuItem
            // 
            this.EndOfWorkToolStripMenuItem.Name = "EndOfWorkToolStripMenuItem";
            this.EndOfWorkToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.EndOfWorkToolStripMenuItem.Text = "KONIEC PRACY";
            this.EndOfWorkToolStripMenuItem.Click += new System.EventHandler(this.EndOfWorkToolStripMenuItem_Click);
            // 
            // oPCJEToolStripMenuItem
            // 
            this.oPCJEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeDBToolStripMenuItem,
            this.CheckStanToolStripMenuItem});
            this.oPCJEToolStripMenuItem.Name = "oPCJEToolStripMenuItem";
            this.oPCJEToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.oPCJEToolStripMenuItem.Text = "OPCJE";
            // 
            // ChangeDBToolStripMenuItem
            // 
            this.ChangeDBToolStripMenuItem.Name = "ChangeDBToolStripMenuItem";
            this.ChangeDBToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ChangeDBToolStripMenuItem.Text = "Zmień bazę";
            this.ChangeDBToolStripMenuItem.Click += new System.EventHandler(this.ChangeDBToolStripMenuItem_Click);
            // 
            // CheckStanToolStripMenuItem
            // 
            this.CheckStanToolStripMenuItem.Name = "CheckStanToolStripMenuItem";
            this.CheckStanToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.CheckStanToolStripMenuItem.Text = "Sprawdź stan";
            this.CheckStanToolStripMenuItem.Click += new System.EventHandler(this.CheckStanToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataRaportPicker);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.raportyZbiorcze);
            this.Controls.Add(this.raportyPelne);
            this.Controls.Add(this.KRSLabel);
            this.Controls.Add(this.NIPLabel);
            this.Controls.Add(this.RegonLabel);
            this.Controls.Add(this.KRSBox);
            this.Controls.Add(this.NIPBox);
            this.Controls.Add(this.RegonBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.raportRodzBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Strona główna";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox raportRodzBox;
        private Label label1;
        private Button button1;
        private TextBox RegonBox;
        private TextBox NIPBox;
        private TextBox KRSBox;
        private Label RegonLabel;
        private Label NIPLabel;
        private Label KRSLabel;
        private ComboBox raportyPelne;
        private ComboBox raportyZbiorcze;
        private MonthCalendar monthCalendar1;
        private TextBox DataRaportPicker;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EndOfWorkToolStripMenuItem;
        private ToolStripMenuItem oPCJEToolStripMenuItem;
        private ToolStripMenuItem ChangeDBToolStripMenuItem;
        private ToolStripMenuItem CheckStanToolStripMenuItem;
    }
}