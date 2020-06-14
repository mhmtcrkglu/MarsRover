using MarsRover.Models;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {

        static void Main(string[] args)
        {
            var roversInputModel = new RoversInputModel() { RoversInput = new List<RoverInputModel>() };

            Console.WriteLine("Enter the size of the plateau: ");
            string sizeOfPlateau = Console.ReadLine();
            roversInputModel.Plateau = sizeOfPlateau;
            int index = 1;
            bool confirmed;

            do
            {
                Console.WriteLine($"Enter coordinate for {index}. Rover: ");
                string roverPosition = Console.ReadLine();

                Console.WriteLine($"Enter route for {index}. Rover: ");
                string roverRoute = Console.ReadLine();

                var rover = new RoverInputModel
                {
                    Index = index,
                    Position = roverPosition,
                    Route = roverRoute
                };

                roversInputModel.RoversInput.Add(rover);

                ConsoleKey response;
                do
                {
                    Console.Write("Do you want to create new rover? [y/n] ");
                    response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.N && response != ConsoleKey.Y);

                confirmed = response == ConsoleKey.N;
                index++;
            } while (!confirmed);

            var rovers = Manager.Manage(roversInputModel);

            Console.WriteLine("Output :");

            foreach (var rover in rovers)
            {
                Console.WriteLine($"{rover.Position.PositionX} " +
                  $"{rover.Position.PositionY} " +
                  $"{rover.Position.Direction}");
            }

            Console.Write("Thanks for joining Mars Rover !");
            Console.ReadLine();
        }
    }
}
