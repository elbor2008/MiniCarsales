using MiniCarsales.Api.Models.Enum;
using MiniCarsales.Api.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Models
{
    public class Car : Vehicle
    {
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public VehicleType VehicleType { get; set; }
        public BodyType BodyType { get; set; }
    }
}
