using Domain.Entities; // Make sure to include this for .Any()
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

public class RouteTests
{
    private readonly ITestOutputHelper _output;

    public RouteTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void FindMinCostRoute_GRU_to_CDG_ReturnsCorrectMinimumValue()
    {
        // Arrange
        var routes = new List<Route>
        {
            new Route { Origin = "GRU", Destination = "BRC", Value = 10 },
            new Route { Origin = "BRC", Destination = "SCL", Value = 5 },
            new Route { Origin = "GRU", Destination = "CDG", Value = 75 },
            new Route { Origin = "GRU", Destination = "SCL", Value = 20 },
            new Route { Origin = "GRU", Destination = "ORL", Value = 56 },
            new Route { Origin = "ORL", Destination = "CDG", Value = 5 },
            new Route { Origin = "SCL", Destination = "ORL", Value = 20 }
        };
        
        string origin = "GRU";
        string destination = "CDG";
        int expectedMinValue = 5; 

        // Act
        int actualMinValue = 10;

        // Assert
        Assert.Equal(expectedMinValue, actualMinValue);
    }
}