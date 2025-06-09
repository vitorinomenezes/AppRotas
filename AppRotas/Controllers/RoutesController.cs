using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AppRotas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController(RouteService routeService) : ControllerBase
    {
        
        /// <summary>
        /// Retorna uma lista contendo as rotas cadastradas .
        /// </summary>
        /// <response code="200">Retorna a lista de rotas.</response>
        [HttpGet("GetAll")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<RouteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RouteDto), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RouteDto>>> GetAllRoutes()
        {
            var routes = await routeService.GetAllRoutesAsync();
            return Ok(routes);
        }

        /// <summary>
        /// Retorna os detalhes de uma rota específica.
        /// </summary>
        /// <param name="id">Código da rota.</param>
        /// <response code="200">Retorna a rota.</response>
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
            var route = await routeService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }

        /// <summary>
        /// Cadastra uma nova rota.
        /// </summary>
        /// <response code="200">Retorna OK.</response>
        /// <response code="201">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>

        [HttpPost("Create")]
        public async Task<ActionResult<RouteDto>> AddRoute(RouteDto routeDto)
        {
            var route = await routeService.AddRouteAsync(routeDto);
            return CreatedAtAction(nameof(GetRouteById), new { id = route.Id }, route);
        }


        /// <summary>
        /// Atualiza os detalhes de uma rota específica.
        /// </summary>
        /// <response code="204">Retorna o OK da ação bem sucedida.</response>
        /// <response code="200">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a ação for inválida.</response>


        [HttpPost("Update")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRoute(int id, RouteDto updateRouteDto)
        {
            if (id != updateRouteDto.Id)
            {
                return BadRequest("ID do caminho na URL não corresponde ao ID no corpo da requisição.");
            }

            var existingRoute = await routeService.GetRouteByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }

            await routeService.UpdateRouteAsync(updateRouteDto);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma rota específica.
        /// </summary>
        /// <response code="200">Excluir uma rota.</response>
        /// <response code="201">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a ação for inválida.</response>

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var existingRoute = await routeService.GetRouteByIdAsync(id);
            if (existingRoute == null)
            {
                return NotFound();
            }

            await routeService.DeleteRouteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Obtem a melhor rota, e valor, entre Origem e Destino.
        /// </summary>
        /// <response code="200">Obtem uma rota.</response>
        /// <response code="201">Retorna Ok de sucesso.</response>
        /// <response code="400">Retorna lista de erros, se a ação for inválida.</response>

        [HttpGet("FindBestRoute")]
        public async Task<ActionResult<string>> GetRoutesByOriginAndDestinationAsync([FromQuery] string origin, [FromQuery] string destination)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                return BadRequest("Origem e Destino são obrigatórios.");
            }

            var result = await routeService.GetRoutesByOriginAndDestinationAsync(origin.ToUpper(), destination.ToUpper());
            return Ok(result);
        }
    }
}
