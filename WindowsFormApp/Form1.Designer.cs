namespace WindowsFormApp
{
    partial class Form1
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
            Grid1 = new DataGridView();
            label1 = new Label();
            txtUsername = new TextBox();
            txtFirstName = new TextBox();
            label2 = new Label();
            txtLastName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtAdres = new TextBox();
            label8 = new Label();
            button1 = new Button();
            dtDateOf = new DateTimePicker();
            comboBox1 = new ComboBox();
            button2 = new Button();
            LId = new Label();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            SuspendLayout();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.Location = new Point(27, 352);
            Grid1.Name = "Grid1";
            Grid1.ReadOnly = true;
            Grid1.RowTemplate.Height = 25;
            Grid1.Size = new Size(943, 307);
            Grid1.TabIndex = 0;
            Grid1.CellClick += Grid1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 66);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "User Name";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(165, 63);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(249, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(165, 90);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(249, 23);
            txtFirstName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 94);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(165, 117);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(249, 23);
            txtLastName.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 122);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 5;
            label3.Text = "Last Name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(165, 144);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(249, 23);
            txtEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 150);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(165, 171);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(249, 23);
            txtPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 178);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 9;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 206);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 11;
            label6.Text = "Dogum Tarihi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 262);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 13;
            label7.Text = "Adres";
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(165, 259);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(249, 23);
            txtAdres.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 234);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 15;
            label8.Text = "Cinsiyet";
            // 
            // button1
            // 
            button1.Location = new Point(164, 300);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "KAYDET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtDateOf
            // 
            dtDateOf.Location = new Point(164, 201);
            dtDateOf.Name = "dtDateOf";
            dtDateOf.Size = new Size(250, 23);
            dtDateOf.TabIndex = 18;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Erkek", "Kadın" });
            comboBox1.Location = new Point(165, 230);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(249, 23);
            comboBox1.TabIndex = 19;
            // 
            // button2
            // 
            button2.Location = new Point(339, 300);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "UPDATE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LId
            // 
            LId.AutoSize = true;
            LId.Location = new Point(26, 21);
            LId.Name = "LId";
            LId.Size = new Size(23, 15);
            LId.TabIndex = 21;
            LId.Text = "LId";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 681);
            Controls.Add(LId);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(dtDateOf);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAdres);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtUsername);
            Controls.Add(Grid1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Grid1;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtFirstName;
        private Label label2;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtAdres;
        private Label label8;
        private Button button1;
        private DateTimePicker dtDateOf;
        private ComboBox comboBox1;
        private Button button2;
        private Label LId;
    }
}