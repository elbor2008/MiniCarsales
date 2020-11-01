using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Dto
{
    public class CarReturnDto
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string VehicleType { get; set; }
        public string BodyType { get; set; }
    }
}
