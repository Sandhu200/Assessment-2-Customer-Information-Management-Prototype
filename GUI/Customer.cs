using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Customer
    {
        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public bool IsStaff { get; set; }

        public Customer(int customerNumber, string name, string contactDetails, bool isStaff)
        {
            CustomerNumber = customerNumber;
            Name = name;
            ContactDetails = contactDetails;
            IsStaff = isStaff;
        }
    }
}
