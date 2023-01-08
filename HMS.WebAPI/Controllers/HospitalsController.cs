using HMS.BLL.Services.Interface;
using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using HMS.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalsController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospitalDto>>> GetList()
        {
            var response = await _hospitalService.GetListAsync();
            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HospitalDto>> GetByIdAsync(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _hospitalService.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<HospitalDto>> Create(HospitalDto itemDto)
        {

            var response = await _hospitalService.AddAsync(itemDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Hospital> Update(int id, [FromBody] HospitalDto obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _hospitalService.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }
            response = _hospitalService.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _hospitalService.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }

            _hospitalService.Delete(id);
            return NoContent();
        }
    }
}
