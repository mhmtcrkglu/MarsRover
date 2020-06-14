using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Helpers
{
    public static class InputHelper
    {
        public static PlateauModel Plateau(string sizeOfPlateau)
        {
            var plateauArray = sizeOfPlateau.Split(" ");

            if (plateauArray.Length == 2) //checker
            {
                PlateauModel plateauModel = new PlateauModel()
                {
                    SizeOfX = int.Parse(plateauArray.First()),
                    SizeOfY = int.Parse(plateauArray.Last())
                };

                return plateauModel;
            }

            return null;
        }

        public static RoverPositionModel RoverPosition(string roverPosition)
        {
            var roverPositionArray = roverPosition.Split(" ");

            if (roverPositionArray.Length == 3) //checker
            {
                string position = roverPositionArray[2].ToUpper();

                try
                {
                    RoverPositionModel roverModel = new RoverPositionModel()
                    {
                        PositionX = int.Parse(roverPositionArray[0]),
                        PositionY = int.Parse(roverPositionArray[1]),
                        Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), position)
                    };

                    return roverModel;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        public static RoverRouteModel RoverRoute(string roverRoute)
        {
            RoverRouteModel routeModel = new RoverRouteModel() {Movements = new List<MovementEnum>() };

            char[] routeArray = roverRoute.ToCharArray();

            foreach (var route in routeArray)
            {
                try //checker
                {
                    var routeEnum = (MovementEnum)Enum.Parse(typeof(MovementEnum), route.ToString().ToUpper());
                    routeModel.Movements.Add(routeEnum);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return routeModel;
        }

    }
}
