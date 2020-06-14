using System.Collections.Generic;
using System.Linq;
using MarsRover.Enums;
using MarsRover.Models;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTripTest
    {
        [Theory(DisplayName = "Rovers Trip")]
        [InlineData(1, "5 5", "1 2 N", "LMLMLMLMM", 1, 3, DirectionEnum.N)]
        [InlineData(2, "5 5", "3 3 E", "MMRMMRMRRM", 5, 1, DirectionEnum.E)]
        public void ToRoverTrip_ShouldAssertEqual_WhenConsoleInput(int index, string sizeOfPlateau, string roverPosition, string roverRoute, int expectedPositionX, int expectedPositionY, DirectionEnum expectedDirection)
        {
            //Arrange Step
            var roversTestInputModel = new RoversInputModel()
            {
                Plateau = sizeOfPlateau,
                RoversInput = new List<RoverInputModel>()
            };

            var roverTestModel = new RoverInputModel()
            {
                Index = index,
                Position = roverPosition,
                Route = roverRoute
            };

            roversTestInputModel.RoversInput.Add(roverTestModel);

            //Act Step
            var rovers = Manager.Manage(roversTestInputModel);

            //Assert Step
            Assert.NotNull(rovers.FirstOrDefault(a => a.Id == index));
            Assert.Equal(expectedPositionX, rovers.FirstOrDefault(a => a.Id == index).Position.PositionX);
            Assert.Equal(expectedPositionY, rovers.FirstOrDefault(a => a.Id == index).Position.PositionY);
            Assert.Equal(expectedDirection, rovers.FirstOrDefault(a => a.Id == index).Position.Direction);
        }
    }
}