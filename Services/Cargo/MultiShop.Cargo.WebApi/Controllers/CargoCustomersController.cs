using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase {
        private readonly ICargoCustomerService cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService) {
            this.cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList() {
            var values = cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id) {
            var value = cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id) {
            cargoCustomerService.TDelete(id);
            return Ok("CargoCustomer delete operation has been successfull");
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto) {
            CargoCustomer cargoCustomer = new CargoCustomer() {
                City = createCargoCustomerDto.City,
                Address = createCargoCustomerDto.Address,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name=createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
            };
            cargoCustomerService.TInsert(cargoCustomer);
            return Ok("CargoCustomer adding operation has been a success.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto) {
            CargoCustomer cargoCustomer = new CargoCustomer() {
                Address = updateCargoCustomerDto.Address,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                City = updateCargoCustomerDto.City,
                Phone = updateCargoCustomerDto.Phone,
                District = updateCargoCustomerDto.District,
                Surname = updateCargoCustomerDto.Surname,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            };
            cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("CargoCustomer update operation has been successfull");
        }
    }
}
