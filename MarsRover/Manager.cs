using MarsRover.Helpers;
using MarsRover.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class Manager
    {
        private static List<RoverModel> Rovers { get; set; } = new List<RoverModel>();

        public static List<RoverModel> Manage(RoversInputModel inputModel)
        {
            FillRovers(inputModel);

            ManagerOperation();

            return Rovers;
        }


        private static void FillRovers(RoversInputModel inputModel)
        {
            //Rovers Fill Operation
            Rovers.AddRange(inputModel.RoversInput.Select(a => new RoverModel
            {
                Id = a.Index,
                Plateau = InputHelper.Plateau(inputModel.Plateau),
                Position = InputHelper.RoverPosition(a.Position),
                Route = InputHelper.RoverRoute(a.Route)
            }));
        }

        private static void ManagerOperation()
        {
            foreach (var rover in Rovers)
            {
                if (rover.Route.Movements.Count > 0)
                {
                    Operations.Apply(rover);
                    rover.Route.Movements.RemoveAt(0);
                }
            }
            var check = Rovers.Any(a => a.Route.Movements.Count > 0);

            if (check)
            {
                ManagerOperation();
            }
            else
            {
                return;
            }
        }
    }
}
