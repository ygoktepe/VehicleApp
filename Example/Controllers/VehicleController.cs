using Example.DataAccess.Abstract;
using Example.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(this._vehicleRepository.GetAll());
        }
        [HttpGet("getByColor")]
        public IActionResult GetByColor(string color)
        {
            return Ok(this._vehicleRepository.GetAll(e => e.Color.Name == color));
        }
        [HttpPost("add")]
        public IActionResult Add(Vehicle vehicle)
        {
            this._vehicleRepository.Add(vehicle);
            return Ok("Başarılı");
        }

        [HttpPut("update")]
        public IActionResult Update(Vehicle vehicle)
        {
            this._vehicleRepository.Update(vehicle);
            return Ok("Güncellendi");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this._vehicleRepository.Delete(this._vehicleRepository.Get(e=>e.Id==id));
            return Ok("Silindi");
        }
    }
}
