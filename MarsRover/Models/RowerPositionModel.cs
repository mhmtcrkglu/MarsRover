using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class RoverPositionModel
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public DirectionEnum Direction { get; set; }

    }
}
