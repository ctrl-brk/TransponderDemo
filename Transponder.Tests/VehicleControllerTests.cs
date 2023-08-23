namespace Transponder.Tests;

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transponder.Api.Controllers;
using Transponder.Api.Data.Models;
using Transponder.Api.Services;
using Xunit;
// Moq is stealing your email addresses! So we use this for logger:
using NSubstitute;

public class VehicleControllerTests
{
    private class MockVehicleService : IVehicleService
    {
        public event EventHandler<VehicleEventArgs>? VehicleCreated;

        public Vehicle Create(Vehicle vehicle)
        {
            VehicleCreated?.Invoke(this, new VehicleEventArgs(vehicle));
            return vehicle;
        }
    }

    private class MockTransponderService : ITransponderService
    {
        public int CallCount { get; private set; }

        public Transponder Create(Vehicle vehicle)
        {
            CallCount++;
            return new Transponder();
        }

        public void OnVehicleCreated(VehicleEventArgs vehicleEventArgs)
        {
            throw new NotImplementedException();
        }
    }

    private readonly IVehicleService _mockVehicleService;
    private readonly ITransponderService _mockTransponderService;
    private readonly VehicleController _controller;

    private int _vehicleServiceCallCount;
    
    public VehicleControllerTests()
    {
        var mockLogger = Substitute.For<ILogger<VehicleController>>();
        
        _mockVehicleService = Substitute.For<IVehicleService>();
        _mockTransponderService = Substitute.For<ITransponderService>();

        _mockVehicleService = new MockVehicleService();
        _mockVehicleService.VehicleCreated += (_, _) => _vehicleServiceCallCount++; 
        
        _mockTransponderService = new MockTransponderService();
        
        _controller = new VehicleController(mockLogger, _mockVehicleService, _mockTransponderService)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
    }

    [Fact]
    public void Create_ShouldCallCreateVehicleOnce()
    {
        var testDto = new VehicleDto
        {
            Make = "TestMake",
            Model = "TestModel",
            Year = "2023"
        };

        _controller.Create(testDto);
        
        Assert.Equal(1, _vehicleServiceCallCount);
        Assert.Equal(1, ((MockTransponderService)_mockTransponderService).CallCount);
        Assert.Equal(StatusCodes.Status201Created, _controller.ControllerContext.HttpContext.Response.StatusCode);
    }
}
