using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class RoverModel
    {
        public int Id { get; set; }
        public PlateauModel Plateau { get; set; }
        public RoverPositionModel Position { get; set; }
        public RoverRouteModel Route { get; set; }
    }
}
