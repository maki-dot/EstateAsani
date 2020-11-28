using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EstateApi.Contracts;
using EstateApi.Models;
using EstateApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsateController : ControllerBase
    {

        private IEsateRepository _estateRepository;


        public EsateController(IEsateRepository esateRepository)
        {
            _estateRepository = esateRepository;
        }


        [HttpGet]
        public IActionResult GetEsate()
        {

            var result = new ObjectResult(_estateRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _estateRepository.CountEsate().ToString());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEsate([FromRoute] int id)
        {


            if (await EstateExists(id))
            {
                var estate = await _estateRepository.Find(id);
                return Ok(estate);
            }
            else
            {
                return NotFound();
            }

        }


        private async Task<bool> EstateExists(int id)
        {
            return await _estateRepository.IsExists(id);
        }


        [HttpPost]
        public async Task<IActionResult> PostEsate([FromBody] Estate esate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _estateRepository.Add(esate);
            return CreatedAtAction("GetEsate", new { id = esate.EstateId }, esate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEsate([FromRoute] int id, [FromBody] EsateViewModel estate)
        {
            await _estateRepository.Update(estate);
            return Ok(estate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEsate([FromBody] EsateViewModel estate)
        {
            await _estateRepository.Remove(estate);
            return Ok();
        }
    }
}
