using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Program_2
{
    class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        string custID = "";
        string custName = "";
        int    custLoyaltyLevel = 0;
        ArrayList listOrders = new ArrayList();
        ArrayList listItems = new ArrayList();

        //Contructor for Customer class
        public Customer(string Cust_ID, string Cust_Name, int Cust_LoyaltyLevel)
        {
            this.custID = Cust_ID;
            this.custName = Cust_Name;
            this.custLoyaltyLevel = Cust_LoyaltyLevel;           
        }

        #region Properties
        public string CustID
        {
            get { return custID; }        
        }

        public string CustName
        {
            get { return custName; }
            set { custName = value; }
        }

        public int CustLoyaltyLevel
        {
            get { return custLoyaltyLevel; }
            set { custLoyaltyLevel = value; }
        }

        public ArrayList ListOrders
        {
            get { return listOrders; }
            set { listOrders = value; }
        }

        public ArrayList ListItems
        {
            get { return listItems; }
            set { listItems = value; }
        }
        #endregion

        //add removeOrder method
        public void RemoveOrders(object order)
        {
            listOrders.Remove(order);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Customer cust = obj as Customer;
            if (cust == null) return false;
            else return Equals(cust);
        }

        public int CompareTo(Customer compareCust)
        {
            // A null value means that this object is greater. 
            if (compareCust == null)
                return 1;

            else
                return this.custID.CompareTo(compareCust.CustID);
        }
        
        public bool Equals(Customer other)
        {
            if (other == null) return false;
            return (this.custID.Equals(other.CustID));
        }
    }
}
