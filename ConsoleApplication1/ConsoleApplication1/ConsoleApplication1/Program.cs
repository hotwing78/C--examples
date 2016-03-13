using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{
    class Customer
    {
        //Contructor for Customer class
        public Customer(string Cust_ID, string Cust_Name, int Cust_LoyaltyLevel)
        {
            CustomerID = Cust_ID;
            setCustomerName(Cust_Name);
            setCustomerLoyaltyLevel(Cust_LoyaltyLevel);
            numItems = 0;
            numOrders = 0;
            lisOrders = new ArrayList();
            listItems = new ArrayList();
        }
        //get Customer ID, not change the CustomerID
        readonly string CustomerID;
        public string getCustomerID()
        {
            return CustomerID;
        }
        //get and set Customer Name
        private string CustomerName;
        public string getCustomerName()
        {
            return CustomerName;
        }
        private void setCustomerName(string Cus_Name)
        {
            CustomerName = Cus_Name;
        }
        //get and set Customer Loyalty Level
        private int CustomerLoyaltyLevel;
        public int getCustomerLoyaltyLevel()
        {
            return CustomerLoyaltyLevel;
        }
        private void setCustomerLoyaltyLevel(int Cus_Level)
        {
            CustomerLoyaltyLevel = Cus_Level;
        }
        //count number of orders of customer
        int _numOrders;
        public int numOrders
        {
            get { return this._numOrders; }
            set { this._numOrders = value; }
        }
        //count number Item of customer
        int _numItems;
        public int numItems
        {
            get { return this._numItems; }
            set { this._numItems = value; }
        }
        //list Orders
        ArrayList _listOrders;
        public ArrayList lisOrders
        {
            get { return this._listOrders; }
            set { this._listOrders = value; }
        }
        //list Items
        ArrayList _listItems;
        public ArrayList listItems
        {
            get { return this._listItems; }
            set { this._listItems = value; }
        }
    }
    //using to sort list customer by Name
    public class SortCustomerName : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((Customer)x).getCustomerName().CompareTo(((Customer)y).getCustomerName());
        }
    }
    //using to find customer by ID
    public class SortCustomerByID : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((Customer)x).getCustomerID().CompareTo(((Customer)y).getCustomerID());
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList listCustomer = new ArrayList();
            const string f1 = @"C:\cpt-244\customer.csv";
            const string f2 = @"C:\cpt-244\orders.csv";
            // Use using StreamReader for disposing.
            //read the file customer.csv
            using (StreamReader r = new StreamReader(f1))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {       
                    string[] lineItem = line.Split(',');
                   // Console.WriteLine("{0}", line);
                    Customer Cust = new Customer(lineItem[0],lineItem[1], int.Parse(lineItem[2]));
                    listCustomer.Add(Cust);
                }
            }
            //Sorted listCustomer by ID
            listCustomer.Sort(new SortCustomerByID());
            
            //read the file orders.csv
            using (StreamReader r2 = new StreamReader(f2))
            {
                string line;
                while ((line = r2.ReadLine()) != null)
                {
                    string Cust_ID;
                    string Oder_ID;
                    string Item_ID;
                    string[] lineItem = line.Split(',');
                    Oder_ID = lineItem[0];
                    Cust_ID = lineItem[1];
                    Item_ID = lineItem[2];
                    Customer f_cust = new Customer(Cust_ID,"",0);
                    int index = listCustomer.BinarySearch(f_cust, new SortCustomerByID());
                    if (index < 0)
                    {
                        Console.WriteLine("The customer ID {0} not found in the list of Customer!", Cust_ID);
                    }
                    else
                    {
                        Customer cust_temp = (Customer)listCustomer[index];
                        if (cust_temp.lisOrders.Count <= 0)
                        {
                            cust_temp.lisOrders.Add(Oder_ID);
                            cust_temp.numOrders++;
                        }
                        else
                        {
                            int id= cust_temp.lisOrders.BinarySearch(Oder_ID);
                            if (id < 0)
                            {
                                cust_temp.lisOrders.Add(Oder_ID);
                                cust_temp.numOrders++;
                            }
                        }

                        if (cust_temp.listItems.Count <= 0)
                        {
                            cust_temp.listItems.Add(Item_ID);
                            cust_temp.numItems++;
                        }
                        else
                        {
                            int id = cust_temp.listItems.BinarySearch(Item_ID);
                            if (id < 0)
                            {
                                cust_temp.listItems.Add(Item_ID);
                                cust_temp.numItems++;
                            }
                        }
                        listCustomer[index] = cust_temp;
                        
                    }
                }

                //Sorted listCustomer by Name
                listCustomer.Sort(new SortCustomerName());
                Console.WriteLine("Customer  , Orders   , Items");
                foreach (Customer cust in listCustomer)
                {
                    Console.WriteLine("{0},{1},{2}", cust.getCustomerName(),cust.numOrders,cust.numItems);
                }
            }
        }
    }

    
}
