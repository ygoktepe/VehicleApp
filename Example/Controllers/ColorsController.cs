using Example.DataAccess.Abstract;
using Example.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {
        IColorRepository _colorRepository;

        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(this._colorRepository.GetAll());
        }
        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            this._colorRepository.Add(color);
            return Ok("Başarılı");
        }

        [HttpPut("update")]
        public IActionResult Update(Color color)
        {
            this._colorRepository.Update(color);
            return Ok("Güncellendi");
        }
        [HttpDelete("deleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            this._colorRepository.Delete(this._colorRepository.Get(e => e.Id == id));
            return Ok("Silindi");
        }

    }
}
