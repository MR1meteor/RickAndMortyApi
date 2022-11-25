using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Dtos.List;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.ListService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetListDto>>> GetListById(int id)
        {
            ServiceResponse<GetListDto> response = await _listService.GetListById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<ServiceResponse<GetListDto>>> AddList(AddListDto newList)
        {
            ServiceResponse<GetListDto> response = await _listService.AddList(newList);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<GetListDto>>> UpdateList(UpdateListDto updatedList)
        {
            ServiceResponse<GetListDto> response = await _listService.UpdateList(updatedList);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
