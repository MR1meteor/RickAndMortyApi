using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Dtos.ListObject;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.ListObjectService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListObjectController : ControllerBase
    {
        private readonly IListObjectService _listObjectService;

        public ListObjectController(IListObjectService listObjectService)
        {
            _listObjectService = listObjectService;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse<GetListObjectDto<object>>>> GetListObjectById(int id)
        {
            ServiceResponse<GetListObjectDto<object>> response = await _listObjectService.GetListObjectById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetListObjectDto<object>>>> AddListObject(AddListObjectDto newObject)
        {
            ServiceResponse<GetListObjectDto<object>> response = await _listObjectService.AddListObject(newObject);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetListObjectDto<object>>>> UpdateListObject(UpdateListObjectDto updatedObject)
        {
            ServiceResponse<GetListObjectDto<object>> response = await _listObjectService.UpdateListObject(updatedObject);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
