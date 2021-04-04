using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Service.Exceptions;
using store.Service.Model.Request.Order;
using store.Service.Model.Response.Order;

namespace store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerWithOrders(int orderNumber)
        {
            try
            {
                var result = await _mediator.Send(new GetOrderDetailsRequest(orderNumber));

                return Ok(result);
            }
            catch (EntityNotFoundServiceException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateOrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch(OrderNumberAlreadyExistServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityNotFoundServiceException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
