using Microsoft.EntityFrameworkCore;
using MiniCarsales.Api.Data;
using MiniCarsales.Api.Models;
using MiniCarsales.Api.Models.Enum;
using MiniCarsales.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MiniCarsales.Api.UnitTests.Repository
{
    public class GenericRepositoryTest
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public GenericRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<VehicleDbContext>().UseInMemoryDatabase("testdb").Options;
            _vehicleDbContext = new VehicleDbContext(options);
            SeedData();
        }

        [Fact]
        public async Task Get_all_success()
        {
            // Arrange
            var expectedListCount = 2;

            // Act
            var genericRepository = new GenericRepository<Car>(_vehicleDbContext);
            var list = await genericRepository.GetAllAsync();

            // Assert
            Assert.Equal(expectedListCount, list.Count());
        }

        [Fact]
        public async Task Add_success()
        {
            // Arrange
            var expectedListCount = 3;

            // Act
            var genericRepository = new GenericRepository<Car>(_vehicleDbContext);
            await genericRepository.AddAsync(new Car
            {
                Make = "nissan",
                Model = "x-trail st",
                Engine = "4-cylinder",
                Doors = 4,
                Wheels = 4,
                VehicleType = VehicleType.Car,
                BodyType = BodyType.SUV
            });

            // Assert
            Assert.Equal(expectedListCount, _vehicleDbContext.Cars.Count());
        }

        private void SeedData()
        {
            _vehicleDbContext.RemoveRange(_vehicleDbContext.Cars);
            _vehicleDbContext.AddRange(
                new Car
                {
                    Make = "nissan",
                    Model = "x-trail",
                    Engine = "2-cylinder",
                    Doors = 4,
                    Wheels = 4,
                    VehicleType = VehicleType.Car,
                    BodyType = BodyType.SUV
                },
                new Car
                {
                    Make = "nissan",
                    Model = "x-trail Ti",
                    Engine = "4-cylinder",
                    Doors = 4,
                    Wheels = 4,
                    VehicleType = VehicleType.Car,
                    BodyType = BodyType.SUV
                }
            );
            _vehicleDbContext.SaveChanges();
        }
    }
}
