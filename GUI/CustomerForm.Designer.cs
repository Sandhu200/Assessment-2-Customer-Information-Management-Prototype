namespace GUI
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBox_CUSTOMERS = new System.Windows.Forms.ListBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_NAME = new System.Windows.Forms.TextBox();
            this.textBox_CONTACT = new System.Windows.Forms.TextBox();
            this.checkBox_STAFF = new System.Windows.Forms.CheckBox();
            this.button_ADD = new System.Windows.Forms.Button();
            this.button_UPDATE = new System.Windows.Forms.Button();
            this.button_DELETE = new System.Windows.Forms.Button();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_NAME = new System.Windows.Forms.Label();
            this.label_CONTACT = new System.Windows.Forms.Label();
            this.button_BACK = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listBox_CUSTOMERS
            this.listBox_CUSTOMERS.FormattingEnabled = true;
            this.listBox_CUSTOMERS.Location = new System.Drawing.Point(300, 20);
            this.listBox_CUSTOMERS.Name = "listBox_CUSTOMERS";
            this.listBox_CUSTOMERS.Size = new System.Drawing.Size(400, 300);
            this.listBox_CUSTOMERS.TabIndex = 0;
            this.listBox_CUSTOMERS.SelectedIndexChanged += new System.EventHandler(this.listBox_CUSTOMERS_SelectedIndexChanged);

            // textBox_ID
            this.textBox_ID.Location = new System.Drawing.Point(100, 20);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(150, 20);

            // textBox_NAME
            this.textBox_NAME.Location = new System.Drawing.Point(100, 60);
            this.textBox_NAME.Name = "textBox_NAME";
            this.textBox_NAME.Size = new System.Drawing.Size(150, 20);

            // textBox_CONTACT
            this.textBox_CONTACT.Location = new System.Drawing.Point(100, 100);
            this.textBox_CONTACT.Name = "textBox_CONTACT";
            this.textBox_CONTACT.Size = new System.Drawing.Size(150, 20);

            // checkBox_STAFF
            this.checkBox_STAFF.Location = new System.Drawing.Point(100, 140);
            this.checkBox_STAFF.Name = "checkBox_STAFF";
            this.checkBox_STAFF.Size = new System.Drawing.Size(150, 20);
            this.checkBox_STAFF.Text = "Is Staff";

            // button_ADD
            this.button_ADD.Location = new System.Drawing.Point(20, 180);
            this.button_ADD.Name = "button_ADD";
            this.button_ADD.Size = new System.Drawing.Size(75, 23);
            this.button_ADD.Text = "Add";
            this.button_ADD.Click += new System.EventHandler(this.button_ADD_Click);

            // button_UPDATE
            this.button_UPDATE.Location = new System.Drawing.Point(110, 180);
            this.button_UPDATE.Name = "button_UPDATE";
            this.button_UPDATE.Size = new System.Drawing.Size(75, 23);
            this.button_UPDATE.Text = "Update";
            this.button_UPDATE.Click += new System.EventHandler(this.button_UPDATE_Click);

            // button_DELETE
            this.button_DELETE.Location = new System.Drawing.Point(200, 180);
            this.button_DELETE.Name = "button_DELETE";
            this.button_DELETE.Size = new System.Drawing.Size(75, 23);
            this.button_DELETE.Text = "Delete";
            this.button_DELETE.Click += new System.EventHandler(this.button_DELETE_Click);

            // button_BACK
            this.button_BACK.Location = new System.Drawing.Point(20, 300);
            this.button_BACK.Name = "button_BACK";
            this.button_BACK.Size = new System.Drawing.Size(75, 23);
            this.button_BACK.Text = "Back";
            this.button_BACK.Click += new System.EventHandler(this.button_BACK_Click);

            // labels
            this.label_ID.Text = "ID:";
            this.label_ID.Location = new System.Drawing.Point(20, 20);
            this.label_NAME.Text = "Name:";
            this.label_NAME.Location = new System.Drawing.Point(20, 60);
            this.label_CONTACT.Text = "Contact:";
            this.label_CONTACT.Location = new System.Drawing.Point(20, 100);

            // CustomerForm
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.Controls.Add(this.listBox_CUSTOMERS);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_NAME);
            this.Controls.Add(this.textBox_CONTACT);
            this.Controls.Add(this.checkBox_STAFF);
            this.Controls.Add(this.button_ADD);
            this.Controls.Add(this.button_UPDATE);
            this.Controls.Add(this.button_DELETE);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.label_NAME);
            this.Controls.Add(this.label_CONTACT);
            this.Controls.Add(this.button_BACK);
            this.Name = "CustomerForm";
            this.Text = "Customer Management (MVC)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox listBox_CUSTOMERS;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_NAME;
        private System.Windows.Forms.TextBox textBox_CONTACT;
        private System.Windows.Forms.CheckBox checkBox_STAFF;
        private System.Windows.Forms.Button button_ADD;
        private System.Windows.Forms.Button button_UPDATE;
        private System.Windows.Forms.Button button_DELETE;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_NAME;
        private System.Windows.Forms.Label label_CONTACT;
        private System.Windows.Forms.Button button_BACK;
    }
}
