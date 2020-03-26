using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House4uClient.Models
{
    public enum LeaseType
    {
        Managed, FullyDelagated
    }

    public class Property
    {
        public int ID { get; set; }

        public string Address { get; set; }
        public int NoBedrooms { get; set; }
        public LeaseType LType { get; set; }

        //private string email;
        public string Email { get; set; }

        //private DateTime expiryDate;
        public DateTime ExpiryDate { get; set; }

        public override string ToString()
        {
            return "\nID: " + ID + "\nAddress: " + Address + "\nNumber of Bedrooms: " + NoBedrooms + "\nLease Type: " + LType + "\nEmail: " + Email + "\nExpiry Date: " + ExpiryDate;
        }

    }
}

