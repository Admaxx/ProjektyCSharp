namespace CEIDGREGON
{
    partial class ProgramOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sprawdź";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ErrorBox.FormattingEnabled = true;
            this.ErrorBox.Items.AddRange(new object[] {
            "StanDanych",
            "KomunikatKod",
            "KomunikatTresc",
            "StatusSesji",
            "StatusUslugi",
            "KomunikatUslugi"});
            this.ErrorBox.Location = new System.Drawing.Point(181, 99);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(206, 23);
            this.ErrorBox.TabIndex = 1;
            // 
            // ProgramOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 264);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramOptions";
            this.Text = "ErrorHandling";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private ComboBox ErrorBox;
    }
}