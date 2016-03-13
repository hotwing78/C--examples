

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Program_2
{
    class Order //: IEquatable<Order>, IComparable<Order>
    {
        string custID = "";
        string orderID = "";
        int desiredShipWeek = 0;
        ArrayList listProductID = new ArrayList();

        public string CustID
        {
            get { return custID; }
            set { custID = value; }
        }

        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public int DesiredShipWeek
        {
            get { return desiredShipWeek; }
            set { desiredShipWeek = value; }
        }

        public ArrayList ListProductID
        {
            get { return listProductID; }
            set { listProductID = value; }
        }

        /*public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Order order = obj as Order;
            if (order == null) return false;
            else return Equals(order);
        }

        public int CompareTo(Order compareOrder)
        {
            // A null value means that this object is greater. 
            if (compareOrder == null)
                return 1;

            else
                return this.DesiredShipWeek.CompareTo(compareOrder.DesiredShipWeek);
        }

        public bool Equals(Order other)
        {
            if (other == null) return false;
            return (this.desiredShipWeek.Equals(other.DesiredShipWeek));
        }*/
    }
}
