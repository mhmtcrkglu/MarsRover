﻿using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Linq;

namespace MarsRover
{
    public class Operations
    {
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

        private static RoverModel TurnRightRover(RoverModel rover)
        {
            rover.Position.Direction = (rover.Position.Direction + 1) > DirectionEnum.W ? DirectionEnum.N : rover.Position.Direction + 1;
            return rover;
        }

        private static RoverModel TurnLeftRover(RoverModel rover)
        {
            rover.Position.Direction = (rover.Position.Direction - 1) < DirectionEnum.N ? DirectionEnum.W : rover.Position.Direction - 1;
            return rover;
        }

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

            if (!ChecRoverPosition(rover))
            {
                return cloneRover;
            }

            return rover;
        }

        private static bool ChecRoverPosition(RoverModel rover)
        {
            if (rover.Position.PositionX > rover.Plateau.SizeOfX || rover.Position.PositionX < 0 ||
                rover.Position.PositionY > rover.Plateau.SizeOfY || rover.Position.PositionY < 0)
            {
                return false;
            }

            return true;
        }
    }
}
