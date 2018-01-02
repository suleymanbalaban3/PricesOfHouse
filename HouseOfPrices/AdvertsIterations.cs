using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseOfPrices
{
    public class AdvertsIterations
    {
        private static int Id;

        public AdvertsIterations()
        {
            Id = 0;
        }
        public AdvertsIterations(int ID)
        {
            Id = ID;
        }
        public AdvertsIterations(int ID, int ID2)
        {
            
        }
        public int Id1
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}