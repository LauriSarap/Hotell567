using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotell567.Logic
{
    public class RoomFactory
    {
        public RoomFactory()
        {
            Debug.WriteLine("RoomFactory connector created");
        }

        public bool IsValidDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return false;
            }

            return true;
        }

        public bool IsPriceValid(string price)
        {
            if (decimal.TryParse(price, out decimal priceAsDecimal))
            {
                if (priceAsDecimal > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
