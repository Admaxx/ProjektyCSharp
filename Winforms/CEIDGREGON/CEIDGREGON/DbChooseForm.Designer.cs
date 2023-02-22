namespace CEIDGREGON
{
    partial class DbChooseForm
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
            this.DbBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnTest = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DbBox
            // 
            this.DbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DbBox.FormattingEnabled = true;
            this.DbBox.Location = new System.Drawing.Point(325, 152);
            this.DbBox.Name = "DbBox";
            this.DbBox.Size = new System.Drawing.Size(200, 23);
            this.DbBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybierz bazę";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(325, 229);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(200, 23);
            this.LoginBox.TabIndex = 2;
            this.LoginBox.Text = "sa";
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(325, 273);
            this.PassBox.Name = "PassBox";
            this.PassBox.PasswordChar = '*';
            this.PassBox.Size = new System.Drawing.Size(200, 23);
            this.PassBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hasło";
            // 
            // btnConnTest
            // 
            this.btnConnTest.Location = new System.Drawing.Point(531, 152);
            this.btnConnTest.Name = "btnConnTest";
            this.btnConnTest.Size = new System.Drawing.Size(108, 23);
            this.btnConnTest.TabIndex = 6;
            this.btnConnTest.Text = "Testuj połączenie";
            this.btnConnTest.UseVisualStyleBackColor = true;
            this.btnConnTest.Click += new System.EventHandler(this.btnConnTest_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(450, 302);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "Wybierz";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(325, 302);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 8;
            this.btnAbort.Text = "Anuluj";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // DbChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnConnTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DbBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbChooseForm";
            this.Text = "Baza";
            this.Load += new System.EventHandler(this.DbChoose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox DbBox;
        private Label label1;
        private TextBox LoginBox;
        private TextBox PassBox;
        private Label label2;
        private Label label3;
        private Button btnConnTest;
        private Button btnChoose;
        private Button btnAbort;
    }
}