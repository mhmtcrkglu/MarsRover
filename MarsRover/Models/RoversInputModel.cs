using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class RoversInputModel
    {
        public string Plateau { get; set; }
        public List<RoverInputModel> RoversInput { get; set; }
    }

    public class RoverInputModel
    {
        public int Index { get; set; }
        public string Position { get; set; }
        public string Route { get; set; }

    }
}
