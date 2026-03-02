using System;
using System.Collections.Generic;

namespace GUI
{
    // This class handles the logic for managing customers (The Controller in MVC)
    public class CustomerController
    {
        // Internal list to store our customer data
        private List<Customer> customerList = new List<Customer>();

        public CustomerController()
        {
            // Adding some starting data so the app isn't empty
            customerList.Add(new Customer(1, "Talwinder Singh", "+62 123 4786", false));
            
        }

        // Method to get all customers for the UI
        public List<Customer> GetAll()
        {
            return customerList;
        }

        // Add a new customer to the list
        public void AddNewCustomer(int id, string name, string contact, bool isStaff)
        {
            Customer newCust = new Customer(id, name, contact, isStaff);
            customerList.Add(newCust);
        }

        // Update an existing customer's details
        public void UpdateCustomer(int id, string name, string contact, bool isStaff)
        {
            foreach (Customer c in customerList)
            {
                if (c.CustomerNumber == id)
                {
                    c.Name = name;
                    c.ContactDetails = contact;
                    c.IsStaff = isStaff;
                    break;
                }
            }
        }

        // Remove a customer by their ID
        public void RemoveCustomer(int id)
        {
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].CustomerNumber == id)
                {
                    customerList.RemoveAt(i);
                    break;
                }
            }
        }

        // Find a specific customer by ID
        public Customer FindById(int id)
        {
            foreach (Customer c in customerList)
            {
                if (c.CustomerNumber == id)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
