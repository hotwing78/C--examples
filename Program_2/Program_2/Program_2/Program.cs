using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Program_2
{
    class Program
    {
        //using to sort list order by DesiredWeek
        public class SortOrderByDesiredWeek : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((Order)x).DesiredShipWeek.CompareTo(((Order)y).DesiredShipWeek);
            }
        }
        //using to find order by ID
        public class SortOrderByOrderID : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((Order)x).CustID.CompareTo(((Order)y).CustID);
            }
        }

        static void Main(string[] args)
        {
            List<Customer> listCustomer = new List<Customer>();
            Queue<Order> listOrders = new Queue<Order>();
            Queue<Item> listItems = new Queue<Item>();
            ArrayList arrOrders = new ArrayList();

            const string f1 = @"customers.csv";
            const string f2 = @"orders-b.csv";
            // Use using StreamReader for disposing.
            //read the file customer.csv
            using (StreamReader r = new StreamReader(f1))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] lineItem = line.Split(',');                    
                    Customer Cust = new Customer(lineItem[0], lineItem[1], int.Parse(lineItem[2]));
                    listCustomer.Add(Cust);
                }
            }
            //Sorted listCustomer by ID
            listCustomer.Sort();
                        
            //read the file orders.csv
            using (StreamReader r2 = new StreamReader(f2))
            {
                string line;
                while ((line = r2.ReadLine()) != null)
                {
                    string Cust_ID;
                    string Oder_ID;
                    string Item_ID;
                    int orderWeek = 0;
                    string[] lineItem = line.Split(',');
                    Oder_ID = lineItem[0];
                    Cust_ID = lineItem[1];
                    Item_ID = lineItem[2];
                    orderWeek = int.Parse(lineItem[3]);
                    
                    Customer f_cust = new Customer(Cust_ID, "", 0);
                    int index = listCustomer.BinarySearch(f_cust);
                    if (index < 0)
                    {
                        Console.WriteLine("The customer ID {0} not found in the list of Customers!", Cust_ID);
                    }
                    else
                    {
                        Customer cust_temp = (Customer)listCustomer[index];
                        
                        //Item
                        Item item = new Item();
                        item.ItemNumber = Item_ID;
                        item.EstimatedShipWeek = 6 + orderWeek;
                        item.DesiredShipWeek = item.EstimatedShipWeek - cust_temp.CustLoyaltyLevel;
                        listItems.Enqueue(item);

                        //Order
                        Order order = new Order();
                        order.CustID = Cust_ID;
                        order.OrderID = Oder_ID;
                        order.DesiredShipWeek = 6 + orderWeek - cust_temp.CustLoyaltyLevel;
                        //int orderIndex = arrOrders.BinarySearch(order, new SortOrderByOrderID());
                        int orderIndex = -1;
                        for (int i = 0; i < arrOrders.Count; i++)
                        {
                            if (Oder_ID == ((Order)arrOrders[i]).OrderID)
                            {
                                orderIndex = i;
                                break;
                            }
                        }
                        if (orderIndex < 0)
                        {
                            order.ListProductID.Add(Item_ID);
                            arrOrders.Add(order);
                        }
                        else                        
                            ((Order)arrOrders[orderIndex]).ListProductID.Add(Item_ID);                        

                        //Add Order information to Customer object
                        if (cust_temp.ListOrders.Count <= 0)                        
                            cust_temp.ListOrders.Add(Oder_ID);                                                    
                        else
                        {
                            int id = cust_temp.ListOrders.BinarySearch(Oder_ID);
                            if (id < 0)                            
                                cust_temp.ListOrders.Add(Oder_ID);                                                            
                        }
                        //Add Item information to Customer object
                        if (cust_temp.ListItems.Count <= 0)                       
                            cust_temp.ListItems.Add(Item_ID);                      
                        else
                        {
                            int id = cust_temp.ListItems.BinarySearch(Item_ID);
                            if (id < 0)                           
                                cust_temp.ListItems.Add(Item_ID);                           
                        }
                        listCustomer[index] = cust_temp;
                    }
                }

                //Sort listOrder by DesiredShipWeek before insert to Queue
                arrOrders.Sort(new SortOrderByDesiredWeek());
                foreach (Order order in arrOrders)
                    listOrders.Enqueue(order);

                Console.WriteLine("Process list orders");
                Console.WriteLine("Customer Name,    Order ID  , Customer ID   , Ship Week");
               
                //OUTPUT
                Queue<Order> pendingOrder = new Queue<Order>();
                while (listOrders.Count > 0)
                {
                    Order order = listOrders.Peek();
                    if(CheckProductInInventory(order))
                    {
                        //remove order from listOrder
                        listOrders.Dequeue();
                        
                        int indexCust = listCustomer.BinarySearch(new Customer(order.CustID, "", 0));
                        Customer cust = listCustomer[indexCust];
                        Console.WriteLine("{0}   ,{1}   ,{2},   {3}", cust.CustName, order.OrderID, cust.CustID, cust.CustLoyaltyLevel);

                        //remove product in inventory
                        //.....
                    }
                    else
                        pendingOrder.Enqueue(order);

                    Console.ReadKey();
                }

                //processing pending order
                Console.WriteLine("Process list pending orders");
                while (pendingOrder.Count > 0)
                {
                    Order order = pendingOrder.Peek();
                    if (CheckProductInInventory(order))
                    {
                        //remove order from listOrder
                        pendingOrder.Dequeue();


                        int indexCust = listCustomer.BinarySearch(new Customer(order.CustID, "", 0));
                        Customer cust = listCustomer[indexCust];
                        Console.WriteLine("{0}   ,{1}   ,{2},   {3}", cust.CustName, order.OrderID, cust.CustID, cust.CustLoyaltyLevel);

                        //remove product in inventory
                        //.....
                    }
                    
                    Console.ReadKey();
                }
            }
        }

        private static bool CheckProductInInventory(Order order)
        {
            bool isEnough = true;
            //check here
            //.....

            return isEnough;
        }
    }
}
