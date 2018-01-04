using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseOfPrices
{
    public class MoneyTypeGenerator
    {
        public String getMoneyTypeNumber(String Number)
        {
            if (Number.Length < 4)
                return Number;
            for (int i = Number.Length-3; i > 0; i -= 3)
            {
                Number = Number.Substring(0, i) + "." + Number.Substring(i);
            }
            return Number;
        }
    }
}