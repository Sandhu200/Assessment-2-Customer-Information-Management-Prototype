using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    // This is the View for our MVC customer management
    public partial class CustomerForm : Form
    {
        // Reference to the shared controller
        private CustomerController controller;

        public CustomerForm(CustomerController sharedController)
        {
            InitializeComponent();
            controller = sharedController;
            UpdateDisplay();
        }

        // Helper to refresh the list box with current data
        private void UpdateDisplay()
        {
            listBox_CUSTOMERS.Items.Clear();
            List<Customer> customers = controller.GetAll();
            
            foreach (Customer c in customers)
            {
                string info = c.CustomerNumber + ": " + c.Name + " (" + c.ContactDetails + ")";
                if (c.IsStaff) info += " [Staff]";
                listBox_CUSTOMERS.Items.Add(info);
            }
        }

        // Clear all the text boxes after an action
        private void ClearInputs()
        {
            textBox_ID.Text = "";
            textBox_NAME.Text = "";
            textBox_CONTACT.Text = "";
            checkBox_STAFF.Checked = false;
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox_ID.Text);
                string name = textBox_NAME.Text;
                string contact = textBox_CONTACT.Text;
                bool isStaff = checkBox_STAFF.Checked;

                controller.AddNewCustomer(id, name, contact, isStaff);
                UpdateDisplay();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        private void button_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox_ID.Text);
                string name = textBox_NAME.Text;
                string contact = textBox_CONTACT.Text;
                bool isStaff = checkBox_STAFF.Checked;

                controller.UpdateCustomer(id, name, contact, isStaff);
                UpdateDisplay();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        private void button_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_CUSTOMERS.SelectedItem != null)
                {
                    string selectedText = listBox_CUSTOMERS.SelectedItem.ToString();
                    string[] parts = selectedText.Split(':');
                    int id = int.Parse(parts[0]);
                    
                    controller.RemoveCustomer(id);
                    UpdateDisplay();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message);
            }
        }

        private void listBox_CUSTOMERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_CUSTOMERS.SelectedItem != null)
            {
                string selectedText = listBox_CUSTOMERS.SelectedItem.ToString();
                string[] parts = selectedText.Split(':');
                int id = int.Parse(parts[0]);

                Customer c = controller.FindById(id);
                if (c != null)
                {
                    textBox_ID.Text = c.CustomerNumber.ToString();
                    textBox_NAME.Text = c.Name;
                    textBox_CONTACT.Text = c.ContactDetails;
                    checkBox_STAFF.Checked = c.IsStaff;
                }
            }
        }

        private void button_BACK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
