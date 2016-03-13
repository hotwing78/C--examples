using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_2
{
    class Item
    {
        string itemNumber = "";
        int estimatedShipWeek = 0;
        int desiredShipWeek = 0;

        public string ItemNumber
        {
            get { return itemNumber; }
            set { itemNumber = value; }
        }

        public int EstimatedShipWeek
        {
            get { return estimatedShipWeek; }
            set { estimatedShipWeek = value; }
        }

        public int DesiredShipWeek
        {
            get { return desiredShipWeek; }
            set { desiredShipWeek = value; }
        }
    }
}
