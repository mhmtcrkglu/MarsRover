using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Linq;

namespace MarsRover
{
    public class Operations
    {
        //Apply next action for rover
        public static RoverModel Apply(RoverModel rover)
        {
            switch (rover.Route.Movements.FirstOrDefault())
            {
                case MovementEnum.L:
                    rover = TurnLeftRover(rover);
                    break;

                case MovementEnum.R:
                    rover = TurnRightRover(rover);
                    break;

                case MovementEnum.M:
                    rover = MoveRover(rover);
                    break;

                default:
                    return null;
            }

            return rover;
        }

        //Change direction; Turn Right 90 degrees
        private static RoverModel TurnRightRover(RoverModel rover)
        {
            rover.Position.Direction = (rover.Position.Direction + 1) > DirectionEnum.W ? DirectionEnum.N : rover.Position.Direction + 1;
            return rover;
        }

        //Change direction; Turn Left 90 degrees
        private static RoverModel TurnLeftRover(RoverModel rover)
        {
            rover.Position.Direction = (rover.Position.Direction - 1) < DirectionEnum.N ? DirectionEnum.W : rover.Position.Direction - 1;
            return rover;
        }
        
        //Move 1 unit to the selected direction
        private static RoverModel MoveRover(RoverModel rover)
        {
            var cloneRover = rover;

            switch (rover.Position.Direction)
            {
                case DirectionEnum.N:
                    rover.Position.PositionY++;
                    break;

                case DirectionEnum.S:
                    rover.Position.PositionY--;
                    break;
                case DirectionEnum.W:
                    rover.Position.PositionX--;
                    break;

                case DirectionEnum.E:
                    rover.Position.PositionX++;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            if (!CheckRoverPosition(rover))
            {
                return cloneRover;
            }

            return rover;
        }
        
        //Rover in the plateau checker
        private static bool CheckRoverPosition(RoverModel rover)
        {
            return rover.Position.PositionX <= rover.Plateau.SizeOfX && 
                   rover.Position.PositionX >= 0 && 
                   rover.Position.PositionY <= rover.Plateau.SizeOfY && 
                   rover.Position.PositionY >= 0;
        }
    }
}
