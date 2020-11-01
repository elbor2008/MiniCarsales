using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCarsales.Api.Dto;
using MiniCarsales.Api.Models;
using MiniCarsales.Api.Repository;

namespace MiniCarsales.Api.Controllers
{
    public class CarsController : BaseApiController
    {
        private readonly IGenericRepository<Car> _repository;
        private readonly IMapper _mapper;

        public CarsController(IGenericRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var list = await _repository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CarReturnDto>>(list));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Car car)
        {
            if (await _repository.AddAsync(car) <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database error");
            }

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<CarReturnDto>(car));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (await _repository.DeleteAsync(id) <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database error");
            }

            return Ok();
        }
    }
}
