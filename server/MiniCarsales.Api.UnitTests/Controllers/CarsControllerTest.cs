using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCarsales.Api.Controllers;
using MiniCarsales.Api.Dto;
using MiniCarsales.Api.Models;
using MiniCarsales.Api.Models.Enum;
using MiniCarsales.Api.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MiniCarsales.Api.UnitTests.Controllers
{
    public class CarsControllerTest
    {
        private readonly Mock<IGenericRepository<Car>> _mockGenericRepository;
        private readonly Mock<IMapper> _mockMapper;

        public CarsControllerTest()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Car>>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Get_car_list_success()
        {
            // Arrange
            var expectedCarListCount = 2;
            var expectedHttpCode = 200;
            var mockCarReturnDtoList = GetMockCarReturnDtoList();
            _mockGenericRepository.Setup(m => m.GetAllAsync()).Returns(Task.FromResult(It.IsAny<IEnumerable<Car>>()));
            _mockMapper.Setup(m => m.Map<IEnumerable<CarReturnDto>>(It.IsAny<IEnumerable<Car>>())).Returns(mockCarReturnDtoList);

            // Act
            var carsController = new CarsController(_mockGenericRepository.Object, _mockMapper.Object);
            var result = await carsController.GetListAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var carList = Assert.IsAssignableFrom<IEnumerable<CarReturnDto>>(okResult.Value);
            Assert.Equal(expectedHttpCode, okResult.StatusCode);
            Assert.Equal(expectedCarListCount, carList.Count());
        }

        [Fact]
        public async Task Add_car_success()
        {
            // Arrange
            var expectedHttpCode = 201;
            var expectedAddCarId = "ab4cea9a-390a-43e4-90ca-1f3849e2a69c";
            var mockCarReturnDto = GetMockCarReturnDto();
            _mockGenericRepository.Setup(m => m.AddAsync(It.IsAny<Car>())).Returns(Task.FromResult(1));
            _mockMapper.Setup(m => m.Map<CarReturnDto>(It.IsAny<Car>())).Returns(mockCarReturnDto);

            // Act
            var carsController = new CarsController(_mockGenericRepository.Object, _mockMapper.Object);
            var result = await carsController.AddAsync(new Car());

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var addedCar = Assert.IsAssignableFrom<CarReturnDto>(objectResult.Value);
            Assert.Equal(expectedHttpCode, objectResult.StatusCode);
            Assert.Equal(expectedAddCarId, addedCar.Id);
        }

        [Fact]
        public async Task Add_car_fail()
        {
            // Arrange
            var expectedHttpCode = 500;
            var mockCarReturnDto = GetMockCarReturnDto();
            _mockGenericRepository.Setup(m => m.AddAsync(It.IsAny<Car>())).Returns(Task.FromResult(0));
            _mockMapper.Setup(m => m.Map<CarReturnDto>(It.IsAny<Car>())).Returns(mockCarReturnDto);

            // Act
            var carsController = new CarsController(_mockGenericRepository.Object, _mockMapper.Object);
            var result = await carsController.AddAsync(new Car());

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedHttpCode, objectResult.StatusCode);
        }

        [Fact]
        public async Task Delete_car_success()
        {
            // Arrange
            var expectedHttpCode = 200;
            var mockCarReturnDto = GetMockCarReturnDto();
            _mockGenericRepository.Setup(m => m.DeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(1));

            // Act
            var carsController = new CarsController(_mockGenericRepository.Object, _mockMapper.Object);
            var result = await carsController.DeleteAsync("ab4cea9a-390a-43e4-90ca-1f3849e2a69c");

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(expectedHttpCode, okResult.StatusCode);
        }

        [Fact]
        public async Task Delete_car_fail()
        {
            // Arrange
            var expectedHttpCode = 500;
            var mockCarReturnDto = GetMockCarReturnDto();
            _mockGenericRepository.Setup(m => m.DeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(0));

            // Act
            var carsController = new CarsController(_mockGenericRepository.Object, _mockMapper.Object);
            var result = await carsController.DeleteAsync("ab4cea9a-390a-43e4-90ca-1f3849e2a69c");

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(expectedHttpCode, objectResult.StatusCode);
        }

        private CarReturnDto GetMockCarReturnDto() => new CarReturnDto
        {
            Id = "ab4cea9a-390a-43e4-90ca-1f3849e2a69c",
            Make = "nissan",
            Model = "x-trail",
            Engine = "4-cylinder",
            Doors = 4,
            Wheels = 4,
            VehicleType = VehicleType.Car.ToString(),
            BodyType = BodyType.SUV.ToString()
        };

        private IEnumerable<CarReturnDto> GetMockCarReturnDtoList() => new List<CarReturnDto>
        {
            new CarReturnDto
            {
                Id = "ab4cea9a-390a-43e4-90ca-1f3849e2a69c",
                Make = "nissan",
                Model = "x-trail",
                Engine = "4-cylinder",
                Doors=4,
                Wheels=4,
                VehicleType=VehicleType.Car.ToString(),
                BodyType=BodyType.SUV.ToString()
            },
            new CarReturnDto
            {
                Id = "9998a349-ce90-40e7-9d5a-bbcce0b5493c",
                Make = "nissan",
                Model = "x-trail Ti",
                Engine = "4-cylinder",
                Doors=4,
                Wheels=4,
                VehicleType=VehicleType.Car.ToString(),
                BodyType=BodyType.SUV.ToString()
            }
        };
    }
}
