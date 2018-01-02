using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseOfPrices
{
    public class House
    {
        public House() { }
        public House(double CoordinateX, double CoordinateY, int RoomNumber, int LivingRoomNumber, int FloorNumber,
            int SquareMeter, int Age, double Heating, int ProximityToTransportation, int RequestedPrice)
        {
            
            this.CoordinateX = CoordinateX;
            this.CoordinateY = CoordinateY;
            this.RoomNumber = RoomNumber;
            this.LivingRoomNumber = LivingRoomNumber;
            this.FloorNumber = FloorNumber;
            this.SquareMeter = SquareMeter;
            this.Age = Age;
            this.Heating = Heating;
            this.ProximityToTransportation = ProximityToTransportation;            
            this.RequestedPrice = RequestedPrice;
        }
        
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public int RoomNumber { get; set; }
        public int LivingRoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int SquareMeter { get; set; }
        public int Age { get; set; }
        public double Heating { get; set; }
        public int ProximityToTransportation { get; set; }
        public int RequestedPrice { get; set; }
    }
}