using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase {
        private readonly ICargoCompanyService cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService) {
            this.cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList() {
            var values = cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto) {
            CargoCompany cargoCompany = new CargoCompany() {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
            };
            cargoCompanyService.TInsert(cargoCompany);  
            return Ok("CargoCompany created succesfully.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id) {
            cargoCompanyService.TDelete(id);
            return Ok("CargoCompany deleted with success");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id) {
            var values = cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto) {
            CargoCompany cargoCompany = new CargoCompany() {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
            };
            cargoCompanyService.TUpdate(cargoCompany);
            return Ok("CargoCompany updated with success");
        }

    }
}
