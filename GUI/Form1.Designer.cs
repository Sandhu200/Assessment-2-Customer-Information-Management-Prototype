namespace GUI
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_DEPOSIT = new System.Windows.Forms.Button();
            this.comboBox_ACCOUNT = new System.Windows.Forms.ComboBox();
            this.textBox_AMOUNT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_WITHDRAW = new System.Windows.Forms.Button();
            this.button_INFO = new System.Windows.Forms.Button();
            this.button_INTEREST = new System.Windows.Forms.Button();
            this.checkBox_STAFF = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(294, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(494, 394);
            this.listBox1.TabIndex = 0;
            // 
            // button_DEPOSIT
            // 
            this.button_DEPOSIT.Location = new System.Drawing.Point(12, 226);
            this.button_DEPOSIT.Name = "button_DEPOSIT";
            this.button_DEPOSIT.Size = new System.Drawing.Size(113, 23);
            this.button_DEPOSIT.TabIndex = 1;
            this.button_DEPOSIT.Text = "Deposit";
            this.button_DEPOSIT.UseVisualStyleBackColor = true;
            this.button_DEPOSIT.Click += new System.EventHandler(this.button_DEPOSIT_Click);
            // 
            // comboBox_ACCOUNT
            // 
            this.comboBox_ACCOUNT.FormattingEnabled = true;
            this.comboBox_ACCOUNT.Location = new System.Drawing.Point(12, 39);
            this.comboBox_ACCOUNT.Name = "comboBox_ACCOUNT";
            this.comboBox_ACCOUNT.Size = new System.Drawing.Size(201, 21);
            this.comboBox_ACCOUNT.TabIndex = 2;
            // 
            // textBox_AMOUNT
            // 
            this.textBox_AMOUNT.Location = new System.Drawing.Point(12, 116);
            this.textBox_AMOUNT.Name = "textBox_AMOUNT";
            this.textBox_AMOUNT.Size = new System.Drawing.Size(201, 20);
            this.textBox_AMOUNT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Account :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter Amount :";
            // 
            // button_WITHDRAW
            // 
            this.button_WITHDRAW.Location = new System.Drawing.Point(152, 226);
            this.button_WITHDRAW.Name = "button_WITHDRAW";
            this.button_WITHDRAW.Size = new System.Drawing.Size(113, 23);
            this.button_WITHDRAW.TabIndex = 6;
            this.button_WITHDRAW.Text = "Withdraw";
            this.button_WITHDRAW.UseVisualStyleBackColor = true;
            this.button_WITHDRAW.Click += new System.EventHandler(this.button_WITHDRAW_Click);
            // 
            // button_INFO
            // 
            this.button_INFO.Location = new System.Drawing.Point(12, 282);
            this.button_INFO.Name = "button_INFO";
            this.button_INFO.Size = new System.Drawing.Size(113, 23);
            this.button_INFO.TabIndex = 7;
            this.button_INFO.Text = "Show Info";
            this.button_INFO.UseVisualStyleBackColor = true;
            this.button_INFO.Click += new System.EventHandler(this.button_INFO_Click);
            // 
            // button_INTEREST
            // 
            this.button_INTEREST.Location = new System.Drawing.Point(152, 282);
            this.button_INTEREST.Name = "button_INTEREST";
            this.button_INTEREST.Size = new System.Drawing.Size(113, 23);
            this.button_INTEREST.TabIndex = 8;
            this.button_INTEREST.Text = "Calculate Interest";
            this.button_INTEREST.UseVisualStyleBackColor = true;
            this.button_INTEREST.Click += new System.EventHandler(this.button_INTEREST_Click);
            // 
            // checkBox_STAFF
            // 
            this.checkBox_STAFF.AutoSize = true;
            this.checkBox_STAFF.Location = new System.Drawing.Point(15, 164);
            this.checkBox_STAFF.Name = "checkBox_STAFF";
            this.checkBox_STAFF.Size = new System.Drawing.Size(94, 17);
            this.checkBox_STAFF.TabIndex = 9;
            this.checkBox_STAFF.Text = "Is Staff Member";
            this.checkBox_STAFF.UseVisualStyleBackColor = true;
            this.checkBox_STAFF.CheckedChanged += new System.EventHandler(this.checkBox_STAFF_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox_STAFF);
            this.Controls.Add(this.button_INTEREST);
            this.Controls.Add(this.button_INFO);
            this.Controls.Add(this.button_WITHDRAW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_AMOUNT);
            this.Controls.Add(this.comboBox_ACCOUNT);
            this.Controls.Add(this.button_DEPOSIT);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Bank Account Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_DEPOSIT;
        private System.Windows.Forms.ComboBox comboBox_ACCOUNT;
        private System.Windows.Forms.TextBox textBox_AMOUNT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_WITHDRAW;
        private System.Windows.Forms.Button button_INFO;
        private System.Windows.Forms.Button button_INTEREST;
        private System.Windows.Forms.CheckBox checkBox_STAFF;
    }
}

