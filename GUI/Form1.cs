using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Customer customer;
        private EverydayAccount everyday;
        private InvestmentAccount investment;
        private OmniAccount omni;
        private CustomerController _customerController;

        public Form1()
        {
            InitializeComponent();
            _customerController = new CustomerController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create accounts
            everyday = new EverydayAccount(101, 500);
            investment = new InvestmentAccount(102, 1000, 0.05, 20);
            omni = new OmniAccount(103, 2000, 0.04, 200, 10);

            // Populate combo boxes
            RefreshCustomerComboBox();

            comboBox_ACCOUNT.Items.Add("Everyday");
            comboBox_ACCOUNT.Items.Add("Investment");
            comboBox_ACCOUNT.Items.Add("Omni");
            comboBox_ACCOUNT.SelectedIndex = 0;
        }

        private void RefreshCustomerComboBox()
        {
            comboBox_CUSTOMER.Items.Clear();
            List<Customer> customers = _customerController.GetAll();
            
            foreach (Customer c in customers)
            {
                comboBox_CUSTOMER.Items.Add(c.CustomerNumber + ": " + c.Name);
            }
            
            if (comboBox_CUSTOMER.Items.Count > 0)
            {
                comboBox_CUSTOMER.SelectedIndex = 0;
            }
        }

        private void comboBox_CUSTOMER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_CUSTOMER.SelectedItem != null)
            {
                string selectedText = comboBox_CUSTOMER.SelectedItem.ToString();
                string[] parts = selectedText.Split(':');
                int id = int.Parse(parts[0]);
                
                customer = _customerController.FindById(id);
                if (customer != null)
                {
                    checkBox_STAFF.Checked = customer.IsStaff;
                }
            }
        }

        private Account GetSelectedAccount()
        {
            string selectedAccountName = comboBox_ACCOUNT.SelectedItem.ToString();

            if (selectedAccountName == "Everyday")
            {
                return everyday;
            }
            else if (selectedAccountName == "Investment")
            {
                return investment;
            }
            else if (selectedAccountName == "Omni")
            {
                return omni;
            }
            else
            {
                return null;
            }
        }

        private void button_DEPOSIT_Click(object sender, EventArgs e)
        {
            double amount;
            bool isAmountValid = double.TryParse(textBox_AMOUNT.Text, out amount);

            if (isAmountValid)
            {
                Account selectedAccount = GetSelectedAccount();
                selectedAccount.Deposit(amount);
                listBox1.Items.Add($"{selectedAccount.GetType().Name} {selectedAccount.ID}; Deposit: ${amount}; New Balance: ${selectedAccount.Balance}");
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void button_WITHDRAW_Click(object sender, EventArgs e)
        {
            double amount;
            bool isAmountValid = double.TryParse(textBox_AMOUNT.Text, out amount);

            if (isAmountValid)
            {
                Account selectedAccount = GetSelectedAccount();
                listBox1.Items.Add(selectedAccount.Withdraw(amount, customer));
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void button_INFO_Click(object sender, EventArgs e)
        {
            Account selectedAccount = GetSelectedAccount();
            listBox1.Items.Add(selectedAccount.ToString());
        }

        private void button_INTEREST_Click(object sender, EventArgs e)
        {
            Account selectedAccount = GetSelectedAccount();
            listBox1.Items.Add(selectedAccount.CalculateInterest());
        }

        private void button_CUSTOMERS_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(_customerController);
            customerForm.ShowDialog();
            RefreshCustomerComboBox();
        }

        private void checkBox_STAFF_CheckedChanged(object sender, EventArgs e)
        {
            customer.IsStaff = checkBox_STAFF.Checked;
        }
    }
}
