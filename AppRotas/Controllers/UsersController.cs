using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AppRotas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(UsersService service) : ControllerBase
    {

        /// <summary>
        /// Retorna uma lista contendo os usuarios cadastradas .
        /// </summary>
        /// <response code="200">Retorna a lista de usuarios.</response>
        [HttpGet("GetAll")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<RouteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RouteDto), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UsersDto>>> GetAll()
        {
            var routes = await service.GetAllAsync();
            return Ok(routes);
        }

        /// <summary>
        /// Retorna os detalhes de um usuario especifico.
        /// </summary>
        /// <param name="id">Código do usuario.</param>
        /// <response code="200">Retorna o usuario.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhuma rota é encontrada pelo id fornecido.</response>
        [HttpGet("Get/{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<RouteDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RouteDto>> GetRouteById(int id)
        {
            var route = await service.GetByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <response code="200">Retorna OK.</response>
        /// <response code="201">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>

        [HttpPost("Create")]
        public async Task<ActionResult<RouteDto>> AddRoute(UsersDto routeDto)
        {
            var route = await service.AddAsync(routeDto);
            return CreatedAtAction(nameof(GetRouteById), new { id = route.Id }, route);
        }


        /// <summary>
        /// Atualiza os detalhes de um usuario específico.
        /// </summary>
        /// <response code="204">Retorna o OK da ação bem sucedida.</response>
        /// <response code="200">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a ação for inválida.</response>


        [HttpPost("Update")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UsersDto updateRouteDto)
        {
            if (id != updateRouteDto.Id)
            {
                return BadRequest("ID do caminho na URL não corresponde ao ID no corpo da requisição.");
            }

            var existingRoute = await service.GetByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }

            await service.UpdateAsync(updateRouteDto);
            return NoContent();
        }

        /// <summary>
        /// Exclui um usuario específico.
        /// </summary>
        /// <response code="200">Excluir um usuario.</response>
        /// <response code="201">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a ação for inválida.</response>

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var existingRoute = await service.GetByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }

            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}
